using System.Collections;
using System.Reflection;
using System.Text;

namespace Exercicio2_4
{
    internal class Calculadora
    {
        private double valorA, valorB;
        private ArrayList log = new ArrayList();

        public double ValorA { get => valorA; set => valorA = value; }
        public double ValorB { get => valorB; set => valorB = value; }
        public ArrayList Log { get => log; set => log = value; }

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
            string log = $"A SOMA de {valorA} e/por {valorB} é {ValorA + ValorB}.\n";
            this.AdicionarLog(log);
            return this.ValorA + this.ValorB;
        }

        public double Subtrair()
        {
            string log = $"A SUBTRAÇÃO de {valorA} e/por {valorB} é {ValorA - ValorB}.\n";
            this.AdicionarLog(log);
            return this.ValorA - this.ValorB;
        }

        public double Multiplicar()
        {
            string log = $"A MULTIPLICAÇÃO de {valorA} e/por {valorB} é {ValorA * ValorB}.\n";
            this.AdicionarLog(log);
            return this.ValorA * this.ValorB;
        }

        public double Dividir()
        {
            string log = $"A DIVISÃO de {valorA} e/por {valorB} é {ValorA / ValorB}.\n";
            this.AdicionarLog(log);
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

        public void AdicionarLog(string texto)
        {
            this.log.Add(texto);
        }

        public void ExibirLog()
        {
            if (log.Count == 0)
            {
                Console.WriteLine("\nNENHUMA OPERAÇÃO REALIZADA.");
            }
            else
            {
                foreach (var item in log)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
