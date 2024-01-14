using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool textBoxAlterado = false;

        // Método construtor
        public Form1()
        {
            InitializeComponent();

        }

        // Método que verifica se o botão clicado é um número
        private bool VerificaClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            if(botao == Numero_0 && botao == Numero_1 && 
               botao == Numero_2 && botao == Numero_4 && 
               botao == Numero_5 && botao == Numero_6 &&
               botao == Numero_7 && botao == Numero_8 &&
               botao == Numero_8 && botao == Numero_9)
            {
                return true;
            }
            else
            {
                return false;
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

        // Verifica se alguma operação foi selecionada
        private bool VerificaOperacao()
        {
            return string.IsNullOrEmpty(operador); // Retorna true se a operação não foi selecionada
        }

        // Método que insere o número digitado no TextBox
        private void InserirTextBox(string texto)
        {
            Exibir_Num.Text += texto;
            textBoxAlterado = true;
        }

        private void AlterarOperacao(object sender, EventArgs e, string operando)
        {
            num1 = RetornaValorTextBox();
            LimparTextBox();
            operador = operando;
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
            num1 = 0; 
            num2 = 0; 
            operador = ""; 
            resultado = 0; 
            substituirZero = true; 
            LimparTextBox(); 
            Exibir_Num.Text = resultado.ToString("0");
            textBoxAlterado = false;

        }

        // Método que retorna o valor do TextBox convertido para double
        private double RetornaValorTextBox()
        {
            double valor = 0;
            if(textBoxAlterado == true )
            {
                double.TryParse(Exibir_Num.Text, out valor);
                return valor;
            }
            else
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
                return 0;
            }
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

        // Método que atualiza a variável com a operação de soma
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
                AlterarOperacao(sender, e, "+");
            }
        }

        // Método que verifica se número máximo de caracteres foi excedido
        private void Exibir_Num_TextChanged(object sender, EventArgs e)
        {
            const int maximo_Caracteres = 10; // Define o número máximo de caracteres
        
            if (Exibir_Num.Text.Length > maximo_Caracteres)
            {
                // Se o número de caracteres exceder o máximo, remova o último caractere
                Exibir_Num.Text = Exibir_Num.Text.Substring(0, maximo_Caracteres);
            }
        }

        // Método que realiza as operações
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
                if (operador == "√")
                {
                    num2 = 0;
                }
                else
                {
                    num2 = RetornaValorTextBox();
                }
                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            //MessageBox.Show("Não é possível dividir por zero.");
                            MensagemErroTextBox();
                        }
                        else
                        {
                            resultado = num1 / num2;
                        }
                        break;
                    case "√":
                        resultado = Math.Sqrt(num1);
                        break;
                    default:
                        resultado = RetornaValorTextBox(); // Retorna o valor do TextBox
                        break;
                }

                Exibir_Num.Text = resultado.ToString();
                //substituirZero = true;
            }
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

        private void Botao_Virgula_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender; // Captura o botão que foi clicado
            string textoBotao = ","; // Captura o texto do botão

            if (VerificaOperacao())
            {
                if (!Exibir_Num.Text.Contains(","))
                {
                    Exibir_Num.Text += textoBotao; // Adiciona a vírgula no TextBox
                }
            }
            else
            {
                
                if (!Exibir_Num.Text.Contains("."))
                {
                    Exibir_Num.Text += textoBotao; // Adiciona o ponto decimal ao TextBox
                }
            }
            textBoxAlterado = true;
        }

        private void Botao_Deletar_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            double valor = RetornaValorTextBox();
            int valor2 = (int)(valor / 10); // Converte o valor double para int
            string texto = valor2.ToString();

            if (!Exibir_Num.Text.Contains(","))
            {
                if (valor != valor2)
                {
                    Exibir_Num.Text = texto;
                }
                if (texto == "0")
                {
                    substituirZero = true;
                }
            }
            else
            {
                valor2 = (int)(valor % 10);  // Converte o resto da divisão para int
                string texto2 = valor2.ToString(); // Converte o valor int para string
                
                if (Exibir_Num.Text.Contains(texto2)) // Verifica se o texto contém o valor ou caracter
                {
                    Exibir_Num.Text = Exibir_Num.Text.Remove(Exibir_Num.Text.Length - 1); // Remove o último caracter e diminui o tamanho da string
                }

                if (texto2 == "0")
                {
                    substituirZero = true;
                    textBoxAlterado = false;
                }
            }
        }

        private void Botao_Subtrair_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                AlterarOperacao(sender, e, "-");
            }
        }

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
                AlterarOperacao(sender, e, "*");
            }
        }

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
                AlterarOperacao(sender, e, "/");
            }
        }

        private void Botao_Raiz_Click(object sender, EventArgs e)
        {
            DesativarFoco();
            if (textBoxAlterado == false)
            {
                //MessageBox.Show("Por favor, insira um número válido.");
                MensagemErroTextBox();
            }
            else
            {
                AlterarOperacao(sender, e, "√");
            }
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
            // Carregar a fonte no formulário
            //string caminhoFonte = Path.Combine(Application.StartupPath, "Fontes", "pixelart.ttf");
            //FontFamily fonte = new FontFamily(caminhoFonte);

            // Aplicar a fonte ao TextBox (substitua textBox1 pelo nome do seu TextBox)
            //Exibir_Num.Font = new Font(fonte, 36, FontStyle.Regular);
        //}
    }
}
