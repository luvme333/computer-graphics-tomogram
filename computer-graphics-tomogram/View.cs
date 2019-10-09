using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace computer_graphics_tomogram
{
    class View
    {
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
            int min = 0;
            int max = 2000;
            int newValue = clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, newValue, newValue, newValue);
        }

        public void DrawQuads(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
    }
}
