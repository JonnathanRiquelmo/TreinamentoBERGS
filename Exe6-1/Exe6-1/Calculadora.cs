using System.Text;
delegate double DelegateOperacao();

namespace Exercicio6_1
{
    internal class Calculadora
    {
        private static double valorA, valorB;
        private static StringBuilder log = new StringBuilder();

        public static double ValorA { get => valorA; set => valorA = value; }
        public static double ValorB { get => valorB; set => valorB = value; }

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
        public static double Somar()
        {
            AdicionarLog($"A SOMA de {ValorA} e/por {ValorB} é {ValorA + ValorB}.\n");
            return ValorA + ValorB;
        }

        public static double Subtrair()
        {
            AdicionarLog($"A SUBTRAÇÃO de {valorA} e/por {valorB} é {ValorA - ValorB}.\n");
            return ValorA - ValorB;
        }

        public static double Multiplicar()
        {
            AdicionarLog($"A MULTIPLICAÇÃO de {valorA} e/por {valorB} é {ValorA * ValorB}.\n");
            return ValorA * ValorB;
        }

        public static double Dividir()
        {
            AdicionarLog($"A DIVISÃO de {valorA} e/por {valorB} é {ValorA / ValorB}.\n");
            return ValorA / ValorB;
        }
        #endregion

        #region StringBuilder com todos os resultados
        public StringBuilder ExibirResultadoTodasOperacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n=====  RESULTADOS  =====\n");
            sb.Append($"SOMA: {Somar().ToString()} \n");
            sb.Append($"SUBTRAÇÃO: {Subtrair().ToString()} \n");
            sb.Append($"MULTIPLICAÇÃO: {Multiplicar().ToString()} \n");
            sb.Append($"DIVISÃO: {Dividir().ToString()} \n");
            return sb;
        }
        #endregion

        #region Montagem do StringBuilder do Log
        public static void AdicionarLog(string texto)
        {
            log.AppendFormat(texto + "\n");
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
