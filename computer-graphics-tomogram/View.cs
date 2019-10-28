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
        public int size = 150, start = 100;
        public void setupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            //GL.Translate(100, 100, 100);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.x, 0, Bin.y, -1, 1);
            //GL.Rotate(30, 1, 1, 0);
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
                GL.Begin(BeginMode.Polygon);
                GL.Color3(Color.Red);
                GL.Vertex3(0.5, -0.5, 0.5);
                GL.Vertex3(0.5, 0.5, 0.5);
                GL.Vertex3(-0.5, 0.5, 0.5);
                GL.Vertex3(-0.5, -0.5, 0.5);
                GL.End();
            }
        }

        int VBOtexture;
        Bitmap[] textureImage = new Bitmap[6];
        
        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData[] data = new BitmapData[6];
            for (int i = 0; i < 6; i++)
            {
                data[i] = textureImage[i].LockBits(
                new System.Drawing.Rectangle(0, 0, textureImage[i].Width, textureImage[i].Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                    data[i].Width, data[i].Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                    PixelType.UnsignedByte, data[i].Scan0);

                textureImage[i].UnlockBits(data[i]);

            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }

        public void generateTextureImage(int layerNumber)
        {
            for (int q = 0; q < 6; q++)
                textureImage[q] = new Bitmap(size, size);
            for (int i = 0; i < size; ++i)
                for (int j = 0; j <size; ++j)
                {
                    textureImage[0].SetPixel(i, j, TranserFunction(Bin.arrayNEW[start, i + start, j]));
                }
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage[1].SetPixel(i, j, TranserFunction(Bin.arrayNEW[start + size, i + start, j]));
                }


            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage[2].SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, start, j]));
                }
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage[3].SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, start + size, j]));
                }


            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage[4].SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, j + start, 0]));
                }
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage[5].SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, j + start, size]));
                }
        }

        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            GL.Begin(BeginMode.Quads);
            //1
            GL.Color3(Color.White);
            GL.TexCoord3(0f, 0f, 0f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(0f, 1f, 0f);
            GL.Vertex3(0, size, 0);
            GL.TexCoord3(0f, 1f, 1f);
            GL.Vertex3(0, size, size);
            GL.TexCoord3(0f, 0f, 1f);
            GL.Vertex3(0, 0, size);
            //2
            GL.Color3(Color.Green);
            GL.TexCoord3(1f, 0f, 0f);
            GL.Vertex3(size, 0, 0);
            GL.TexCoord3(1f, 0f, 1f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord3(1f, 1f, 1f);
            GL.Vertex3(size, size, size);
            GL.TexCoord3(1f, 1f, 0f);
            GL.Vertex3(size, size, 0);
            //3
            GL.Color3(Color.Red);
            GL.TexCoord3(0f, 0f, 0f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(0f, 0f, 1f);
            GL.Vertex3(0, 0, size);
            GL.TexCoord3(1f, 0f, 1f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord3(1f, 0f, 0f);
            GL.Vertex3(size, 0, 0);
            //4
            GL.Color3(Color.Yellow);
            GL.TexCoord3(0f, 1f, 0f);
            GL.Vertex3(0, size, 0);
            GL.TexCoord3(0f, 1f, 1f);
            GL.Vertex3(0, size, size);
            GL.TexCoord3(1f, 1f, 1f);
            GL.Vertex3(size, size, size);
            GL.TexCoord3(1f, 1f, 0f);
            GL.Vertex3(size, size, 0);
            //5
            GL.Color3(Color.Blue);
            GL.TexCoord3(0f, 0f, 0f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(1f, 0f, 0f);
            GL.Vertex3(size, 0, 0);
            GL.TexCoord3(1f, 1f, 0f);
            GL.Vertex3(size, size, 0);
            GL.TexCoord3(0f, 1f, 0f);
            GL.Vertex3(0, size, 0);
            //6
            GL.Color3(Color.Orange);
            GL.TexCoord3(0f, 0f, 1f);
            GL.Vertex3(0, 0, size);
            GL.TexCoord3(1f, 0f, 1f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord3(1f, 1f, 1f);
            GL.Vertex3(size, size, size);
            GL.TexCoord3(0f, 1f, 1f);
            GL.Vertex3(0, size, size);

            GL.End();

            GL.Disable(EnableCap.DepthTest);
        }
    }
}
