namespace JogoGrourmet
{
    partial class frmGourmet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGourmet));
            this.InicioLabel = new System.Windows.Forms.Label();
            this.IniciarButton = new System.Windows.Forms.Button();
            this.ResetarListaPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResetarListaPic)).BeginInit();
            this.SuspendLayout();
            // 
            // InicioLabel
            // 
            this.InicioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InicioLabel.AutoSize = true;
            this.InicioLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InicioLabel.Location = new System.Drawing.Point(59, 35);
            this.InicioLabel.Name = "InicioLabel";
            this.InicioLabel.Size = new System.Drawing.Size(236, 19);
            this.InicioLabel.TabIndex = 0;
            this.InicioLabel.Text = "Pense em um prato que gosta...";
            // 
            // IniciarButton
            // 
            this.IniciarButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IniciarButton.Location = new System.Drawing.Point(130, 75);
            this.IniciarButton.Name = "IniciarButton";
            this.IniciarButton.Size = new System.Drawing.Size(91, 34);
            this.IniciarButton.TabIndex = 1;
            this.IniciarButton.Text = "OK";
            this.IniciarButton.UseVisualStyleBackColor = true;
            this.IniciarButton.Click += new System.EventHandler(this.IniciarButton_Click);
            // 
            // ResetarListaPic
            // 
            this.ResetarListaPic.Image = ((System.Drawing.Image)(resources.GetObject("ResetarListaPic.Image")));
            this.ResetarListaPic.Location = new System.Drawing.Point(6, 100);
            this.ResetarListaPic.Name = "ResetarListaPic";
            this.ResetarListaPic.Size = new System.Drawing.Size(19, 19);
            this.ResetarListaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ResetarListaPic.TabIndex = 2;
            this.ResetarListaPic.TabStop = false;
            this.ResetarListaPic.Click += new System.EventHandler(this.ResetarListaPic_Click);
            // 
            // frmGourmet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 126);
            this.Controls.Add(this.ResetarListaPic);
            this.Controls.Add(this.IniciarButton);
            this.Controls.Add(this.InicioLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGourmet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Gourmet - Paul Moya V3";
            this.Load += new System.EventHandler(this.FrmGourmet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResetarListaPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InicioLabel;
        private System.Windows.Forms.Button IniciarButton;
        private System.Windows.Forms.PictureBox ResetarListaPic;
    }
}