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
        private bool loaded;
        private int currentLayer = 0;

        public Form1()
        {
            InitializeComponent();
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
            if (loaded)
            {
                view.DrawQuads(currentLayer);
                glControl1.SwapBuffers();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            if (loaded)
            {
                view.DrawQuads(currentLayer);
                glControl1.SwapBuffers();
            }
        }
    }
}
