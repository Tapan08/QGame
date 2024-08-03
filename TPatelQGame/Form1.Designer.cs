namespace TPatelQGame
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
            this.Designbtn = new System.Windows.Forms.Button();
            this.Playbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Designbtn
            // 
            this.Designbtn.Location = new System.Drawing.Point(46, 72);
            this.Designbtn.Name = "Designbtn";
            this.Designbtn.Size = new System.Drawing.Size(155, 89);
            this.Designbtn.TabIndex = 0;
            this.Designbtn.Text = "Design";
            this.Designbtn.UseVisualStyleBackColor = true;
            this.Designbtn.Click += new System.EventHandler(this.Designbtn_Click);
            // 
            // Playbtn
            // 
            this.Playbtn.Location = new System.Drawing.Point(312, 72);
            this.Playbtn.Name = "Playbtn";
            this.Playbtn.Size = new System.Drawing.Size(158, 103);
            this.Playbtn.TabIndex = 1;
            this.Playbtn.Text = "Play";
            this.Playbtn.UseVisualStyleBackColor = true;
            this.Playbtn.Click += new System.EventHandler(this.Playbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Location = new System.Drawing.Point(172, 179);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(138, 80);
            this.Exitbtn.TabIndex = 2;
            this.Exitbtn.Text = "Exit";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Playbtn);
            this.Controls.Add(this.Designbtn);
            this.Name = "Form1";
            this.Text = "Control Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Designbtn;
        private System.Windows.Forms.Button Playbtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

