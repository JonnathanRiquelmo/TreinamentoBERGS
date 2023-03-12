namespace BDTurma
{
    public class Aluno
    {
        private short codigo;
        private string nome;
        private DateTime nascimento;

        public short Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime Nascimento { get => nascimento; set => nascimento = value; }

        public Aluno() { }
    }

    public class Turma
    {
        private List<Aluno> _list;

        public List<Aluno> List { get => _list; set => _list = value; }

        public enum Operacao
        {
            listarTodos = 1,
            incluir = 2,
            excluir = 3,
            sair = 4
        }

        public Turma()
        {
            this.List = new List<Aluno>();
        }

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
    }

}
