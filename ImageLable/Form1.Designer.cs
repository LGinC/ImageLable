namespace ImageLable
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除矩形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_Load = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.B_output = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_current = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.tb_index = new System.Windows.Forms.TextBox();
            this.B_skip = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label_file = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(48, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 1050);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除矩形ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.Text = "清除矩形";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenu_click);
            // 
            // 清除矩形ToolStripMenuItem
            // 
            this.清除矩形ToolStripMenuItem.Name = "清除矩形ToolStripMenuItem";
            this.清除矩形ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清除矩形ToolStripMenuItem.Text = "清除矩形";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // B_Load
            // 
            this.B_Load.Location = new System.Drawing.Point(334, 10);
            this.B_Load.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(33, 23);
            this.B_Load.TabIndex = 2;
            this.B_Load.Text = "...";
            this.B_Load.UseVisualStyleBackColor = true;
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(422, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(280, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // B_output
            // 
            this.B_output.Location = new System.Drawing.Point(708, 10);
            this.B_output.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.B_output.Name = "B_output";
            this.B_output.Size = new System.Drawing.Size(33, 23);
            this.B_output.TabIndex = 2;
            this.B_output.Text = "...";
            this.B_output.UseVisualStyleBackColor = true;
            this.B_output.Click += new System.EventHandler(this.B_output_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "图片";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "标注";
            // 
            // label_current
            // 
            this.label_current.AutoSize = true;
            this.label_current.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_current.Location = new System.Drawing.Point(336, 46);
            this.label_current.Name = "label_current";
            this.label_current.Size = new System.Drawing.Size(40, 16);
            this.label_current.TabIndex = 3;
            this.label_current.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "/";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_total.Location = new System.Drawing.Point(382, 46);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(40, 16);
            this.label_total.TabIndex = 3;
            this.label_total.Text = "0000";
            // 
            // tb_index
            // 
            this.tb_index.Location = new System.Drawing.Point(426, 43);
            this.tb_index.Name = "tb_index";
            this.tb_index.Size = new System.Drawing.Size(39, 21);
            this.tb_index.TabIndex = 5;
            // 
            // B_skip
            // 
            this.B_skip.Location = new System.Drawing.Point(481, 41);
            this.B_skip.Name = "B_skip";
            this.B_skip.Size = new System.Drawing.Size(75, 23);
            this.B_skip.TabIndex = 6;
            this.B_skip.Text = "跳转";
            this.B_skip.UseVisualStyleBackColor = true;
            this.B_skip.Click += new System.EventHandler(this.B_skip_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(95, 36);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(174, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "边框大小";
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(573, 50);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(29, 12);
            this.label_file.TabIndex = 3;
            this.label_file.Text = "标注";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1026, 502);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.B_skip);
            this.Controls.Add(this.tb_index);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label_current);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_output);
            this.Controls.Add(this.B_Load);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "图片标注";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_Load;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button B_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_current;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除矩形ToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_index;
        private System.Windows.Forms.Button B_skip;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_file;
    }
}

