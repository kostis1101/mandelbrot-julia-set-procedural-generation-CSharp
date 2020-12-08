
namespace mandelbrot_julia_set_tutorial
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
            this.imageCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCanvas
            // 
            this.imageCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCanvas.Location = new System.Drawing.Point(0, 0);
            this.imageCanvas.Name = "imageCanvas";
            this.imageCanvas.Size = new System.Drawing.Size(874, 496);
            this.imageCanvas.TabIndex = 1;
            this.imageCanvas.TabStop = false;
            this.imageCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.drawImage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 496);
            this.Controls.Add(this.imageCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox imageCanvas;
    }
}

