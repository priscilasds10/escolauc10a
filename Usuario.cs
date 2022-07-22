using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoEscola
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public string NomeUser { get; set; }
        public string EmailUser { get; set; }
        public string SenhaUser { get; set; }
        public string SituacaoUser { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nomeUser, string emailUser, string senhaUser, string situacaoUser)
        {
            NomeUser = nomeUser;
            EmailUser = emailUser;
            SenhaUser = senhaUser;
            SituacaoUser = situacaoUser;
        }

        public Usuario(int idUser, string nomeUser, string emailUser, string senhaUser, string situacaoUser)
        {
            IdUser = idUser;
            NomeUser = nomeUser;
            EmailUser = emailUser;
            SenhaUser = senhaUser;
            SituacaoUser = situacaoUser;
        }
        public Usuario(string nomeUser, string emailUser, string senhaUser)
        {       
            NomeUser = nomeUser;
            EmailUser = emailUser;
            SenhaUser = senhaUser;            
        }
        public Usuario(string emailUser, string senhaUser)
        {            
            EmailUser = emailUser;
            SenhaUser = senhaUser;
        }
        public void InserirUser(Usuario usuario)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_usuario values(null, @nome, @email, @senha, @situacao);"; 
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.NomeUser;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.EmailUser;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.SenhaUser;
            cmd.Parameters.Add("@situacao", MySqlDbType.VarChar).Value = usuario.SituacaoUser;
            cmd.ExecuteNonQuery();
        }
        public void AlterarUser(Usuario usuario)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_usuario set nome_usuario=@nome, senha_usuario=@senha ,situacao_usuario=@situacao where id_usuario =@id";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.NomeUser;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.SenhaUser;
            cmd.Parameters.Add("@situacao", MySqlDbType.VarChar).Value = usuario.SituacaoUser;
            cmd.ExecuteNonQuery();
        }

        public List<Usuario> ListarTodosUser()
        {
            List<Usuario> usuarios = new List<Usuario>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario ";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usuarios.Add(new Usuario(dr.GetInt32(0),dr.GetString(1),dr.GetString(2), dr.GetString(3),dr.GetString(4)));
            }
            return usuarios;
        }
        public void ObterPorIdUser(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario where id_usuario = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IdUser = dr.GetInt32(0);
                NomeUser = dr.GetString(1);
                EmailUser = dr.GetString(2);
                SenhaUser = dr.GetString(3);
                SituacaoUser = dr.GetString(4);
            }
        }
        public bool EfetuarLogin(Usuario usuario)
        {
            bool valido = false;
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario where senha_usuario = md5(@senha) and email_usuario = @email;";
            cmd.Parameters.Add("@senha",MySqlDbType.VarChar).Value = usuario.SenhaUser;
            cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = usuario.EmailUser;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IdUser = dr.GetInt32(0);
                NomeUser = dr.GetString(1);
                SituacaoUser = dr.GetString(4);
                valido = true;
            }
            return valido;
        }
    }
}