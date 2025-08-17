namespace Group_Project_WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDims = new System.Windows.Forms.TextBox();
            this.txtHumans = new System.Windows.Forms.TextBox();
            this.txtZombies = new System.Windows.Forms.TextBox();
            this.txtNumDims = new System.Windows.Forms.TextBox();
            this.txtMaxIter = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblZombies = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblHumansLeft = new System.Windows.Forms.Label();
            this.lblIteration = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDim4 = new System.Windows.Forms.ComboBox();
            this.cmbDim5 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDims
            // 
            this.txtDims.Location = new System.Drawing.Point(647, 47);
            this.txtDims.Name = "txtDims";
            this.txtDims.Size = new System.Drawing.Size(100, 26);
            this.txtDims.TabIndex = 0;
            // 
            // txtHumans
            // 
            this.txtHumans.Location = new System.Drawing.Point(141, 9);
            this.txtHumans.Name = "txtHumans";
            this.txtHumans.Size = new System.Drawing.Size(100, 26);
            this.txtHumans.TabIndex = 1;
            // 
            // txtZombies
            // 
            this.txtZombies.Location = new System.Drawing.Point(142, 44);
            this.txtZombies.Name = "txtZombies";
            this.txtZombies.Size = new System.Drawing.Size(100, 26);
            this.txtZombies.TabIndex = 2;
            // 
            // txtNumDims
            // 
            this.txtNumDims.Location = new System.Drawing.Point(647, 12);
            this.txtNumDims.Name = "txtNumDims";
            this.txtNumDims.Size = new System.Drawing.Size(100, 26);
            this.txtNumDims.TabIndex = 3;
            // 
            // txtMaxIter
            // 
            this.txtMaxIter.Location = new System.Drawing.Point(386, 12);
            this.txtMaxIter.Name = "txtMaxIter";
            this.txtMaxIter.Size = new System.Drawing.Size(100, 26);
            this.txtMaxIter.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(142, 90);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 34);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(267, 90);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 34);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(394, 90);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 34);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(647, 383);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(100, 34);
            this.btnWrite.TabIndex = 8;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Human Count:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Zombie Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max Iterations:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "# of Dimensions:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Dimensions:";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(31, 364);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(568, 74);
            this.rtbLog.TabIndex = 16;
            this.rtbLog.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblZombies);
            this.groupBox1.Controls.Add(this.lblPercent);
            this.groupBox1.Controls.Add(this.lblHumansLeft);
            this.groupBox1.Controls.Add(this.lblIteration);
            this.groupBox1.Location = new System.Drawing.Point(605, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 244);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblZombies
            // 
            this.lblZombies.AutoSize = true;
            this.lblZombies.Location = new System.Drawing.Point(23, 150);
            this.lblZombies.Name = "lblZombies";
            this.lblZombies.Size = new System.Drawing.Size(74, 20);
            this.lblZombies.TabIndex = 3;
            this.lblZombies.Text = "Zombies:";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(17, 109);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(107, 20);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "% Remaining:";
            // 
            // lblHumansLeft
            // 
            this.lblHumansLeft.AutoSize = true;
            this.lblHumansLeft.Location = new System.Drawing.Point(19, 75);
            this.lblHumansLeft.Name = "lblHumansLeft";
            this.lblHumansLeft.Size = new System.Drawing.Size(105, 20);
            this.lblHumansLeft.TabIndex = 1;
            this.lblHumansLeft.Text = "Humans Left:";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(19, 36);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(80, 20);
            this.lblIteration.TabIndex = 0;
            this.lblIteration.Text = "Iterations:";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new System.Drawing.Point(31, 130);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(568, 222);
            this.pnlGrid.TabIndex = 18;
            // 
            // cmbFloor
            // 
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(317, 44);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(36, 28);
            this.cmbFloor.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dim3";
            // 
            // cmbDim4
            // 
            this.cmbDim4.FormattingEnabled = true;
            this.cmbDim4.Location = new System.Drawing.Point(405, 44);
            this.cmbDim4.Name = "cmbDim4";
            this.cmbDim4.Size = new System.Drawing.Size(36, 28);
            this.cmbDim4.TabIndex = 21;
            // 
            // cmbDim5
            // 
            this.cmbDim5.FormattingEnabled = true;
            this.cmbDim5.Location = new System.Drawing.Point(490, 44);
            this.cmbDim5.Name = "cmbDim5";
            this.cmbDim5.Size = new System.Drawing.Size(36, 28);
            this.cmbDim5.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Dim4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(440, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Dim5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDim5);
            this.Controls.Add(this.cmbDim4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbFloor);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMaxIter);
            this.Controls.Add(this.txtNumDims);
            this.Controls.Add(this.txtZombies);
            this.Controls.Add(this.txtHumans);
            this.Controls.Add(this.txtDims);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDims;
        private System.Windows.Forms.TextBox txtHumans;
        private System.Windows.Forms.TextBox txtZombies;
        private System.Windows.Forms.TextBox txtNumDims;
        private System.Windows.Forms.TextBox txtMaxIter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblZombies;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblHumansLeft;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDim4;
        private System.Windows.Forms.ComboBox cmbDim5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

