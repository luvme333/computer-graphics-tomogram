using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics_tomogram
{
    public partial class Form1 : Form
    {
        Bin bin = new Bin();
        View view = new View();
        bool needReload = true;
        private bool loaded = false;
        private int currentLayer = 0;
        private int FrameCount;
        private int switchMode = 0;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);

        public Form1()
        {
            InitializeComponent();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while(glControl1.IsIdle)
            {
                displayFPS();
                glControl1.Invalidate();
            }
        }

        void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
            FrameCount++;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str = dialog.FileName;
                bin.readBin(str);
                view.setupView(glControl1.Width, glControl1.Height);
                loaded = true;
                trackBar1.Maximum = Bin.z - 1;
                glControl1.Invalidate();
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            /*if (loaded)
            {
                if (switchMode == 0)
                {
                    if (needReload)
                    {
                        view.generateTextureImage(currentLayer);
                        view.Load2DTexture();
                        needReload = false;
                    }
                    view.DrawTexture();
                }
                if (switchMode == 1)
                {
                    view.DrawQuads(currentLayer);
                }
                glControl1.SwapBuffers();
            }*/
            view.setupView(view.size, view.size);
            view.DrawTexture();
            glControl1.SwapBuffers();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            needReload = true;
            /*view.DrawQuads(currentLayer);
            glControl1.SwapBuffers();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }

        private void четырехугольникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view.quadSwitch = false;
            switchMode = 1;
            needReload = true;
        }

        private void текстуройToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchMode = 0;
            needReload = true;
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            view.Minimum = trackBar2.Value;
            needReload = true;
        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {
            view.Width = trackBar3.Value;
            needReload = true;
        }

        private void четырехугольникиQuadStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchMode = 1;
            view.quadSwitch = true;
            needReload = true;
        }
    }
}
