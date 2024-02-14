using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraGrafica
{
    public partial class Form1 : Form
    {
        // Variáveis globais
        private double resultado = 0;
        private bool substituirZero = true;
        private bool textBoxAlterado = false;

        // Método construtor
        public Form1()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(Form1TecladoSelecionado);

        }

        // Método que faz a leitura do teclado
        private void Form1TecladoSelecionado(object sender, KeyPressEventArgs e)
        {
            // Verifica se o botão pressionado é um número
            if (char.IsDigit(e.KeyChar))
            {
                // Se for um número, insira no TextBox
                InserirTextBox(e.KeyChar.ToString());
            }
            else if (e.KeyChar == ',')
            {
                // Se for uma vírgula, insira no TextBox
                InserirTextBox(",");
            }
            else if (e.KeyChar == '.')
            {
                // Se for uma ponto, insira no TextBox
                InserirTextBox(",");
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                // Insere o operador/sinal no TextBox
                InserirTextBox(e.KeyChar.ToString());
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                // Se for a tecla Enter, realize a operação
                Botao_Igual_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Se for a tecla Backspace, remova o último caractere
                Botao_Deletar_Click(sender, e);
            }
            else if (e.KeyChar == '(' || e.KeyChar == ')')
            {
                InserirTextBox(e.KeyChar.ToString());
            }
        }
 
        // Método que exibe uma mensagem de erro no TextBox
        private async void MensagemErroTextBox()
        {
            string mensagem = "ERRO";
            int tempoEmMiliSegundos = 3000;
            Exibir_Num.Text = mensagem;
            await Task.Delay(tempoEmMiliSegundos);
            ReiniciarVariáveis();
        }

        // Método que insere o número digitado no TextBox
        private void InserirTextBox(string texto)
        {
            if (substituirZero == true)
            {
                Exibir_Num.Text = texto;
            }
            else
            {
                Exibir_Num.Text += texto;
            }
            substituirZero = false;
            textBoxAlterado = true;
        }

        // Método que limpa o TextBox
        private void LimparTextBox()
        {
            Exibir_Num.Clear();
        }

        // Função que remove o foco dos botões
        private void DesativarFoco()
        {
            this.ActiveControl = null;
        }
        
        // Método que reinicia as variáveis
        private void ReiniciarVariáveis()
        { 
            resultado = 0; 
            substituirZero = true; 
            LimparTextBox(); 
            Exibir_Num.Text = resultado.ToString("0");
            textBoxAlterado = false;

        }

        // Método que atualiza o TextBox
        private void AtualizaTextBox(object sender, EventArgs e, string texto)
        {
            DesativarFoco();
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = texto; // Captura o texto do botão

            if (substituirZero)
            {
                Exibir_Num.Text = texto_Botao; // Substitui o número digitado no TextBox
                substituirZero = false;
            }
            else
            {
                InserirTextBox(texto_Botao);
            }
            textBoxAlterado = true;
        }

        // Método que adiciona o número 1 no TextBox
        private void Numero_1_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "1");
        }

        // Método que adiciona o número 2 no TextBox
        private void Numero_2_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "2"); 
        }

        // Método que adiciona o número 3 no TextBox
        private void Numero_3_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "3");
        }

        // Método que adiciona a operação de soma no TextBox
        private void Botao_Soma_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                Exibir_Num.Text += "+";
            }
        }

        // Método que verifica se número máximo de caracteres foi excedido
        private void Exibir_Num_TextChanged(object sender, EventArgs e)
        {
            const int maximo_Caracteres = 20; // Define o número máximo de caracteres
        
            if (Exibir_Num.Text.Length > maximo_Caracteres)
            {
                // Se o número de caracteres exceder o máximo, remova o último caractere
                Exibir_Num.Text = Exibir_Num.Text.Substring(0, maximo_Caracteres);
            }
        }

        // Método que separa os números e operadores e realiza as operações
        private void Botao_Igual_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                string expressao = Exibir_Num.Text;
                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();
                string numeroAtual = "";

                for (int i = 0; i < expressao.Length; i++)
                {
                    char caractere = expressao[i];

                    if (char.IsDigit(caractere) || caractere == ',')
                    {
                        numeroAtual += caractere;
                    }
                    else if (caractere == '-')
                    {
                        // Verifica se o "-" é um operador ou parte de um número negativo
                        if (i == 0 || (!char.IsDigit(expressao[i - 1]) && expressao[i - 1] != ','))
                        {
                            numeroAtual += caractere; // Considera como parte do número negativo
                        }
                        else
                        {
                            // É um operador de subtração
                            AdicionarNumero(numeroAtual, numeros);
                            numeroAtual = "";
                            operadores.Add(caractere);
                        }
                    }
                    else if (caractere == '+' || caractere == '*' || caractere == '/' || caractere == '√')
                    {
                        AdicionarNumero(numeroAtual, numeros);
                        numeroAtual = "";
                        operadores.Add(caractere);
                    }
                }

                AdicionarNumero(numeroAtual, numeros);

                double resultado = RealizarOperacoes(numeros, operadores);
                Exibir_Num.Text = resultado.ToString();
            }
        }

        // Método que adiciona o número atual na lista de números
        private void AdicionarNumero(string numeroAtual, List<double> numeros)
        {
            if (numeroAtual != "")
            {
                double numero = double.Parse(numeroAtual);
                numeros.Add(numero);
            }
        }

        // Método que realiza as operações
        private double RealizarOperacoes(List<double> numeros, List<char> operadores)
        {
            double resultado = 0;
            int indice = 0;

            while (operadores.Count > 0)
            {
                char operador = operadores[0];      
                if (operador == '√')
                {
                    double num1 = numeros[indice];
                    resultado = Math.Sqrt(num1);

                    // Atualiza a lista de números e remove o operador
                    numeros[0] = resultado;
                    numeros.RemoveAt(0);
                    operadores.RemoveAt(0);
                }
                else
                {
                    double num1 = numeros[indice];
                    double num2 = numeros[indice + 1];

                    if (operador == '+')
                    {
                        resultado = num1 + num2;
                    }
                    else if (operador == '-')
                    {
                        resultado = num1 - num2;
                    }
                    else if (operador == '*')
                    {
                        resultado = num1 * num2;
                    }
                    else if (operador == '/')
                    {
                        if (num2 == 0)
                        {
                            MessageBox.Show("Resultado Indefinido!");
                            MensagemErroTextBox();
                        }
                        else
                        {
                            resultado = num1 / num2;
                        }
                    }

                    numeros[indice] = resultado;
                    numeros.RemoveAt(indice + 1);
                    operadores.RemoveAt(0);
                }
            }

            return resultado;
        }

        // Método que limpa o TextBox e reinicia as variáveis
        private void Limpar_Tudo_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            ReiniciarVariáveis();
        }
        
        // Método que insere o número 4 no TextBox
        private void Numero_4_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "4");
        }

        // Método que insere o número 5 no TextBox
        private void Numero_5_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "5");
        }

        // Método que insere o número 6 no TextBox
        private void Numero_6_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "6");
        }

        // Método que insere o número 7 no TextBox
        private void Numero_7_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "7");
        }

        // Método que insere o número 8 no TextBox
        private void Numero_8_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "8");
        }

        // Método que insere o número 9 no TextBox
        private void Numero_9_Click(object sender, EventArgs e)
        {
            AtualizaTextBox(sender, e, "9");
        }
        
        // Método que insere o numero 0 no TextBox
        private void Numero_0_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            textBoxAlterado = true;
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string texto_Botao = "0";
            InserirTextBox(texto_Botao); 
        }

        // Método que insere a vírgula no TextBox
        private void Botao_Virgula_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string textoBotao = ","; // Captura o texto do botão

            if (!Exibir_Num.Text.Contains(","))
            {
                Exibir_Num.Text += textoBotao; // Adiciona a vírgula no TextBox
            }
            else if (!Exibir_Num.Text.Contains("."))
            {
                Exibir_Num.Text += textoBotao; // Adiciona o ponto decimal ao TextBox
            }
            textBoxAlterado = true;
        }

        // Método que deleta o último caractere do TextBox
        private void Botao_Deletar_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            char[] caracteres = Exibir_Num.Text.ToCharArray(); // Converte o texto do TextBox em um array de caracteres

            // Converte o vetor de caracteres para uma lista para facilitar a manipulação
            List<char> listaDeCaracteres = caracteres.ToList();

            // Verifica se a lista não está vazia antes de tentar remover o último caractere
            if (listaDeCaracteres.Count > 0)
            {
                // Remove o último caractere
                listaDeCaracteres.RemoveAt(listaDeCaracteres.Count - 1);

                // Converte de volta para um vetor de caracteres
                caracteres = listaDeCaracteres.ToArray();
            }

            // Converte o vetor de caracteres de volta para uma string
            string texto = new string(caracteres);

            if (string.IsNullOrEmpty(texto))
            {
                substituirZero = true;
                textBoxAlterado = false;
                texto = "0";
            }

            // Exibe o texto no TextBox
            Exibir_Num.Text = texto;
        }

        // Método que insere operador/sinal TextBox
        private void Botao_Subtrair_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            InserirTextBox("-");
        }

        // Método que insere o operador de multiplicação no TextBox
        private void Botao_Multiplicar_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                Exibir_Num.Text += "*";
            }
        }

        // Método que insere o operador de divisão no TextBox
        private void Botao_Dividir_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                Exibir_Num.Text += "/";
            }
        }

        // Método que insere o operador de raiz quadrada no TextBox
        private void Botao_Raiz_Click(object sender, EventArgs e)
        {
            Exibir_Num.Text = "√";
            substituirZero = false;
        }
    }
}
