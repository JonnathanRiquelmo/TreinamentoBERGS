using static Exercicio2_4.Calculadora;

namespace Exercicio2_4
{
    /// <summary>
    /// 1. No projeto utilizado no exercício 2.3, altere o enumerador chamado Operacao,
    /// adicionando o valor Exibir Log
    /// 2. Altere a construtora da classe para não receber parâmetros.
    /// 3. Crie as propriedades ValorA e ValorB com get e set.
    /// 4. Faça com que o programa, ao terminar a execução de cada operação, pergunte
    /// se o usuário deseja continuar na aplicação ou sair.
    /// 5. Na classe Calculadora, crie uma propriedade somente de leitura do tipo Arraylist
    /// chamada Log.
    /// 6. Faça com que, a cada operação realizada, seja adicionada na propriedade Log
    /// uma string no seguinte formato:
    /// A<operação> de <valorA> e/por<valorB> é <resultado>.
    /// 7. Faça com que, quando o usuário selecionar a opção Exibir Log, sejam exibidas
    /// todas as entradas do ArrayList Log ou a mensagem “Nenhuma operação
    /// realizada.”.
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