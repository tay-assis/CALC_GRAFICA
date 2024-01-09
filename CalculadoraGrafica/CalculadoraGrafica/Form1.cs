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
        private bool substituirZero = true;

        public Form1()
        {
            InitializeComponent();

        }

        // Verifica se a operação foi selecionada
        private bool VerificaOperacao()
        {
            return string.IsNullOrEmpty(operador); // Retorna true se a operação não foi selecionada
        }

        private void InserirTextBox(string texto)
        {
            Exibir_Num.Text += texto; // Atualiza o TextBox com o número digitado
        }

        private void LimparTextBox()
        {
            Exibir_Num.Clear(); // Limpa o TextBox
        }
        
        private void ReiniciarVariáveis()
        {
            num1 = 0; // Limpa o valor de num1
            num2 = 0; // Limpa o valor de num2
            operador = ""; // Limpa o valor de operador
            resultado = 0; // Limpa o valor de resultado
            substituirZero = true; // Define substituirZero como true
            LimparTextBox(); // Limpa o TextBox
            Exibir_Num.Text = resultado.ToString("0"); // Exibe 0 no TextBox

        }

        private double RetornaValorTextBox()
        {
            double valor = 0;
            if(double.TryParse(Exibir_Num.Text, out valor))
            {
                return valor;
            }
            else
            {
                MessageBox.Show("Por favor, insira um número válido.");
                return 0;
            }
        }

        private void AtualizaTextBox(object sender, EventArgs e)
        {
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = botao.Text; // Captura o texto do botão

            if (substituirZero)
            {
                Exibir_Num.Text = texto_Botao; // Atualiza o TextBox com o número digitado
                substituirZero = false;
            }
            else
            {
                InserirTextBox(texto_Botao);
            }
        }

        // Método que atualiza as variáveis num1 e num2 com o número 1
        private void Numero_1_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        // Método que atualiza as variáveis num1 e num2 com o número 2
        private void Numero_2_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        // Método que atualiza as variáveis num1 e num2 com o número 3
        private void Numero_3_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Botao_Soma_Click(object sender, EventArgs e)
        {
            num1 = RetornaValorTextBox();
            LimparTextBox(); // Limpa o TextBox
            operador = "+"; // Define a operação como soma
        }

        private void Exibir_Num_TextChanged(object sender, EventArgs e)
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
            num2 = RetornaValorTextBox();
            switch (operador)
            {
                case "+":
                    LimparTextBox(); // Limpa o TextBox
                    resultado = num1 + num2;
                    break;
                default:
                    resultado = RetornaValorTextBox(); // Retorna o valor do TextBox
                    break;
                // outras operações aqui...
            }

            Exibir_Num.Text = resultado.ToString();
            substituirZero = true;
        }

        private void Limpar_Tudo_Click(object sender, EventArgs e)
        {
            ReiniciarVariáveis(); // Reinicia as variáveis
        }
        
        private void Numero_4_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_5_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_6_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_7_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_8_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_9_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e); // Atualiza as variáveis
        }

        private void Numero_0_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = botao.Text; // Captura o texto do botão
            InserirTextBox(texto_Botao); // Atualiza as variáveis
        }

        private void Botao_Ponto_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string textoBotao = botao.Text; // Captura o texto do botão

            if (VerificaOperacao())
            {
                if (!Exibir_Num.Text.Contains(","))
                {
                    Exibir_Num.Text += textoBotao; // Adiciona o ponto no TextBox
                }
            }
            else
            {
                
                if (!Exibir_Num.Text.Contains("."))
                {
                    Exibir_Num.Text += textoBotao; // Adiciona o ponto decimal ao TextBox
                }
            }
        }
    }
}
