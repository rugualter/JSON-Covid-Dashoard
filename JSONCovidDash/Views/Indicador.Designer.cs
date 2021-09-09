
namespace JSONCovidDash.Views
{
    partial class Indicador
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAcumulado = new System.Windows.Forms.Label();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "<Title>";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAcumulado
            // 
            this.lblAcumulado.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAcumulado.Location = new System.Drawing.Point(0, 20);
            this.lblAcumulado.Name = "lblAcumulado";
            this.lblAcumulado.Size = new System.Drawing.Size(100, 15);
            this.lblAcumulado.TabIndex = 1;
            this.lblAcumulado.Text = "<Acumulado>";
            this.lblAcumulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDiferenca.Location = new System.Drawing.Point(0, 35);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(100, 14);
            this.lblDiferenca.TabIndex = 2;
            this.lblDiferenca.Text = "<Diferença>";
            this.lblDiferenca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Indicador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDiferenca);
            this.Controls.Add(this.lblAcumulado);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Indicador";
            this.Size = new System.Drawing.Size(100, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAcumulado;
        private System.Windows.Forms.Label lblDiferenca;
    }
}
