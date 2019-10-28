namespace computer_graphics_tomogram
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenTK.GLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимВизуализацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.четырехугольникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстуройToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.четырехугольникиQuadStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.LightGreen;
            this.glControl1.Location = new System.Drawing.Point(18, 42);
            this.glControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1402, 785);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = true;
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.режимВизуализацииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1438, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // режимВизуализацииToolStripMenuItem
            // 
            this.режимВизуализацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.четырехугольникиToolStripMenuItem,
            this.текстуройToolStripMenuItem,
            this.четырехугольникиQuadStripToolStripMenuItem});
            this.режимВизуализацииToolStripMenuItem.Name = "режимВизуализацииToolStripMenuItem";
            this.режимВизуализацииToolStripMenuItem.Size = new System.Drawing.Size(201, 29);
            this.режимВизуализацииToolStripMenuItem.Text = "Режим визуализации";
            // 
            // четырехугольникиToolStripMenuItem
            // 
            this.четырехугольникиToolStripMenuItem.Name = "четырехугольникиToolStripMenuItem";
            this.четырехугольникиToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            this.четырехугольникиToolStripMenuItem.Text = "Четырехугольники";
            this.четырехугольникиToolStripMenuItem.Click += new System.EventHandler(this.четырехугольникиToolStripMenuItem_Click);
            // 
            // текстуройToolStripMenuItem
            // 
            this.текстуройToolStripMenuItem.Name = "текстуройToolStripMenuItem";
            this.текстуройToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            this.текстуройToolStripMenuItem.Text = "Текстурой";
            this.текстуройToolStripMenuItem.Click += new System.EventHandler(this.текстуройToolStripMenuItem_Click);
            // 
            // четырехугольникиQuadStripToolStripMenuItem
            // 
            this.четырехугольникиQuadStripToolStripMenuItem.Name = "четырехугольникиQuadStripToolStripMenuItem";
            this.четырехугольникиQuadStripToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            this.четырехугольникиQuadStripToolStripMenuItem.Text = "Четырехугольники (QuadStrip)";
            this.четырехугольникиQuadStripToolStripMenuItem.Click += new System.EventHandler(this.четырехугольникиQuadStripToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(348, 849);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(734, 69);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(348, 926);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(734, 69);
            this.trackBar2.SmallChange = 5;
            this.trackBar2.TabIndex = 3;
            this.trackBar2.TickFrequency = 5;
            this.trackBar2.Scroll += new System.EventHandler(this.TrackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar3.LargeChange = 100;
            this.trackBar3.Location = new System.Drawing.Point(348, 982);
            this.trackBar3.Maximum = 4000;
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(734, 69);
            this.trackBar3.SmallChange = 100;
            this.trackBar3.TabIndex = 4;
            this.trackBar3.TickFrequency = 100;
            this.trackBar3.Value = 2000;
            this.trackBar3.Scroll += new System.EventHandler(this.TrackBar3_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(282, 849);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 19);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Слой";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(176, 926);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 19);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Значение минимума";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(249, 982);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(92, 19);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Ширина TF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1438, 1049);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem режимВизуализацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem четырехугольникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстуройToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem четырехугольникиQuadStripToolStripMenuItem;
    }
}

