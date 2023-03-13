using ClientesEmpresa;

namespace ConsoleEmpresa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            Clientes clientes = new Clientes();

            do
            {
                Console.WriteLine("==== MENU ====\n");
                Console.WriteLine("1 - LISTAR TODOS");
                Console.WriteLine("2 - INCLUIR");
                Console.WriteLine("3 - EXCLUIR");
                Console.WriteLine("4 - SAIR\n");
                Console.Write("OPÇÃO:");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                       ListarClientes(clientes);
                        break;
                    case "2":
                        IncluirCliente(clientes);
                        break;
                    case "3":
                        ExcluirCliente(clientes);
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine();
            } while (!sair);
        }

        static void ListarClientes(Clientes clientes)
        {
            Console.WriteLine("Clientes cadastrados:");

            foreach (Cliente cliente in clientes.Listar())
            {
                if (cliente.TipoPessoa == TipoPessoa.Fisica)
                {
                    Console.WriteLine($"{FormatarCPF(cliente.CpfCnpj)} - {cliente.Data.ToString("dd/MM/yyyy")} - {cliente.Nome} - R$ {cliente.Renda.ToString()}");
                }
                else
                {
                    Console.WriteLine($"{FormatarCNPJ(cliente.CpfCnpj)} - {cliente.Data.ToString("dd/MM/yyyy")} - {cliente.Nome}");
                }
            }
        }

        static void IncluirCliente(Clientes clientes)
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Informe o CPF ou CNPJ:");
            cliente.CpfCnpj = Console.ReadLine();

            Console.WriteLine("Informe o tipo de pessoa (F - Física / J - Jurídica):");
            cliente.TipoPessoa = (TipoPessoa)Enum.Parse(typeof(TipoPessoa), Console.ReadLine());

            Console.WriteLine("Informe o nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento ou constituição (dd/mm/aaaa):");
            cliente.Data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            if (cliente.TipoPessoa == TipoPessoa.Fisica)
            {
                Console.WriteLine("Informe a renda:");
                cliente.Renda = Decimal.Parse(Console.ReadLine());
            }

            if (clientes.Incluir(cliente))
            {
                Console.WriteLine("Cliente incluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Não foi possível incluir o cliente.");
            }
        }

        static void ExcluirCliente(Clientes clientes)
        {
            Console.WriteLine("Informe o CPF ou CNPJ:");
            string cpfCnpj = Console.ReadLine();

            Console.WriteLine("Informe o tipo de pessoa (F - Física / J - Jurídica):");
            TipoPessoa tipoPessoa = (TipoPessoa)Enum.Parse(typeof(TipoPessoa), Console.ReadLine());

            if (clientes.Excluir(cpfCnpj, tipoPessoa))
            {
                Console.WriteLine("Cliente excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Não foi possível excluir o cliente.");
            }
        }

        static string FormatarCPF(string cpf)
        {
            return String.Format(@"{0:\000\.000\.000\-00}", cpf);
        }

        public static string FormatarCNPJ(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            if (cnpj.Length != 14)
            {
                throw new ArgumentException("CNPJ inválido.");
            }

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
        }

    }
}
