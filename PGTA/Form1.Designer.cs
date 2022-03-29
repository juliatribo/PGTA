namespace PGTA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn1 = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.showText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(859, 37);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(150, 46);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Browse";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(61, 37);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(752, 39);
            this.textFile.TabIndex = 1;
            // 
            // showText
            // 
            this.showText.Location = new System.Drawing.Point(61, 119);
            this.showText.Multiline = true;
            this.showText.Name = "showText";
            this.showText.Size = new System.Drawing.Size(752, 548);
            this.showText.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1042, 734);
            this.Controls.Add(this.showText);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn1;
        private TextBox textFile;
        private TextBox showText;
    }
}