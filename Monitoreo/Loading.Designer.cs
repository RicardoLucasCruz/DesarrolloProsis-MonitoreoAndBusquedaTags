namespace Monitoreo
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.PbLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // PbLoading
            // 
            this.PbLoading.Image = ((System.Drawing.Image)(resources.GetObject("PbLoading.Image")));
<<<<<<< HEAD
            this.PbLoading.Location = new System.Drawing.Point(164, 64);
            this.PbLoading.Name = "PbLoading";
            this.PbLoading.Size = new System.Drawing.Size(220, 169);
            this.PbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLoading.TabIndex = 0;
            this.PbLoading.TabStop = false;
//            this.PbLoading.Click += new System.EventHandler(this.PbLoading_Click);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 688);
            this.Controls.Add(this.PbLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
=======
            this.PbLoading.Location = new System.Drawing.Point(783, 309);
            this.PbLoading.Margin = new System.Windows.Forms.Padding(4);
            this.PbLoading.Name = "PbLoading";
            this.PbLoading.Size = new System.Drawing.Size(293, 208);
            this.PbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLoading.TabIndex = 0;
            this.PbLoading.TabStop = false;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 851);
            this.Controls.Add(this.PbLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
>>>>>>> origin
            this.Name = "Loading";
            this.Opacity = 0.65D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
<<<<<<< HEAD
            this.Load += new System.EventHandler(this.Loading_Load);
=======
>>>>>>> origin
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLoading;
    }
}