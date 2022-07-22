using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtEmail.Text, txtPass.Text);
            if (usuario.EfetuarLogin(usuario))
            {
                this.Close();
                Program.usuarioLogado = usuario;
            }
            else
            {
                MessageBox.Show("Usuario ou Senha incorreto");
                Application.Restart();  
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
