using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2_2
{
    internal class Calculadora
    {
        private double valorA, valorB;

        public Calculadora(double valorA, double valorB)
        {
            this.valorA = valorA;
            this.valorB = valorB;
        }

        public double Somar()
        {
            return this.valorA + this.valorB;
        }

        public double Subtrair()
        {
            return this.valorA - this.valorB;
        }

        public double Multiplicar()
        {
            return this.valorA * this.valorB;
        }

        public double Dividir()
        {
            return this.valorA / this.valorB;
        }

        public StringBuilder ExibirResultadoOperacoes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SOMA: " + this.Somar().ToString() + "\n");
            sb.Append("SUBTRAÇÃO: " + this.Subtrair().ToString() + "\n");
            sb.Append("MULTIPLICAÇÃO: " + this.Multiplicar().ToString() + "\n");
            sb.Append("DIVISÃO: " + this.Dividir().ToString() + "\n");
            return sb;
        }

    }
}
