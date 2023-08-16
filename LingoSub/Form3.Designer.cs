namespace LingoSub
{
    partial class Form3
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
            this.powrot = new System.Windows.Forms.Button();
            this.openfile = new System.Windows.Forms.Button();
            this.openDestination = new System.Windows.Forms.Button();
            this.file = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.Label();
            this.translate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // powrot
            // 
            this.powrot.Location = new System.Drawing.Point(28, 386);
            this.powrot.Name = "powrot";
            this.powrot.Size = new System.Drawing.Size(148, 51);
            this.powrot.TabIndex = 10;
            this.powrot.Text = "Powrót";
            this.powrot.UseVisualStyleBackColor = true;
            this.powrot.Click += new System.EventHandler(this.powrot_Click);
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(49, 67);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(106, 45);
            this.openfile.TabIndex = 11;
            this.openfile.Text = "Wybierz plik";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // openDestination
            // 
            this.openDestination.Location = new System.Drawing.Point(49, 173);
            this.openDestination.Name = "openDestination";
            this.openDestination.Size = new System.Drawing.Size(106, 45);
            this.openDestination.TabIndex = 12;
            this.openDestination.Text = "Wybierz folder docelowy";
            this.openDestination.UseVisualStyleBackColor = true;
            this.openDestination.Click += new System.EventHandler(this.openDestination_Click);
            // 
            // file
            // 
            this.file.AutoSize = true;
            this.file.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.file.Location = new System.Drawing.Point(291, 84);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(10, 13);
            this.file.TabIndex = 13;
            this.file.Text = " ";
            // 
            // destination
            // 
            this.destination.AutoSize = true;
            this.destination.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.destination.Location = new System.Drawing.Point(291, 190);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(10, 13);
            this.destination.TabIndex = 14;
            this.destination.Text = " ";
            // 
            // translate
            // 
            this.translate.Location = new System.Drawing.Point(646, 387);
            this.translate.Name = "translate";
            this.translate.Size = new System.Drawing.Size(142, 51);
            this.translate.TabIndex = 15;
            this.translate.Text = "Przetłumacz";
            this.translate.UseVisualStyleBackColor = true;
            this.translate.Click += new System.EventHandler(this.translate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.openfile);
            this.panel1.Controls.Add(this.powrot);
            this.panel1.Controls.Add(this.openDestination);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 451);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.translate);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.file);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LingoSub";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button powrot;
        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.Button openDestination;
        private System.Windows.Forms.Label file;
        private System.Windows.Forms.Label destination;
        private System.Windows.Forms.Button translate;
        private System.Windows.Forms.Panel panel1;
    }
}