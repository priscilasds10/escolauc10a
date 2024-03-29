﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoEscola
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public double ValorCurso { get; set; }

        public Curso()
        {
            CargaHoraria = 0;
        }

        public Curso(string nome, int cargaHoraria, double valorCurso)
        {

            Nome = nome;
            CargaHoraria = cargaHoraria;
            ValorCurso = valorCurso;
        }
        public Curso(int id, string nome, int cargaHoraria, double valorCurso)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ValorCurso = valorCurso;
        }
        public void InserirCurso(Curso curso)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_curso values(null, @nome,@cargahoraria,@valor);";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@cargahoraria", MySqlDbType.VarChar).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = curso.ValorCurso;
            cmd.ExecuteNonQuery();
        }
        public void AlterarCurso(Curso curso)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_curso set nome_curso=@nome, carga_horaria_curso=@cargahoraria, valor_curso=@valor where id_curso =@id";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@cargahoraria", MySqlDbType.VarChar).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = curso.ValorCurso;
            cmd.ExecuteNonQuery();
        }
        public List<Curso> ListarCursos()
        {
            List<Curso> cursos = new List<Curso>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cursos.Add(
                    new Curso(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDouble(3)));
            }
            return cursos;
        }
        public void ObterPorIdCurso(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso where id_curso = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                CargaHoraria = dr.GetInt32(2);
                ValorCurso = dr.GetDouble(3);
            }
        }
    }
}