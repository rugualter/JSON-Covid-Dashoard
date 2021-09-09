
namespace JSONCovidDash.Views
{
    partial class MiniIndicator
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
            this.lblConfirmados = new System.Windows.Forms.Label();
            this.lblObitos = new System.Windows.Forms.Label();
            this.lblObitosNovos = new System.Windows.Forms.Label();
            this.lblConfirmadosNovos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConfirmados
            // 
            this.lblConfirmados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblConfirmados.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmados.ForeColor = System.Drawing.Color.White;
            this.lblConfirmados.Location = new System.Drawing.Point(0, 0);
            this.lblConfirmados.Name = "lblConfirmados";
            this.lblConfirmados.Size = new System.Drawing.Size(60, 15);
            this.lblConfirmados.TabIndex = 1;
            this.lblConfirmados.Text = "label2";
            this.lblConfirmados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblObitos
            // 
            this.lblObitos.BackColor = System.Drawing.Color.Black;
            this.lblObitos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblObitos.ForeColor = System.Drawing.Color.White;
            this.lblObitos.Location = new System.Drawing.Point(0, 15);
            this.lblObitos.Name = "lblObitos";
            this.lblObitos.Size = new System.Drawing.Size(60, 15);
            this.lblObitos.TabIndex = 2;
            this.lblObitos.Text = "label3";
            this.lblObitos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblObitosNovos
            // 
            this.lblObitosNovos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblObitosNovos.ForeColor = System.Drawing.Color.Black;
            this.lblObitosNovos.Location = new System.Drawing.Point(60, 15);
            this.lblObitosNovos.Name = "lblObitosNovos";
            this.lblObitosNovos.Size = new System.Drawing.Size(40, 15);
            this.lblObitosNovos.TabIndex = 5;
            this.lblObitosNovos.Text = "label4";
            this.lblObitosNovos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmadosNovos
            // 
            this.lblConfirmadosNovos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmadosNovos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblConfirmadosNovos.Location = new System.Drawing.Point(60, 0);
            this.lblConfirmadosNovos.Name = "lblConfirmadosNovos";
            this.lblConfirmadosNovos.Size = new System.Drawing.Size(40, 15);
            this.lblConfirmadosNovos.TabIndex = 4;
            this.lblConfirmadosNovos.Text = "label5";
            this.lblConfirmadosNovos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiniIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblObitosNovos);
            this.Controls.Add(this.lblConfirmadosNovos);
            this.Controls.Add(this.lblObitos);
            this.Controls.Add(this.lblConfirmados);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MiniIndicator";
            this.Size = new System.Drawing.Size(100, 30);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblConfirmados;
        private System.Windows.Forms.Label lblObitos;
        private System.Windows.Forms.Label lblObitosNovos;
        private System.Windows.Forms.Label lblConfirmadosNovos;
    }
}
