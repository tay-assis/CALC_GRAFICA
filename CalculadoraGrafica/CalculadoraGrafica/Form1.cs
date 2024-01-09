using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraGrafica
{
    public partial class Form1 : Form
    {
        // Variáveis globais
        private double num1 = 0;
        private double num2 = 0;
        private string operador = "";
        private double resultado = 0;

        public Form1()
        {
            InitializeComponent();

            // Desabilitando o TextBox para edição e seleção
            Exibir_Num.ReadOnly = true;
            Exibir_Num.Enabled = false;
            Exibir_Num.Text = resultado.ToString("0");
        }

        // Verifica se a operação foi selecionada
        private bool VerificaOperacao()
        {
            return string.IsNullOrEmpty(operador); // Retorna true se a operação não foi selecionada
        }

        private void AtualizarExibirNum(string texto)
        {
            Exibir_Num.Text += texto; // Atualiza o TextBox com o número digitado
        }

        private void LimparTextBox()
        {
            Exibir_Num.Clear(); // Limpa o TextBox
        }   

        // Método que atualiza as variáveis num1 e num2 com o número 1
        public void Numero_1_Click(object sender, EventArgs e)
        {
            LimparTextBox(); // Limpa o TextBox
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = botao.Text; // Captura o texto do botão

            if(VerificaOperacao())
            {
                // Se não foi realizada nenhuma operação, os números vão para num1
                AtualizarExibirNum(texto_Botao); // Atualiza o TextBox com o número digitado
                double.TryParse(Exibir_Num.Text, out num1); // Armazena num1
            }
            else
            {
                AtualizarExibirNum(texto_Botao); // Atualiza o TextBox com o número digitado
                double.TryParse(Exibir_Num.Text, out num2); // Armazena num2
            }
        }

        // Método que atualiza as variáveis num1 e num2 com o número 2
        public void Numero_2_Click(object sender, EventArgs e)
        {
            LimparTextBox(); // Limpa o TextBox
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = botao.Text; // Captura o texto do botão

            if (VerificaOperacao())
            {
                // Se não foi realizada nenhuma operação, os números vão para num1
                AtualizarExibirNum(texto_Botao); // Atualiza o TextBox com o número digitado
                double.TryParse(Exibir_Num.Text, out num1); // Armazena num1
            }
            else
            {
                AtualizarExibirNum(texto_Botao); // Atualiza o TextBox com o número digitado
                double.TryParse(Exibir_Num.Text, out num2); // Armazena num2
            }
        }

        // Método que atualiza as variáveis num1 e num2 com o número 3
        private void Numero_3_Click(object sender, EventArgs e)
        {
            LimparTextBox(); // Limpa o TextBox
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = botao.Text; // Captura o texto do botão

            if (VerificaOperacao())
            {
                AtualizarExibirNum(texto_Botao);
                double.TryParse(Exibir_Num.Text, out num1);
            }
            else
            {
                AtualizarExibirNum(texto_Botao);
                double.TryParse(Exibir_Num.Text, out num2);
            }
        }

        public void Botao_Soma_Click(object sender, EventArgs e)
        {
            // Captura o valor do primeiro número inserido
            if (double.TryParse(Exibir_Num.Text, out num1))
            {
                operador = "+"; // Define a operação como soma
            }
            else
            {
                MessageBox.Show("Por favor, insira um número válido.");
            }
        }

        public void Exibir_Num_TextChanged(object sender, EventArgs e)
        {
            const int maximo_Caracteres = 10; // Define o número máximo de caracteres

            if (Exibir_Num.Text.Length > maximo_Caracteres)
            {
                // Se o número de caracteres exceder o máximo, remova o último caractere
                Exibir_Num.Text = Exibir_Num.Text.Substring(0, maximo_Caracteres);
            }
        }

        private void Botao_Igual_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Exibir_Num.Text, out num2))
            {
                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    // outras operações aqui...

                    default:
                        break;
                }

                Exibir_Num.Text = resultado.ToString();
                LimparTextBox(); // Limpa o TextBox
                Exibir_Num.Text = resultado.ToString("0");
            }
            else
            {
                MessageBox.Show("Por favor, insira um número válido.");
            }
        }

        
    }
}
