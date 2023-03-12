using System.Collections;
using System.Text;
using static Exercicio2_5.Calculadora;
using static System.Net.Mime.MediaTypeNames;

namespace Exercicio2_5
{
    /// <summary>
    /// 1. No projeto utilizado no exercício 2.4, altere os métodos de operação para que ao
    /// realizar uma operação, troque o ArrayList para StringBuilder no Log
    /// 2. Utilize a função String.Format() ao adicionar no StringBuilder do Log
    /// 3. Execute o programa e teste novamente.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int valorA, valorB;
            Calculadora Calc = new Calculadora();
            Operacao op;
            bool sair = false;

            do
            {
                string teclado = MenuDecisao().ToString();

                Console.Clear();

                op = (Operacao)Enum.Parse(typeof(Operacao), teclado, true);

                #region Decisão de qual operação realizar
                switch (op)
                {
                    case Operacao.Somar:
                        EntradaValores();
                        Console.WriteLine("\nRESULTADO SOMA = " + Calc.Somar().ToString());
                        break;
                    case Operacao.Subtrair:
                        EntradaValores();
                        Console.WriteLine("\nRESULTADO SUBTRAÇÃO = " + Calc.Subtrair().ToString());
                        break;
                    case Operacao.Multiplicar:
                        EntradaValores();
                        Console.WriteLine("\nRESULTADO MULTIPLICAÇÃO = " + Calc.Multiplicar().ToString());
                        break;
                    case Operacao.Dividir:
                        EntradaValores();
                        Console.WriteLine("\nRESULTADO DIVISÃO = " + Calc.Dividir().ToString());
                        break;
                    case Operacao.TodasOperacoes:
                        EntradaValores();
                        Console.WriteLine(Calc.ExibirResultadoTodasOperacoes());
                        break;
                    case Operacao.ExibirLog:
                        Calc.ExibirLog();
                        break;
                    case 0:
                        Console.WriteLine("FIM!");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("OPERAÇÂO INVÁLIDA!");
                        break;
                }
                #endregion

            } while (!sair);

            #region Entrada dos valores
            void EntradaValores()
            {
                Console.Write("Digite o 1º valor: ");
                valorA = int.Parse(Console.ReadLine());
                Calc.ValorA = valorA;

                Console.Write("Digite o 2º valor: ");
                valorB = int.Parse(Console.ReadLine());
                Calc.ValorB = valorB;
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
                Console.WriteLine("5 - TODAS AS OPERAÇÕES BÁSICAS");
                Console.WriteLine("6 - EXIBIR LOG");
                Console.WriteLine("0 - SAIR\n");
                Console.Write("DIGITE A OPÇÃO: ");

                int op;
                int.TryParse(Console.ReadLine(), out op);
                return op;
            }
            #endregion
        }
    }
}