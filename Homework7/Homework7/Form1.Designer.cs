namespace Homework7
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
            this.button1 = new System.Windows.Forms.Button();
            this.Depth = new System.Windows.Forms.Label();
            this.TrunkLength = new System.Windows.Forms.TextBox();
            this.TrunkLenth = new System.Windows.Forms.Label();
            this.PerRight = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PerLeft = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.AngelRight = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.AngelLeft = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.TextBox();
            this.Green = new System.Windows.Forms.TextBox();
            this.Blue = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RecursiveDepth = new System.Windows.Forms.TextBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PerRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngelRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngelLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1177, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 118);
            this.button1.TabIndex = 0;
            this.button1.Text = "draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Depth
            // 
            this.Depth.AutoSize = true;
            this.Depth.Location = new System.Drawing.Point(1227, 80);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(120, 27);
            this.Depth.TabIndex = 1;
            this.Depth.Text = "递归深度";
            // 
            // TrunkLength
            // 
            this.TrunkLength.Location = new System.Drawing.Point(1352, 146);
            this.TrunkLength.Name = "TrunkLength";
            this.TrunkLength.Size = new System.Drawing.Size(280, 38);
            this.TrunkLength.TabIndex = 3;
            this.TrunkLength.TextChanged += new System.EventHandler(this.TrunkLength_TextChanged);
            // 
            // TrunkLenth
            // 
            this.TrunkLenth.AutoSize = true;
            this.TrunkLenth.Location = new System.Drawing.Point(1226, 150);
            this.TrunkLenth.Name = "TrunkLenth";
            this.TrunkLenth.Size = new System.Drawing.Size(120, 27);
            this.TrunkLenth.TabIndex = 4;
            this.TrunkLenth.Text = "主干长度";
            // 
            // PerRight
            // 
            this.PerRight.BackColor = System.Drawing.SystemColors.Control;
            this.PerRight.Location = new System.Drawing.Point(1351, 212);
            this.PerRight.Maximum = 500;
            this.PerRight.Name = "PerRight";
            this.PerRight.Size = new System.Drawing.Size(281, 101);
            this.PerRight.TabIndex = 5;
            this.PerRight.Scroll += new System.EventHandler(this.PerRight_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1172, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "右分支长度比";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1172, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "左分支长度比";
            // 
            // PerLeft
            // 
            this.PerLeft.Location = new System.Drawing.Point(1352, 287);
            this.PerLeft.Maximum = 500;
            this.PerLeft.Name = "PerLeft";
            this.PerLeft.Size = new System.Drawing.Size(280, 101);
            this.PerLeft.TabIndex = 9;
            this.PerLeft.Scroll += new System.EventHandler(this.PerLeft_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1199, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "右分支角度";
            // 
            // AngelRight
            // 
            this.AngelRight.Location = new System.Drawing.Point(1352, 361);
            this.AngelRight.Maximum = 180;
            this.AngelRight.Name = "AngelRight";
            this.AngelRight.Size = new System.Drawing.Size(279, 101);
            this.AngelRight.TabIndex = 11;
            this.AngelRight.Scroll += new System.EventHandler(this.AngelRight_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1199, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "左分支角度";
            // 
            // AngelLeft
            // 
            this.AngelLeft.Location = new System.Drawing.Point(1353, 437);
            this.AngelLeft.Maximum = 180;
            this.AngelLeft.Name = "AngelLeft";
            this.AngelLeft.Size = new System.Drawing.Size(279, 101);
            this.AngelLeft.TabIndex = 13;
            this.AngelLeft.Scroll += new System.EventHandler(this.AngelLeft_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1281, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 14;
            this.label5.Text = "颜色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1356, 584);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 27);
            this.label6.TabIndex = 15;
            this.label6.Text = "R";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1356, 643);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 27);
            this.label7.TabIndex = 16;
            this.label7.Text = "G";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1356, 704);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 27);
            this.label8.TabIndex = 17;
            this.label8.Text = "B";
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(1404, 580);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(146, 38);
            this.Red.TabIndex = 18;
            this.Red.TextChanged += new System.EventHandler(this.Red_TextChanged);
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(1404, 640);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(146, 38);
            this.Green.TabIndex = 19;
            this.Green.TextChanged += new System.EventHandler(this.Green_TextChanged);
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(1404, 701);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(146, 38);
            this.Blue.TabIndex = 20;
            this.Blue.TextChanged += new System.EventHandler(this.Blue_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "黑色",
            "红色",
            "黄色",
            "绿色",
            "蓝色",
            "紫色",
            "自定义"});
            this.comboBox1.Location = new System.Drawing.Point(1354, 511);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(278, 35);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // RecursiveDepth
            // 
            this.RecursiveDepth.Location = new System.Drawing.Point(1351, 75);
            this.RecursiveDepth.Name = "RecursiveDepth";
            this.RecursiveDepth.Size = new System.Drawing.Size(280, 38);
            this.RecursiveDepth.TabIndex = 22;
            this.RecursiveDepth.TextChanged += new System.EventHandler(this.RecursiveDepth_TextChanged);
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.SystemColors.Window;
            this.drawPanel.Location = new System.Drawing.Point(37, 35);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1108, 719);
            this.drawPanel.TabIndex = 23;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1699, 795);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.RecursiveDepth);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AngelLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AngelRight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PerLeft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PerRight);
            this.Controls.Add(this.TrunkLenth);
            this.Controls.Add(this.TrunkLength);
            this.Controls.Add(this.Depth);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PerRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngelRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngelLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Depth;
        private System.Windows.Forms.TextBox TrunkLength;
        private System.Windows.Forms.Label TrunkLenth;
        private System.Windows.Forms.TrackBar PerRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar PerLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar AngelRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar AngelLeft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Red;
        private System.Windows.Forms.TextBox Green;
        private System.Windows.Forms.TextBox Blue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox RecursiveDepth;
        private System.Windows.Forms.Panel drawPanel;
    }
}

