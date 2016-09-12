namespace AStarExample
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
            this.gridPanel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStepOne = new System.Windows.Forms.Button();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.gbAlgorithms = new System.Windows.Forms.GroupBox();
            this.rbSimple = new System.Windows.Forms.RadioButton();
            this.rbOwn = new System.Windows.Forms.RadioButton();
            this.gbAlgorithms.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPanel.Location = new System.Drawing.Point(13, 13);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(843, 626);
            this.gridPanel.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 645);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Begin";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(13, 674);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStepOne
            // 
            this.btnStepOne.Enabled = false;
            this.btnStepOne.Location = new System.Drawing.Point(93, 645);
            this.btnStepOne.Name = "btnStepOne";
            this.btnStepOne.Size = new System.Drawing.Size(75, 23);
            this.btnStepOne.TabIndex = 3;
            this.btnStepOne.Text = "Next";
            this.btnStepOne.UseVisualStyleBackColor = true;
            this.btnStepOne.Click += new System.EventHandler(this.btnStepOne_Click);
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(360, 647);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(50, 20);
            this.tbWidth.TabIndex = 4;
            this.tbWidth.Text = "10";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(360, 676);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(50, 20);
            this.tbHeight.TabIndex = 5;
            this.tbHeight.Text = "10";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(313, 650);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 6;
            this.lblWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(313, 679);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 7;
            this.lblHeight.Text = "Height:";
            // 
            // gbAlgorithms
            // 
            this.gbAlgorithms.Controls.Add(this.rbOwn);
            this.gbAlgorithms.Controls.Add(this.rbSimple);
            this.gbAlgorithms.Location = new System.Drawing.Point(174, 645);
            this.gbAlgorithms.Name = "gbAlgorithms";
            this.gbAlgorithms.Size = new System.Drawing.Size(133, 52);
            this.gbAlgorithms.TabIndex = 9;
            this.gbAlgorithms.TabStop = false;
            this.gbAlgorithms.Text = "Algorithm used:";
            // 
            // rbSimple
            // 
            this.rbSimple.AutoSize = true;
            this.rbSimple.Location = new System.Drawing.Point(7, 19);
            this.rbSimple.Name = "rbSimple";
            this.rbSimple.Size = new System.Drawing.Size(56, 17);
            this.rbSimple.TabIndex = 0;
            this.rbSimple.Text = "Simple";
            this.rbSimple.UseVisualStyleBackColor = true;
            // 
            // rbOwn
            // 
            this.rbOwn.AutoSize = true;
            this.rbOwn.Checked = true;
            this.rbOwn.Location = new System.Drawing.Point(69, 19);
            this.rbOwn.Name = "rbOwn";
            this.rbOwn.Size = new System.Drawing.Size(47, 17);
            this.rbOwn.TabIndex = 1;
            this.rbOwn.TabStop = true;
            this.rbOwn.Text = "Own";
            this.rbOwn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 707);
            this.Controls.Add(this.gbAlgorithms);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.btnStepOne);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gridPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbAlgorithms.ResumeLayout(false);
            this.gbAlgorithms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStepOne;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.GroupBox gbAlgorithms;
        private System.Windows.Forms.RadioButton rbOwn;
        private System.Windows.Forms.RadioButton rbSimple;
    }
}

