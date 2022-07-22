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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }
        //Inserir Usuario
        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(
                txtNome.Text,  txtEmail.Text, txtSenha.Text, txtSitu.Text
                );
            usuario.InserirUser(usuario);
            MessageBox.Show("Usuario inserido com sucesso!");
        }

        //Alterar Usuario

        private void button4_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.IdUser = int.Parse(txtId.Text);
            usuario.NomeUser = txtNome.Text;
            usuario.EmailUser = txtEmail.Text;
            usuario.SenhaUser = txtSenha.Text;
            usuario.SituacaoUser = txtSitu.Text;
            usuario.AlterarUser(usuario);
            MessageBox.Show("Usuario inserido com sucesso!");
        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
        //Listar Usuarios
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Usuario usuario = new Usuario();
            foreach (var item in usuario.ListarTodosUser())
            {
                listBox2.Items.Add(item.IdUser + " - " + item.NomeUser + " - " +
                    item.EmailUser + " - " + item.SenhaUser + " - " + item.SituacaoUser);
            }
        }
        //Limpando Campos
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtSitu.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtId.ReadOnly == true)
            {
                txtId.ReadOnly = false;
                button3.Text = "Buscar";
                txtId.Focus();
                LimparCampos();
            }
            else
            {
                if (txtId.Text != string.Empty)
                {
                    Usuario usuario = new Usuario();
                    usuario.ObterPorIdUser(int.Parse(txtId.Text));
                    if (usuario.IdUser > 0)
                    {
                        txtNome.Text = usuario.NomeUser;            
                        txtEmail.Text = usuario.EmailUser;
                        txtSenha.Text = usuario.SenhaUser;
                        txtSitu.Text = usuario.SituacaoUser;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario não cadastrado!");
                        txtId.Focus();
                    }

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}