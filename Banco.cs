using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    public static class Banco
    {

        public static string StrCon =" @server=ca109-pl.valueserver.net;user id=aluno_itoo;database=wellington_88db;password=79Tgdo@5";
        public static MySqlCommand AbriConexao()
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection cn = new MySqlConnection(StrCon);
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception)
            {

            }
            return cmd;

        }
    }
}