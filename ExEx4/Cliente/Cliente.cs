using Bergs.ProvacSharp.BD;
using System.Text;

namespace ClientesEmpresa
{
    public enum TipoPessoa { Fisica = 'F', Juridica = 'J' }

    public class Cliente
    {
        public string CpfCnpj { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal? Renda { get; set; }
    }

    public class Clientes
    {
        private List<Cliente> _clientes;

        public Clientes()
        {
            this._clientes = new List<Cliente>();

            try
            {
                using (var bd = new AcessoBancoDados("C:\\soft\\pxc\\data\\exercicioextra2.mdb"))
                {
                    bd.Abrir();
                    List<Linha> conteudo = bd.Consultar("SELECT CPFCNPJ, TIPOPESSOA, NOME, DATA, RENDA FROM CLIENTE");

                    foreach (Linha linha in conteudo)
                    {
                        Cliente cliente = new Cliente();
                        cliente.CpfCnpj = linha.Campos[0].Conteudo.ToString();
                        cliente.TipoPessoa = (TipoPessoa)char.Parse(linha.Campos[1].Conteudo.ToString());
                        cliente.Nome = linha.Campos[2].Conteudo.ToString();
                        cliente.Data = DateTime.Parse(linha.Campos[3].Conteudo.ToString());

                        if (cliente.TipoPessoa == TipoPessoa.Fisica)
                        {
                            cliente.Renda = Decimal.Parse(linha.Campos[4].Conteudo.ToString());
                        }

                        _clientes.Add(cliente);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public bool Incluir(Cliente cliente)
        {
            // Verifica se o cliente já existe na lista
            if (_clientes.Any(c => c.CpfCnpj == cliente.CpfCnpj && c.TipoPessoa == cliente.TipoPessoa))
            {
                return false;
            }

            // Verifica se é pessoa física com menos de 18 anos
            if (cliente.TipoPessoa == TipoPessoa.Fisica && DateTime.Today.AddYears(-18) < cliente.Data)
            {
                return false;
            }

            // Verifica se é pessoa jurídica com menos de 2 anos de constituição
            if (cliente.TipoPessoa == TipoPessoa.Juridica && DateTime.Today.AddYears(-2) < cliente.Data)
            {
                return false;
            }

            // Verifica se é pessoa física com renda menor ou igual a zero
            if (cliente.TipoPessoa == TipoPessoa.Fisica && (cliente.Renda == null || cliente.Renda <= 0))
            {
                return false;
            }

            // Se for pessoa jurídica, salva NULL no campo Renda
            if (cliente.TipoPessoa == TipoPessoa.Juridica)
            {
                cliente.Renda = null;
            }

            try
            {
                using (var bd = new AcessoBancoDados("C:\\soft\\pxc\\data\\exercicioextra2.mdb"))
                {
                    bd.Abrir();
                    StringBuilder sb = new StringBuilder();

                    if (cliente.TipoPessoa == TipoPessoa.Fisica)
                    {
                        sb.Append("INSERT INTO CLIENTE (CPFCNPJ, TIPOPESSOA, NOME, DATA, RENDA) VALUES(");

                    }
                    else
                    {
                        sb.Append("INSERT INTO CLIENTE (CPFCNPJ, TIPOPESSOA, NOME, DATA) VALUES(");
                    }

                    sb.Append("'" + cliente.CpfCnpj + "',");
                    sb.Append("'" + cliente.TipoPessoa.ToString().Substring(0, 1) + "', ");
                    sb.Append("'" + cliente.Nome + "', ");
                    sb.Append("'" + cliente.Data.ToString() + "'");

                    if (cliente.TipoPessoa == TipoPessoa.Fisica)
                    {
                        sb.Append("," + cliente.Renda);
                    }

                    sb.Append(")");
                    bd.ExecutarInsert(sb.ToString());
                    bd.EfetivarComandos();
                }

                // Adiciona o cliente na lista
                _clientes.Add(cliente);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }

        public bool Excluir(string cpfCnpj, TipoPessoa tipoPessoa)
        {
            try
            {
                // Procura o cliente na lista e remove se encontrado
                var cliente = _clientes.Single(c => c.CpfCnpj == cpfCnpj && c.TipoPessoa == tipoPessoa);

                try
                {
                    using (var bd = new AcessoBancoDados("C:\\soft\\pxc\\data\\exercicioextra2.mdb"))
                    {
                        if (cliente != null)
                        {
                            bd.Abrir();
                            StringBuilder sb = new StringBuilder();
                            sb.Append($"DELETE FROM CLIENTE WHERE CPFCNPJ = '{cliente.CpfCnpj}'");
                            bd.ExecutarDelete(sb.ToString());
                            bd.EfetivarComandos();
                            _clientes.Remove(cliente);

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Cliente a ser excluído não consta na base");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha na exclusão do cliente");
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<Cliente> Listar()
        {
            // Retorna a lista de clientes
            return _clientes;
        }
    }
}
