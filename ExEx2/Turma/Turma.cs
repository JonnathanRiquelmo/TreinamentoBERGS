using Bergs.ProvacSharp.BD;
using System.Text;

namespace BDTurma
{
    public class Aluno
    {
        private short codigo;
        private string nome;
        private DateTime nascimento;
        public Aluno() { }

        public short Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime Nascimento { get => nascimento; set => nascimento = value; }
    }

    public class Turma
    {
        private List<Aluno> _alunos;

        private string caminho;

        public enum Operacao
        {
            listarTodos = 1,
            incluir = 2,
            excluir = 3,
            importar = 4,
            exportar = 5,
            salvarBD = 6,
            sair = 0
        }

        public Turma(string caminho)
        {
            this.List = new List<Aluno>();
            this.caminho = caminho;

            Console.WriteLine($"\nCAMINHO: {caminho} \n");
            using (AcessoBancoDados bancoDados = new AcessoBancoDados(caminho))
            {
                bancoDados.Abrir();
                List<Linha> retorno = bancoDados.Consultar("SELECT CODIGO, NOME, NASCIMENTO FROM TURMA");
                if (retorno.Count() != 0)
                {
                    this._alunos.Clear();

                    foreach (Linha linha in retorno)
                    {
                        Aluno al = new Aluno();
                        //campo código é a posição 0
                        al.Codigo = short.Parse(linha.Campos[0].Conteudo.ToString());
                        al.Nome = linha.Campos[1].Conteudo.ToString();
                        al.Nascimento = DateTime.Parse(linha.Campos[2].Conteudo.ToString());
                        //adição na minha lista
                        this._alunos.Add(al);
                    }

                    Console.WriteLine("\n\nIMPORTAÇÃO DO BANCO DE DADOS REALIZADA COM SUCESSO!");
                    Console.ReadKey();
                }
            }
        }

        public List<Aluno> List { get => _alunos; set => _alunos = value; }

        #region Método de inclusao de um aluno na lista
        public bool Incluir(Aluno aluno)
        {
            if (aluno.Nascimento.Date.AddYears(18) > System.DateTime.Now.Date)
            {
                return false;
            }

            foreach (var al in List)
            {
                if (al.Codigo.Equals(aluno.Codigo))
                {
                    return false;
                }
            }
            this.List.Add(aluno);
            return true;
        }
        #endregion

        #region Método de exclusão de um aluno na lista
        public Aluno Excluir(short codigo)
        {
            foreach (Aluno al in List)
            {
                if (al.Codigo.Equals(codigo))
                {
                    this.List.Remove(al);
                    return al;
                }
            }
            return null;
        }
        #endregion

        #region Método que lista todos os alunos da lista
        public String Listar()
        {
            string result = "";

            if (this.List.Count == 0)
            {
                return "\n\nNÃO HÁ ELEMENTOS (ALUNOS) NA LISTA (TURMA)!\n";
            }

            foreach (Aluno al in List)
            {
                result += $"{al.Codigo:00000} – {al.Nascimento.Date:dd/MM/yyyy} - {al.Nome}\n";
            }

            return result;
        }
        #endregion

        #region Método que importa a lista de alunos em arquivo de texto
        public int Importar(string caminho)
        {
            string[] linhas;

            try
            {
                linhas = File.ReadAllLines(caminho);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nO ARQUIVO NÃO EXISTE!");
                return 0;
            }


            this.List.Clear();
            // Processar cada linha e adicionar as informações na lista
            foreach (string linha in linhas)
            {
                // Dividir a linha em três informações separadas pelo traço
                string[] info = linha.Split('-');

                // Criar um objeto Aluno com as informações e adicionar na lista
                Aluno al = new Aluno { Codigo = short.Parse(info[0]), Nome = info[2], Nascimento = DateTime.Parse(info[1]) };
                _alunos.Add(al);
            }


            return linhas.Length;
        }
        #endregion

        #region Método que exporta a lista de alunos em arquivo de texto
        public bool Exportar(string caminho)
        {
            try
            {
                using (StreamWriter arquivo = new StreamWriter(caminho))
                {
                    // Percorrendo a lista e escrevendo os objetos no arquivo
                    foreach (Aluno al in _alunos)
                    {
                        arquivo.WriteLine($"{al.Codigo:000000}-{al.Nascimento:dd/MM/yyyy}-{al.Nome}");
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Método que apaga os registros do banco e carrega (insere) toda a lista e alunos 
        public bool Salvar()
        {
            using (AcessoBancoDados bancoDados = new AcessoBancoDados(this.caminho))
            {
                bancoDados.Abrir();

                bancoDados.ExecutarDelete("DELETE FROM TURMA");

                foreach (Aluno al in this._alunos)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO TURMA (CODIGO, NOME, NASCIMENTO) VALUES (");
                    sql.Append(al.Codigo);
                    sql.AppendFormat(", '{0}', '{1}')", al.Nome, al.Nascimento.ToString("MM/dd/yyyy"));
                    if (!bancoDados.ExecutarInsert(sql.ToString()))
                    {
                        return false;
                    }
                }
                bancoDados.EfetivarComandos();
            }
            return true;
        }
        #endregion
    }
}
