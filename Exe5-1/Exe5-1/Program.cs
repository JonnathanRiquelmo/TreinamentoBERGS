using static Exercicio5_1.Calculadora;

namespace Exercicio5_1
{
    /// <summary>
    /// 1. No projeto utilizado no exercício 4.1, crie um tratamento de exceções na classe
    /// Program, exibindo a cada erro a mensagem trazida pela exceção na tela.
    /// 2. Faça com que a aplicação trate alguma exceção que poderá ser lançada ao tentar
    /// pegar algum elemento que não exista no ArrayList Log
    /// 3. Faça com que a aplicação trate alguma exceção que poderá ser lançada ao tentar
    /// converter tipos de dados incompatíveis
    /// 4. Altere o programa, utilizando o bloco finally para exibir a mensagem
    /// perguntando se o usuário deseja continuar ou sair da aplicação.
    /// 5. Execute o programa e teste novamente. 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int valorA, valorB;
            Calculadora Calc = new Calculadora();
            Operacao op;
            bool sair = false;
            string teclado;

            #region Estrutura de repetição do menu com tratamento de erros
            do
            {
                try
                {
                    teclado = MenuDecisao().ToString();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("OCORREU UMA EXCEÇÃO!\n");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("\nDESEJA CONTINUAR NO SISTEMA? \n\n   [SIM = qualquer outra tecla]\n\n   [NÃO = n/N]\n");
                    Console.Write("OPÇÃO: ");
                    string escolha = Console.ReadLine();
                    if (escolha.Equals("n") || escolha.Equals("N"))
                    {
                        sair = true;
                        Console.Clear();
                        Console.WriteLine("FIM!");
                        continue;
                    }
                    else
                    {
                        sair = false;
                        Console.Clear();
                        continue;
                    }
                }

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
            #endregion

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

                return int.Parse(Console.ReadLine());
            }
            #endregion

            Console.ReadKey();
        }
    }
}