﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    public class Professor
    {

        public int IdProf { get; set; }
        public string NomeProf { get; set; }
        public string CpfProf { get; set; }
        public string EmailProf { get; set; }
        public string TelefoneProf { get; set; }
        public DateTime DataCadastroProf { get; set; }

        public Professor()
        {

        }
        public Professor(string nomeProf, string cpfProf, string emailProf, string telefoneProf)
        {
            NomeProf = nomeProf;
            CpfProf = cpfProf;
            EmailProf = emailProf;
            TelefoneProf = telefoneProf;
        }
        public Professor(int idProf, string nomeProf, string cpfProf, string emailProf, string telefoneProf, DateTime dataCadastroProf)
        {
            IdProf = idProf;
            NomeProf = nomeProf;
            CpfProf = cpfProf;
            EmailProf = emailProf;
            TelefoneProf = telefoneProf;
            DataCadastroProf = dataCadastroProf;
        }
        public bool EfetuarLoginProfessor(Professor professor)
        {
            return true;
        }
        //Inserindo DB
        public void InserirProf(Professor professor)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_professor values(null, @nome,@cpf, @email, @telefone, default)"; 
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professor.NomeProf;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = professor.CpfProf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = professor.EmailProf;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professor.TelefoneProf;
            cmd.ExecuteNonQuery();
        }
        //Alterando DB
        public void AlterarProf(Professor professor)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_professor set nome_professor=@nome, email_professor = @email, telefone_professor=@telefone where id_professor =@id";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professor.NomeProf;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = professor.IdProf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = professor.EmailProf;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professor.TelefoneProf;
            cmd.ExecuteNonQuery();
        }
        //Listando via DB
        public List<Professor> ListarProfessor()
        {
            List<Professor> professores = new List<Professor>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                professores.Add(
                    new Professor(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetDateTime(5)
                        ));
            }
            return professores;
        }
        //Pegando o cadastro via Id(DB)
        public void ObterPorIdProf(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor where id_professor = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IdProf = dr.GetInt32(0);
                NomeProf = dr.GetString(1);
                CpfProf = dr.GetString(2);
                EmailProf = dr.GetString(3);
                TelefoneProf = dr.GetString(4);
                DataCadastroProf = dr.GetDateTime(5);
            }
        }
    }
}