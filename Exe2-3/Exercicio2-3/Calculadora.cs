using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2_3
{
    internal class Calculadora
    {
        private double valorA, valorB;

        #region Enum com as operações
        public enum Operacao
        {
            Somar = 1,
            Subtrair = 2,
            Multiplicar = 3,
            Dividir = 4,
            TodasOperacoes = 5
        }
        #endregion

        #region Método construtor da classe
        public Calculadora(double valorA, double valorB)
        {
            this.valorA = valorA;
            this.valorB = valorB;
        }
        #endregion

        #region Métodos para as operações básicas
        public double Somar() { return this.valorA + this.valorB; }
        public double Subtrair() { return this.valorA - this.valorB; }
        public double Multiplicar() { return this.valorA * this.valorB; }
        public double Dividir() { return this.valorA / this.valorB; }
        #endregion

        #region StringBuilder com todos os resultados
        public StringBuilder ExibirResultadoTodasOperacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n=====  RESULTADOS  =====\n");
            sb.Append("SOMA: " + this.Somar().ToString() + "\n");
            sb.Append("SUBTRAÇÃO: " + this.Subtrair().ToString() + "\n");
            sb.Append("MULTIPLICAÇÃO: " + this.Multiplicar().ToString() + "\n");
            sb.Append("DIVISÃO: " + this.Dividir().ToString() + "\n");
            return sb;
        }
        #endregion

    }
}
