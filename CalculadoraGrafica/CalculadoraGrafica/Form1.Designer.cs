namespace CalculadoraGrafica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Numero_1 = new System.Windows.Forms.Button();
            this.Numero_2 = new System.Windows.Forms.Button();
            this.Botao_Soma = new System.Windows.Forms.Button();
            this.Exibir_Num = new System.Windows.Forms.TextBox();
            this.Botao_Igual = new System.Windows.Forms.Button();
            this.Numero_3 = new System.Windows.Forms.Button();
            this.Limpar_Tudo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Numero_1
            // 
            this.Numero_1.Font = new System.Drawing.Font("Mongolian Baiti", 25.92F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero_1.Location = new System.Drawing.Point(11, 319);
            this.Numero_1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Numero_1.Name = "Numero_1";
            this.Numero_1.Size = new System.Drawing.Size(59, 60);
            this.Numero_1.TabIndex = 0;
            this.Numero_1.TabStop = false;
            this.Numero_1.Text = "1";
            this.Numero_1.UseVisualStyleBackColor = true;
            this.Numero_1.Click += new System.EventHandler(this.Numero_1_Click);
            // 
            // Numero_2
            // 
            this.Numero_2.Font = new System.Drawing.Font("Mongolian Baiti", 25.92F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero_2.Location = new System.Drawing.Point(80, 319);
            this.Numero_2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Numero_2.Name = "Numero_2";
            this.Numero_2.Size = new System.Drawing.Size(59, 60);
            this.Numero_2.TabIndex = 2;
            this.Numero_2.TabStop = false;
            this.Numero_2.Text = "2";
            this.Numero_2.UseVisualStyleBackColor = true;
            this.Numero_2.Click += new System.EventHandler(this.Numero_2_Click);
            // 
            // Botao_Soma
            // 
            this.Botao_Soma.Font = new System.Drawing.Font("Mongolian Baiti", 28.224F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botao_Soma.Location = new System.Drawing.Point(344, 311);
            this.Botao_Soma.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Botao_Soma.Name = "Botao_Soma";
            this.Botao_Soma.Size = new System.Drawing.Size(75, 127);
            this.Botao_Soma.TabIndex = 11;
            this.Botao_Soma.TabStop = false;
            this.Botao_Soma.Text = "+";
            this.Botao_Soma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botao_Soma.UseVisualStyleBackColor = true;
            this.Botao_Soma.Click += new System.EventHandler(this.Botao_Soma_Click);
            // 
            // Exibir_Num
            // 
            this.Exibir_Num.Enabled = false;
            this.Exibir_Num.Font = new System.Drawing.Font("Mongolian Baiti", 47.808F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exibir_Num.Location = new System.Drawing.Point(11, 12);
            this.Exibir_Num.Multiline = true;
            this.Exibir_Num.Name = "Exibir_Num";
            this.Exibir_Num.ReadOnly = true;
            this.Exibir_Num.Size = new System.Drawing.Size(409, 96);
            this.Exibir_Num.TabIndex = 15;
            this.Exibir_Num.TabStop = false;
            this.Exibir_Num.Text = "0";
            this.Exibir_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Exibir_Num.TextChanged += new System.EventHandler(this.Exibir_Num_TextChanged);
            // 
            // Botao_Igual
            // 
            this.Botao_Igual.Font = new System.Drawing.Font("Microsoft Yi Baiti", 36.288F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botao_Igual.Location = new System.Drawing.Point(277, 380);
            this.Botao_Igual.Name = "Botao_Igual";
            this.Botao_Igual.Size = new System.Drawing.Size(59, 59);
            this.Botao_Igual.TabIndex = 16;
            this.Botao_Igual.TabStop = false;
            this.Botao_Igual.Text = "=";
            this.Botao_Igual.UseVisualStyleBackColor = true;
            this.Botao_Igual.Click += new System.EventHandler(this.Botao_Igual_Click);
            // 
            // Numero_3
            // 
            this.Numero_3.Font = new System.Drawing.Font("Mongolian Baiti", 25.92F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero_3.Location = new System.Drawing.Point(149, 319);
            this.Numero_3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Numero_3.Name = "Numero_3";
            this.Numero_3.Size = new System.Drawing.Size(59, 60);
            this.Numero_3.TabIndex = 3;
            this.Numero_3.TabStop = false;
            this.Numero_3.Text = "3";
            this.Numero_3.UseVisualStyleBackColor = true;
            this.Numero_3.Click += new System.EventHandler(this.Numero_3_Click);
            // 
            // Limpar_Tudo
            // 
            this.Limpar_Tudo.Font = new System.Drawing.Font("Mongolian Baiti", 12.096F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limpar_Tudo.Location = new System.Drawing.Point(11, 115);
            this.Limpar_Tudo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Limpar_Tudo.Name = "Limpar_Tudo";
            this.Limpar_Tudo.Size = new System.Drawing.Size(59, 60);
            this.Limpar_Tudo.TabIndex = 17;
            this.Limpar_Tudo.TabStop = false;
            this.Limpar_Tudo.Text = "AC";
            this.Limpar_Tudo.UseVisualStyleBackColor = true;
            this.Limpar_Tudo.Click += new System.EventHandler(this.Limpar_Tudo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 452);
            this.Controls.Add(this.Limpar_Tudo);
            this.Controls.Add(this.Numero_3);
            this.Controls.Add(this.Botao_Igual);
            this.Controls.Add(this.Exibir_Num);
            this.Controls.Add(this.Botao_Soma);
            this.Controls.Add(this.Numero_2);
            this.Controls.Add(this.Numero_1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Numero_1;
        private System.Windows.Forms.Button Numero_2;
        private System.Windows.Forms.Button Botao_Soma;
        private System.Windows.Forms.TextBox Exibir_Num;
        private System.Windows.Forms.Button Botao_Igual;
        private System.Windows.Forms.Button Numero_3;
        private System.Windows.Forms.Button Limpar_Tudo;
    }
}

