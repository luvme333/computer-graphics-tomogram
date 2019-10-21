using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace computer_graphics_tomogram
{
    class View
    {
        public int Minimum= 0;
        public int Width = 2000;
        public bool quadSwitch = false;
        public void setupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.x, 0, Bin.y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        int clamp(int value, int min, int max)
        {
            return Math.Min(max, Math.Max(min, value));
        }
        Color TranserFunction(short value)
        {
            int min = Minimum;
            int max = Minimum + Width;
            int newValue = clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, newValue, newValue, newValue);
        }

        public void DrawQuads(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (!quadSwitch)
            {
                GL.Begin(BeginMode.Quads);
                for (int x_coord = 0; x_coord < Bin.x - 1; x_coord++)
                    for (int y_coord = 0; y_coord < Bin.y - 1; y_coord++)
                    {
                        short value;

                        value = Bin.array[x_coord + y_coord * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord, y_coord);

                        value = Bin.array[x_coord + (y_coord + 1) * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord, y_coord + 1);

                        value = Bin.array[x_coord + 1 + (y_coord + 1) * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord + 1, y_coord + 1);

                        value = Bin.array[x_coord + 1 + y_coord * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord + 1, y_coord);
                    }
                GL.End();
            }
            else
            {
                GL.Begin(BeginMode.QuadStrip);
                for (int x_coord = 0; x_coord < Bin.x - 1; x_coord++)
                    for (int y_coord = 0; y_coord < Bin.y - 1; y_coord++)
                    {
                        short value;

                        if ((x_coord == 0) && (y_coord == 0))
                        {
                            value = Bin.array[x_coord + y_coord * Bin.x +
                                layerNumber * Bin.x * Bin.y];
                            //GL.Color3(Color.DarkGreen);
                            GL.Color3(TranserFunction(value));
                            GL.Vertex2(x_coord, y_coord);

                            value = Bin.array[x_coord + (y_coord + 1) * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                            //GL.Color3(Color.White);
                            GL.Color3(TranserFunction(value));
                            GL.Vertex2(x_coord, y_coord + 1);
                        }

                        else
                        {
                            GL.Vertex2(x_coord, y_coord);
                            GL.Vertex2(x_coord, y_coord + 1);
                        }

                        value = Bin.array[x_coord + 1 + y_coord * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        //GL.Color3(Color.Red);
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord + 1, y_coord);

                        value = Bin.array[x_coord + 1 + (y_coord + 1) * Bin.x +
                            layerNumber * Bin.x * Bin.y];
                        //GL.Color3(Color.Aquamarine);
                        GL.Color3(TranserFunction(value));
                        GL.Vertex2(x_coord + 1, y_coord + 1);
                    }
                GL.End();
            }

        }

        int VBOtexture;
        Bitmap textureImage;

        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(
                new System.Drawing.Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            textureImage.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }

        public void generateTextureImage(int layerNumber)
        {
            textureImage = new Bitmap(Bin.x, Bin.y);
            for (int i = 0; i < Bin.x; ++i)
               for (int j = 0; j <Bin.y; ++j)
                {
                    int pixelNumber = i + j * Bin.x + layerNumber * Bin.x * Bin.y;
                    textureImage.SetPixel(i, j, TranserFunction(Bin.array[pixelNumber]));
                }
        }

        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, Bin.y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(Bin.x, Bin.y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(Bin.x, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }
    }
}
