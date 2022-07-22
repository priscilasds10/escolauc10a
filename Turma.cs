using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoEscola
{
    public class Turma
    {
         public int IdTurma { get; set; }
        public Curso Curso { get; set; }

        public string Sigla_turma{ get;set; }

        public DateTime Data_inicio { get; set; }

        public DateTime Data_termino { get; set; }

        public TimeSpan Hora { get;set; }

        public Decimal Duracao {get; set; }

        public string Dia_semana { get; set; }

        public string Situacao { get; set; }
        public Turma(int idTurma, Curso curso, string sigla_turma, DateTime data_inicio, DateTime data_termino, TimeSpan hora, decimal duracao, string dia_semana, string situacao)
        {
            IdTurma = idTurma;
            Curso = curso;
            Sigla_turma = sigla_turma;
            Data_inicio = data_inicio;
            Data_termino = data_termino;
            Hora = hora;
            Duracao = duracao;
            Dia_semana = dia_semana;
            Situacao = situacao;
         }

         public Turma(int idTurma, Curso curso, DateTime data_inicio, DateTime data_termino, TimeSpan hora, decimal duracao, string dia_semana, string situacao)
        {
            IdTurma = idTurma;
            Curso = curso;  
            Data_inicio = data_inicio;
            Data_termino = data_termino;
            Hora = hora;
            Duracao = duracao;
            Dia_semana = dia_semana;
            Situacao = situacao;
 
    }
     public Turma(int idTurma, Curso curso,  DateTime data_inicio, DateTime data_termino, decimal duracao, string dia_semana, string situacao)
        {
            IdTurma = idTurma;
            Curso = curso;
            Data_inicio = data_inicio;
            Data_termino = data_termino;
            Duracao = duracao;
            Dia_semana = dia_semana;
            Situacao = situacao;
        }
         public Turma(int idTurma, Curso curso,  DateTime data_inicio, DateTime data_termino,  decimal duracao, string situacao)
        {
            IdTurma = idTurma;
            Curso = curso;
            Data_inicio = data_inicio;
            Data_termino = data_termino;
            Duracao = duracao;
            Situacao = situacao;
        }
          public Turma(int idTurma, Curso curso,  DateTime data_inicio, DateTime data_termino,  decimal duracao)
        {
            IdTurma = idTurma;
            Curso = curso;
            Data_inicio = data_inicio;
            Data_termino = data_termino;
            Duracao = duracao;
        }

        public Turma(int v1, string v2, DateTime dateTime1, DateTime dateTime2, decimal v3)
        {
        }

        public Turma(int v1, int v2, DateTime dateTime1, DateTime dateTime2, decimal v3)
        {
        }

        public void InserirTurma(Turma turma)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_turma values(null, @idturma,@curso, @data_inicio,@data_termino, @duracao)"; 
            cmd.Parameters.Add("@idturma", MySqlDbType.VarChar).Value = turma.IdTurma;
            cmd.Parameters.Add("@curso", MySqlDbType.VarChar).Value = turma.Curso;
            cmd.Parameters.Add("@data_inicio", MySqlDbType.VarChar).Value = turma.Data_inicio;
            cmd.Parameters.Add("@data_termino", MySqlDbType.VarChar).Value = turma.Data_termino;
            cmd.Parameters.Add("@duracao", MySqlDbType.VarChar).Value = turma.Duracao;
            cmd.ExecuteNonQuery();
        }
        //Alterando DB
        public void AlterarTurma(Turma turma)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_turma values(null, @idturma,@curso, @data_inicio,@data_termino, @duracao)"; 
            cmd.Parameters.Add("@idturma", MySqlDbType.VarChar).Value = turma.IdTurma;
            cmd.Parameters.Add("@curso", MySqlDbType.VarChar).Value = turma.Curso;
            cmd.Parameters.Add("@data_inicio", MySqlDbType.VarChar).Value = turma.Data_inicio;
            cmd.Parameters.Add("@data_termino", MySqlDbType.VarChar).Value = turma.Data_termino;
            cmd.Parameters.Add("@duracao", MySqlDbType.VarChar).Value = turma.Duracao;
            cmd.ExecuteNonQuery();
            
            }
        //Listando via DB
        public List<Turma> Listarturma()
        {
            List<Turma> turmas = new List<Turma>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_turma";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                turmas.Add(
                    new Turma(dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetDateTime(3),
                        dr.GetDateTime(4),
                        dr.GetDecimal(6)
                        ));
            }
            return turmas;
        }
        //Pegando o cadastro via Id(DB)
        public void ObterPorIdTurma(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_turma where id_turma = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IdTurma = dr.GetInt32(0);
                int v = dr.GetInt32(1);
                Data_inicio = dr.GetDateTime(3);
                Data_termino = dr.GetDateTime(4);
                Duracao = dr.GetDecimal(6);
         
            }
        }
    }
}
       

    
