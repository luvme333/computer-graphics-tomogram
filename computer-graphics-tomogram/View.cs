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
        public int Minimum = 0;
        public int Width = 200;
        public bool quadSwitch = false;
        public int size = 60, start = 250;
        double rquad = 0;
        public void setupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(-size*3, size*3, -size*2, size*2, -size*1.5, size*1.5);
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

        public void generateTextureImage(int layernumber)
        {
            textureImage = new Bitmap(size, size);
            if (layernumber == 0)
            for (int i = 0; i < size; ++i)
                for (int j = 0; j <size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[start, i + start, j]));
                }

            if (layernumber == 1)
                for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[start + size, i + start, j]));
                }

            if (layernumber == 2)
                for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, start, j]));
                }
            if (layernumber == 3)
                for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, start + size, j]));
                }


            if (layernumber == 4)
                for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, j + start, 0]));
                }
            if (layernumber == 5)
                for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    textureImage.SetPixel(i, j, TranserFunction(Bin.arrayNEW[i + start, j + start, size]));
                }
        }


        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Rotate(rquad, 1, 1, 1);
            GL.Begin(BeginMode.Quads);
            //1
            generateTextureImage(0);
            VBOtexture = 0;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Color3(Color.White);
            GL.TexCoord2(1f, 1f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex3(0, size, 0);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(0, size, size);
            GL.TexCoord2(1f, 0f);
            GL.Vertex3(0, 0, size);
            GL.End();

            //2
            generateTextureImage(1);
            VBOtexture = 1;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 1);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 1f);
            GL.Vertex3(size, 0, 0);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord2(1f, 0f);
            GL.Vertex3(size, size, size);
            GL.TexCoord2(1f, 1f);
            GL.Vertex3(size, size, 0);
            GL.End();

            //3
            generateTextureImage(2);
            VBOtexture = 2;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(1f, -1f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord2(1f, 0f);
            GL.Vertex3(size, 0, 0);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(0f, -1f);
            GL.Vertex3(0, 0, size);
            GL.End();

            //4
            generateTextureImage(3);
            VBOtexture = 3;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 1f);
            GL.Vertex3(0, size, 0);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(0, size, size);
            GL.TexCoord2(1f, 0f);
            GL.Vertex3(size, size, size);
            GL.TexCoord2(1f, 1f);
            GL.Vertex3(size, size, 0);
            GL.End();

            //5
            generateTextureImage(4);
            VBOtexture = 4;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 4);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 1f);
            GL.Vertex3(size, size, 0);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(0, size, 0);
            GL.TexCoord2(-1f, 0f);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(-1f, 1f);
            GL.Vertex3(size, 0, 0);
            GL.End();

            //6
            generateTextureImage(5);
            VBOtexture = 5;
            Load2DTexture();
            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex3(0, 0, size);
            GL.TexCoord2(1f, 0f);
            GL.Vertex3(size, 0, size);
            GL.TexCoord2(1f, 1f);
            GL.Vertex3(size, size, size);
            GL.TexCoord2(0f, 1f);
            GL.Vertex3(0, size, size);

            GL.End();

            GL.Flush();
            rquad += 1;

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);
        }
    }
}
