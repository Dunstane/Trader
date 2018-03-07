namespace TradeSystemSkelengton
{
    partial class MainGui
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
            this.SimulationPB = new System.Windows.Forms.PictureBox();
            this.citieslb = new System.Windows.Forms.ListBox();
            this.TestPopulatebt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationPB)).BeginInit();
            this.SuspendLayout();
            // 
            // SimulationPB
            // 
            this.SimulationPB.Location = new System.Drawing.Point(43, 12);
            this.SimulationPB.Name = "SimulationPB";
            this.SimulationPB.Size = new System.Drawing.Size(1122, 442);
            this.SimulationPB.TabIndex = 0;
            this.SimulationPB.TabStop = false;
            // 
            // citieslb
            // 
            this.citieslb.FormattingEnabled = true;
            this.citieslb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.citieslb.Location = new System.Drawing.Point(609, 460);
            this.citieslb.Name = "citieslb";
            this.citieslb.Size = new System.Drawing.Size(556, 95);
            this.citieslb.TabIndex = 1;
            // 
            // TestPopulatebt
            // 
            this.TestPopulatebt.Location = new System.Drawing.Point(1090, 569);
            this.TestPopulatebt.Name = "TestPopulatebt";
            this.TestPopulatebt.Size = new System.Drawing.Size(75, 23);
            this.TestPopulatebt.TabIndex = 2;
            this.TestPopulatebt.Text = "Test";
            this.TestPopulatebt.UseVisualStyleBackColor = true;
            this.TestPopulatebt.Click += new System.EventHandler(this.TestPopulatebt_Click);
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 604);
            this.Controls.Add(this.TestPopulatebt);
            this.Controls.Add(this.citieslb);
            this.Controls.Add(this.SimulationPB);
            this.Name = "MainGui";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.SimulationPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SimulationPB;
        private System.Windows.Forms.ListBox citieslb;
        private System.Windows.Forms.Button TestPopulatebt;
    }
}

