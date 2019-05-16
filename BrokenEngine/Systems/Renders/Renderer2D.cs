using OpenGL;
using BrokenEngine.Systems.Buffers;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Utils;
using System.Collections.Generic;
using System;

namespace BrokenEngine.Systems.Renders
{
    class Renderer2D : BaseSystem
    {
        private Vao vao;
        private Vbo vbo;
        private Ibo ibo;
        private Renderable[] renderableComponents;
        private uint lastEntityOffset;

        public Renderer2D()
        {

            lastEntityOffset    = 0;

            vao = new Vao();
            vbo = new Vbo(BufferUsage.DynamicDraw, 100000);
            ibo = new Ibo(100000 * 6);

            // Set layouts for vbo
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // x, y
            vbo.PushLayout(new BufferLayout(4, VertexAttribType.Float, false)); // r, g, b, a
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // tx, ty
            vbo.PushLayout(new BufferLayout(1, VertexAttribType.Float, false)); // texture id

        }

        /// <summary>
        /// The start methods for the renderer
        /// </summary>
        internal override void Start()
        {

            vao.Bind();
            vbo.Bind();

            vbo.InitBuffer();

            ibo.Bind();
            ibo.SetBufferData();
            ibo.Unbind();

            vbo.Unbind();
            vao.Unbind();
        }

        /// <summary>
        /// Flush all the entities that has not been flushed
        /// </summary>
        private void Flush()
        {
            renderableComponents = EntityManager.Instance.GetEntitiesComponents<Renderable>();

            uint flushed = 0;

            if (renderableComponents.Length == 0)
                return;

            for (int i = 0; i < renderableComponents.Length; i++)
            {
                if (renderableComponents[i].IsSubmitted)
                    continue;

                renderableComponents[i].BufferOffset = lastEntityOffset;

                List<float> vertexData = new List<float>();

                for (int j = 0; j < renderableComponents[i].Vertices.Length; j++)
                {
                    // XY
                    vertexData.Add(renderableComponents[i].Vertices[j].X);
                    vertexData.Add(renderableComponents[i].Vertices[j].Y);

                    // RGBA 
                    vertexData.Add(renderableComponents[i].Colors[j].R);
                    vertexData.Add(renderableComponents[i].Colors[j].G);
                    vertexData.Add(renderableComponents[i].Colors[j].B);
                    vertexData.Add(renderableComponents[i].Colors[j].A);

                    // Tx Ty
                    if (renderableComponents[i].TextureOffsets != null)
                    {
                        vertexData.Add(renderableComponents[i].TextureOffsets[0, j].X);
                        vertexData.Add(renderableComponents[i].TextureOffsets[0, j].Y);
                    }
                    else
                    {
                        vertexData.Add(0);
                        vertexData.Add(0);
                    }


                    // Texture id
                    if (renderableComponents[i].Texture == null)
                        vertexData.Add(1024);
                    else
                        vertexData.Add(renderableComponents[i].Texture.Id);

                }

                // Add data to vbo
                vbo.Bind();
                Gl.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)lastEntityOffset, (uint)(renderableComponents[i].Vertices.Length * vbo.VertexSize), vertexData.ToArray());
                vbo.Unbind();

                renderableComponents[i].IsSubmitted = true;
                lastEntityOffset += (uint)(renderableComponents[i].Vertices.Length * vbo.VertexSize);

                flushed += 1;
            }

            if (flushed != 0)
                Debug.Log("Renderer Flushed " + flushed + " Entities", Debug.DebugLayer.Render, Debug.DebugLevel.Information);
        }

        internal void UpdateData() { throw new System.NotImplementedException(); }

        /// <summary>
        /// Draw all the entities that has a render component
        /// </summary>
        internal override void Draw()
        {
            Flush();

            if (renderableComponents.Length == 0)
                return;

            TextureManager.Instance.BindTextureArrayToShader("textureArray", Shader.BasicShader);
            TextureManager.Instance.BindTextureArray();

            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            for (int i = 0; i < renderableComponents.Length; i++)
            {
                if (!renderableComponents[i].ComponentEnabled)
                    continue;

                if (!renderableComponents[i].Entity.EntityEnabled)
                    continue;

                Shader.BasicShader.SetUniformM4("modelView", renderableComponents[i].Entity.ModelView);

                uint quadsCount = (uint)(renderableComponents[i].Vertices.Length / 4);

                // Draw
                
                Shader.BasicShader.Enable();
                vao.Bind();
                ibo.Bind();
                Gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, (IntPtr)((i * (6 * quadsCount)) * sizeof(int)));
                ibo.Unbind();
                vao.Unbind();
                Shader.BasicShader.Disable();
                
            }
            TextureManager.Instance.UnbindTextureArray();
        }

        internal override void Update()
        {
            return;
        }
    }
}
