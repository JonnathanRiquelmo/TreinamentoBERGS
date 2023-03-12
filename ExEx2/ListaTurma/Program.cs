using BDTurma;
using static BDTurma.Turma;

namespace ProgramaPrincipal
{
    /// <summary>
    /// 1. Modifique o exercício anterior incluindo as opções:
    /// - “Importar arquivo”: deve solicitar o nome do arquivo, chamar o método “Importar” da
    /// classe “Turma” e apresentar a quantidade de registros incluídos;
    /// - “Exportar arquivo”: deve solicitar o nome do arquivo, chamar o método “Exportar” da classe
    /// “Turma” e informar se conseguiu salvar ou não o arquivo;
    /// 2. O formato do arquivo será posicional:
    /// - 5 dígitos para o código(com zeros à esquerda)
    /// - 10 espaços para a data no formato dd/MM/yyyy
    /// - o restante da linha será o nome do aluno
    /// 3. Na classe “Turma” crie os métodos:
    /// - “Int32 Importar(String arquivo)”, que deve abrir o arquivo e popular o List<Aluno>, deve
    /// retornar a quantidade de linhas efetivamente incluídas no List<Aluno>
    /// - “bool Exportar(String arquivo)”, que deve salvar o arquivo texto; em caso de exceção, deve
    /// retornar false
    /// 4. No ConsoleApplication, utilize a diretiva “using” para abrir o arquivo
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Turma turma = new Turma(@"C:\Soft\pxc\data\exercicioextra.mdb");
            reset();
            
            Aluno aluno;
            bool sair = false;
            string teclado;
            Operacao op;

            #region Laço de repetição do menu de opcões e seus métodos
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
                        case Operacao.importar:
                            int linhas = turma.Importar(@"C:\Soft\pxc\data\LISTA_ALUNOS.txt");
                            if (linhas != 0)
                            {
                                Console.WriteLine($"\nDADOS IMPORTADOS COM SUCESSO!\n\nLINHAS LIDAS: {linhas}");
                            }
                            reset();
                            break;
                        case Operacao.exportar:

                            if (turma.Exportar(@"C:\Soft\pxc\data\LISTA_ALUNOS.txt"))
                            {
                                Console.WriteLine("\nDADOS EXPORTADOS COM SUCESSO!");
                            }
                            else
                            {
                                Console.WriteLine("\nNÃO FOI POSSÍVEL EXPORTAR OS DADOS!");
                            }
                            reset();
                            break;
                        case Operacao.salvarBD:
                            if (turma.Salvar())
                            {
                                Console.WriteLine("\nSALVO NO BANCO DE DADOS COM SUCESSO!");
                            }
                            else
                            {
                                Console.WriteLine("\n\nERRO AO SALVAR NO BANCO DE DADOS!");
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
            #endregion

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
                Console.WriteLine("4 - IMPORTAR ARQUIVO");
                Console.WriteLine("5 - EXPORTAR ARQUIVO");
                Console.WriteLine("6 - SALVAR EM BANCO DE DADOS");
                Console.WriteLine("0 - SAIR\n");
                Console.Write("SUA OPÇÃO: ");
                return int.Parse(Console.ReadLine());
            }
            #endregion

            #region Reset da tela chamado a cada operação
            void reset()
            {
                Console.Write("\nDigite algo para continuar... ");
                Console.ReadKey();
                Console.Clear();
            }
            #endregion

        }
    }
}