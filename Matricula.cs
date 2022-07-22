using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoEscola
{
    public class Matricula
    {
        public int IdMatri { get; set; }
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public string Situacao { get; set; }
        public double ValorCursoMatri { get; set; }
        public DateTime DataMatri { get; set; }
        public Usuario Usuario { get; set; }

        public Matricula()
        {
            Aluno = new Aluno();
            Usuario = new Usuario();
            Curso = new Curso();
        }
        public Matricula(int idMatri, Aluno aluno, Curso curso, string situacao, double valorCursoMatri, DateTime dataMatri, Usuario usuario)
        {
            IdMatri = idMatri;
            Aluno = aluno;
            Curso = curso;
            Situacao = situacao;
            ValorCursoMatri = valorCursoMatri;
            DataMatri = dataMatri;
            Usuario = usuario;
        }
        public Matricula(Aluno aluno, Curso curso, Usuario usuario)
        {
            Aluno = aluno;
            Curso = curso;
            Usuario = usuario;
        }
        public void InserirMatri(Aluno aluno, Curso curso, Usuario usuario)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_matricula values (null, @alunoId,@cursoId,'A',@valorCurso,now(),@usuarioId);";
            cmd.Parameters.Add("@alunoId",MySqlDbType.Int32).Value = aluno.Id;
            cmd.Parameters.Add("@cursoId",MySqlDbType.Int32).Value = curso.Id;
            cmd.Parameters.Add("@valorCurso",MySqlDbType.Decimal).Value = curso.ValorCurso; 
            cmd.Parameters.Add("@usuarioId",MySqlDbType.Int32).Value = usuario.IdUser;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@identity";
            IdMatri = Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
