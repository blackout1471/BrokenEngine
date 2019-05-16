using BrokenEngine.Systems.Buffers;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using OpenGL;
using System.Collections.Generic;
using System;
using BrokenEngine.Utils;

namespace BrokenEngine.Systems.Renders
{
    class BatchRenderer2D : BaseSystem
    {
        private Vao vao;
        private Vbo vbo;
        private Ibo ibo;
        private uint lastEntityOffset;
        private BatchRenderable[] particleComponents;

        public BatchRenderer2D()
        {
            lastEntityOffset = 0;

            vao = new Vao();
            vbo = new Vbo(BufferUsage.DynamicDraw, 100000);
            ibo = new Ibo(100000 * 6);

            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // xy
            vbo.PushLayout(new BufferLayout(4, VertexAttribType.Float, false)); // rgba
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // tx ty
            vbo.PushLayout(new BufferLayout(1, VertexAttribType.Float, false)); // texture id


        }

        /// <summary>
        /// The start method of the batchrenderer
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
        /// Flush the data to the gpu
        /// </summary>
        private void Flush()
        {
            particleComponents = EntityManager.Instance.GetEntitiesComponents<ParticleGenerator>();

            if (particleComponents.Length == 0)
                return;

            uint flushed = 0;

            for (int i = 0; i < particleComponents.Length; i++)
            {
                ParticleGenerator curComp = (ParticleGenerator)particleComponents[i];

                if (curComp.IsSubmitted)
                    continue;

                curComp.BufferOffset = lastEntityOffset;

                List<float> vertexData = new List<float>();

                for (int j = 0; j < curComp.Vertices.Length; j++)
                {
                    // XY
                    vertexData.Add(curComp.Vertices[j].X);
                    vertexData.Add(curComp.Vertices[j].Y);

                    // RGBA 
                    vertexData.Add(curComp.Colors[j].R);
                    vertexData.Add(curComp.Colors[j].G);
                    vertexData.Add(curComp.Colors[j].B);
                    vertexData.Add(curComp.Colors[j].A);

                    // Tx Ty
                    if (curComp.TextureOffsets != null)
                    {
                        vertexData.Add(curComp.TextureOffsets[0, j].X);
                        vertexData.Add(curComp.TextureOffsets[0, j].Y);
                    }
                    else
                    {
                        vertexData.Add(0);
                        vertexData.Add(0);
                    }


                    // Texture id
                    if (curComp.Texture == null)
                        vertexData.Add(1024);
                    else
                        vertexData.Add(curComp.Texture.Id);
                }

                // Add data to vbo
                vbo.Bind();
                Gl.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)lastEntityOffset, (uint)(curComp.Vertices.Length * vbo.VertexSize), vertexData.ToArray());
                vbo.Unbind();

                // Set component as submitted
                curComp.IsSubmitted = true;
                lastEntityOffset += (uint)(curComp.Vertices.Length * vbo.VertexSize);

                flushed += 1;

            }

            if (flushed != 0)
                Debug.Log("BatchRenderer Flushed " + flushed + " Entities", Debug.DebugLayer.Render, Debug.DebugLevel.Information);
        }


        internal void UpdateData() { throw new System.NotImplementedException(); }

        internal override void Draw()
        {
            Flush();

            if (particleComponents.Length == 0)
                return;

            TextureManager.Instance.BindTextureArrayToShader("textureArray", Shader.BasicShader);
            TextureManager.Instance.BindTextureArray();

            for (int i = 0; i < particleComponents.Length; i++)
            {
                ParticleGenerator curGenerator = (ParticleGenerator)particleComponents[i];

                if (!curGenerator.ComponentEnabled)
                    continue;

                if (!curGenerator.Entity.EntityEnabled)
                    continue;

                // Set model view for the shader
                Shader.batchShader.SetUniformM4("modelView", curGenerator.Entity.ModelView);
                
                // Set batch renderer offsets array

                uint quadsCount = (uint)(curGenerator.Vertices.Length / 4);

                Shader.batchShader.Enable();
                vao.Bind();
                ibo.Bind();
                //Gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, (IntPtr)((i * (6 * quadsCount)) * sizeof(int)));
                Gl.DrawElementsInstanced(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, (IntPtr)((i * (6 * quadsCount)) * sizeof(int)), curGenerator.ParticleCount);
                ibo.Unbind();
                vao.Unbind();
                Shader.batchShader.Disable();
            }

            TextureManager.Instance.UnbindTextureArray();
        }

        internal override void Update()
        {
            return;
        }

    }
}
