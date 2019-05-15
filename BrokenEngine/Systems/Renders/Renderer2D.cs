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
        private Shader shader;
        private Renderable[] renderableComponents;
        private uint lastEntityOffset;
        private uint indicieCount;

        public Renderer2D()
        {

            #region Shaders

            string[] vertexShaderSource = {"#version 330\n",
                "layout(location = 0) in vec2 pos;\n",
                "layout(location = 1) in vec4 colors;\n",
                "layout(location = 2) in vec2 texturepos;\n",
                "layout(location = 3) in float textureId;\n",

                "uniform mat4 pr_matrix;\n",
                "uniform mat4 modelView = mat4(1.0);\n",

                "out vec4 outColors;\n",
                "out vec2 outTexturePos;\n",
                "out float outTextureId;\n",

                "void main()\n",
                "{\n",
                    "gl_Position = pr_matrix * modelView * vec4(pos.xy, 1.0, 1.0);\n",
                    "//gl_Position = vec4(pos.xy, 1.0, 1.0);\n",

                    "outColors = colors;\n",
                    "outTexturePos = texturepos;\n",
                    "outTextureId = textureId;\n",
                "}\n" };

            string[] fragmentShaderSource = { "#version 330\n",
                "in vec4 outColors;\n",
                "in vec2 outTexturePos;\n",
                "in float outTextureId;\n",

                "uniform sampler2DArray textureArray;\n",

                "void main()\n",
                "{\n",
                    " vec4 finalColor = outColors;\n",

                    "if (outTextureId != 1024)\n",
                    "{\n",
                        "finalColor *= texture(textureArray, vec3(outTexturePos.xy, outTextureId));\n",
                    "}\n",

                    "gl_FragColor = finalColor;\n",
                "}\n" };

            #endregion

            lastEntityOffset    = 0;
            indicieCount        = 0;

            vao = new Vao();
            vbo = new Vbo(BufferUsage.DynamicDraw, 100000);
            ibo = new Ibo(100000 * 6);

            // Set layouts for vbo
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // x, y
            vbo.PushLayout(new BufferLayout(4, VertexAttribType.Float, false)); // r, g, b, a
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // tx, ty
            vbo.PushLayout(new BufferLayout(1, VertexAttribType.Float, false)); // texture id

            // Set shaders and stuff
            shader = new Shader(vertexShaderSource, fragmentShaderSource);

            // TEST ORTOGONAL
            shader.SetUniformM4("pr_matrix", Matrix4f.Orthogonal(800f, 0f, 600f, 0f, -1.0f, 1.0f));
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
                    vertexData.Add(renderableComponents[i].TextureOffsets[0, j].X);
                    vertexData.Add(renderableComponents[i].TextureOffsets[0, j].Y);

                    // Texture id
                    if (renderableComponents[i].Texture == null)
                        vertexData.Add(1024);
                    else
                        vertexData.Add(renderableComponents[i].Texture.Id);

                }

                Debug.Log("Flushed Entity Pos {" + vertexData[0] + ":" + vertexData[1] + "}", Debug.DebugLayer.Render, Debug.DebugLevel.Information);

                // Add data to vbo
                vbo.Bind();
                Gl.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)lastEntityOffset, (uint)(renderableComponents[i].Vertices.Length * vbo.VertexSize), vertexData.ToArray());
                vbo.Unbind();

                renderableComponents[i].IsSubmitted = true;
                lastEntityOffset += (uint)(renderableComponents[i].Vertices.Length * vbo.VertexSize);
                indicieCount += 6;
            }
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

            for (int i = 0; i < renderableComponents.Length; i++)
            {
                if (!renderableComponents[i].ComponentEnabled)
                    continue;

                if (!renderableComponents[i].Entity.EntityEnabled)
                    continue;

                shader.SetUniformM4("modelView", renderableComponents[i].Entity.ModelView);

                shader.Enable();
                vao.Bind();
                ibo.Bind();
                Gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, (IntPtr)((i * 6) * sizeof(int)));
                //Gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
                ibo.Unbind();
                vao.Unbind();
                shader.Disable();
            }
        }

        internal override void Update()
        {
            return;
        }
    }
}
