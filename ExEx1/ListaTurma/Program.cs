using BDTurma;
using static BDTurma.Turma;

namespace ProgramaPrincipal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Turma turma = new Turma();
            Aluno aluno;
            bool sair = false;
            string teclado;
            Operacao op;

            do
            {
                try
                {
                    teclado = MenuDecisao().ToString();

                    Console.Clear();

                    op = (Operacao)Enum.Parse(typeof(Operacao), teclado, true);

                    switch (op)
                    {
                        case Operacao.listarTodos:
                            Console.WriteLine(turma.Listar());
                            reset();
                            break;
                        case Operacao.incluir:
                            aluno = new Aluno();
                            EntradaValores();
                            turma.Incluir(aluno);
                            reset();
                            break;
                        case Operacao.excluir:
                            Console.Write("\nDigite o CÓDIGO do aluno para EXCLUSÃO: ");
                            if (turma.Excluir(short.Parse(Console.ReadLine())) != null)
                            {
                                Console.WriteLine("\nALUNO EXCLUÍDO COM SUCESSO!");
                            }
                            else
                            {
                                Console.WriteLine("\n\nCÓDIGO INEXISTENTE!");
                            }
                            reset();
                            break;
                        case Operacao.sair:
                            sair = true;
                            Console.WriteLine("FIM!");
                            reset();
                            break;
                        default:
                            Console.WriteLine("\n\nOPERAÇÂO INVÁLIDA!");
                            reset();
                            break;
                    }
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

            } while (!sair);

            #region Entrada dos valores
            void EntradaValores()
            {

                Console.Write("\nDigite o CÓDIGO do aluno: ");
                aluno.Codigo = short.Parse(Console.ReadLine());
                Console.Write("\nDigite o NOME do aluno: ");
                aluno.Nome = Console.ReadLine();
                Console.Write("\nDigite DATA DE NASCIMENTO do aluno: ");
                aluno.Nascimento = DateTime.Parse(Console.ReadLine());
            }
            #endregion

            #region Método que monta o MENU
            int MenuDecisao()
            {
                Console.WriteLine("===== MENU =====\n");
                Console.WriteLine("1 - LISTAR TODOS");
                Console.WriteLine("2 - INCLUIR");
                Console.WriteLine("3 - EXCLUIR");
                Console.WriteLine("4 - SAIR\n");
                Console.Write("SUA OPÇÃO: ");
                return int.Parse(Console.ReadLine());
            }
            #endregion
            void reset()
            {
                Console.Write("\nDigite algo para continuar... ");
                Console.ReadKey();
                Console.Clear();
            }

        }

    }
}