namespace FlowShopPermutacional
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtNumeroSequencias = new System.Windows.Forms.TextBox();
            this.lblNumeroSequencias = new System.Windows.Forms.Label();
            this.btnBuscaVizinhamca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Teste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNumeroSequencias
            // 
            this.txtNumeroSequencias.Location = new System.Drawing.Point(61, 66);
            this.txtNumeroSequencias.Name = "txtNumeroSequencias";
            this.txtNumeroSequencias.Size = new System.Drawing.Size(75, 20);
            this.txtNumeroSequencias.TabIndex = 1;
            this.txtNumeroSequencias.Text = "10000";
            // 
            // lblNumeroSequencias
            // 
            this.lblNumeroSequencias.AutoSize = true;
            this.lblNumeroSequencias.Location = new System.Drawing.Point(61, 47);
            this.lblNumeroSequencias.Name = "lblNumeroSequencias";
            this.lblNumeroSequencias.Size = new System.Drawing.Size(116, 13);
            this.lblNumeroSequencias.TabIndex = 2;
            this.lblNumeroSequencias.Text = "Numero de sequencias";
            // 
            // btnBuscaVizinhamca
            // 
            this.btnBuscaVizinhamca.Location = new System.Drawing.Point(64, 188);
            this.btnBuscaVizinhamca.Name = "btnBuscaVizinhamca";
            this.btnBuscaVizinhamca.Size = new System.Drawing.Size(129, 23);
            this.btnBuscaVizinhamca.TabIndex = 3;
            this.btnBuscaVizinhamca.Text = "Busca Vizinhança";
            this.btnBuscaVizinhamca.UseVisualStyleBackColor = true;
            this.btnBuscaVizinhamca.Click += new System.EventHandler(this.btnBuscaVizinhamca_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscaVizinhamca);
            this.Controls.Add(this.lblNumeroSequencias);
            this.Controls.Add(this.txtNumeroSequencias);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNumeroSequencias;
        private System.Windows.Forms.Label lblNumeroSequencias;
        private System.Windows.Forms.Button btnBuscaVizinhamca;
    }
}

