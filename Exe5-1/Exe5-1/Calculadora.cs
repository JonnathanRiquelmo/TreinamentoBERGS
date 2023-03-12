using System.Collections;
using System.Text;

namespace Exercicio5_1
{
    internal class Calculadora
    {
        private double valorA, valorB;
        private StringBuilder log = new StringBuilder();

        public double ValorA { get => valorA; set => valorA = value; }
        public double ValorB { get => valorB; set => valorB = value; }

        #region Enum com as operações
        public enum Operacao
        {
            Somar = 1,
            Subtrair = 2,
            Multiplicar = 3,
            Dividir = 4,
            TodasOperacoes = 5,
            ExibirLog = 6
        }
        #endregion

        #region Método construtor da classe
        public Calculadora() { }
        #endregion

        #region Métodos para as operações básicas
        public double Somar()
        {
            this.AdicionarLog($"A SOMA de {valorA} e/por {valorB} é {ValorA + ValorB}.\n");
            return this.ValorA + this.ValorB;
        }

        public double Subtrair()
        {
            this.AdicionarLog($"A SUBTRAÇÃO de {valorA} e/por {valorB} é {ValorA - ValorB}.\n");
            return this.ValorA - this.ValorB;
        }

        public double Multiplicar()
        {
            this.AdicionarLog($"A MULTIPLICAÇÃO de {valorA} e/por {valorB} é {ValorA * ValorB}.\n");
            return this.ValorA * this.ValorB;
        }

        public double Dividir()
        {
            this.AdicionarLog($"A DIVISÃO de {valorA} e/por {valorB} é {ValorA / ValorB}.\n");
            return this.ValorA / this.ValorB;
        }
        #endregion

        #region StringBuilder com todos os resultados
        public StringBuilder ExibirResultadoTodasOperacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n=====  RESULTADOS  =====\n");
            sb.Append($"SOMA: {this.Somar().ToString()} \n");
            sb.Append($"SUBTRAÇÃO: {this.Subtrair().ToString()} \n");
            sb.Append($"MULTIPLICAÇÃO: {this.Multiplicar().ToString()} \n");
            sb.Append($"DIVISÃO: {this.Dividir().ToString()} \n");
            return sb;
        }
        #endregion

        #region Montagem do StringBuilder do Log
        public void AdicionarLog(string texto)
        {
            this.log.AppendFormat(texto + "\n");
        }
        #endregion

        #region Leitura e exibição do Log
        public void ExibirLog()
        {
            if (log.Length == 0)
            {
                Console.WriteLine("\nNENHUMA OPERAÇÃO REALIZADA.");
            }
            else
            {
                Console.WriteLine(log.ToString());
            }
        }
        #endregion
    }
}
