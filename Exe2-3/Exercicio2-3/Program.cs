using System;
using System.Runtime.Intrinsics.X86;
using static Exercicio2_3.Calculadora;
using static System.Net.Mime.MediaTypeNames;

namespace Exercicio2_3
{
    /// <summary>
    /// 1. No projeto utilizado no exercício 2.2, crie um enumerador chamado Operacao
    /// contendo os valores Somar, Subtrair, Multiplicar e Dividir
    /// 2. Altere a Main da classe program para que o usuário selecione qual operação
    /// deseja realizar
    /// 3. Faça com que o programa realize e exiba somente o resultado da operação
    /// selecionada
    /// 4. Execute o programa e teste novamente.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int valorA, valorB;
            Calculadora Calc;
            Operacao op;

            #region Entrada dos valores
            Console.Write("Digite o 1º valor: ");
            valorA = int.Parse(Console.ReadLine());
            Console.Write("Digite o 2º valor: ");
            valorB = int.Parse(Console.ReadLine());
            #endregion

            Calc = new Calculadora(valorA, valorB);
            string teclado = MenuDecisao().ToString();
            op = (Operacao)Enum.Parse(typeof(Operacao), teclado, true);

            #region Decisão de qual operação realizar
            switch (op)
            {
                case Operacao.Somar:
                    Console.WriteLine("RESULTADO SOMA = " + Calc.Somar().ToString());
                    break;
                case Operacao.Subtrair:
                    Console.WriteLine("RESULTADO SUBTRAÇÃO = " + Calc.Subtrair().ToString());
                    break;
                case Operacao.Multiplicar:
                    Console.WriteLine("RESULTADO MULTIPLICAÇÃO = " + Calc.Multiplicar().ToString());
                    break;
                case Operacao.Dividir:
                    Console.WriteLine("RESULTADO DIVISÃO = " + Calc.Dividir().ToString());
                    break;
                case Operacao.TodasOperacoes:
                    Console.WriteLine(Calc.ExibirResultadoTodasOperacoes());
                    break;
                default:
                    Console.WriteLine("OPERAÇÂO INVÁLIDA!");
                    break;
            }
            #endregion

            #region Método que monta o MENU
            int MenuDecisao()
            {
                Console.WriteLine("\n===== MENU =====\n");
                Console.WriteLine("1 - SOMAR");
                Console.WriteLine("2 - SUBTRAIR");
                Console.WriteLine("3 - MULTIPLICAR");
                Console.WriteLine("4 - DIVIDIR");
                Console.WriteLine("5 - TODAS AS OPERAÇÕES\n");
                Console.Write("DIGITE A OPÇÃO: ");

                return int.Parse(Console.ReadLine());
            }
            #endregion
        }
    }
}