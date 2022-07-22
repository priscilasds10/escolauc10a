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
    public partial class FrmCurso : Form
    {
        public FrmCurso()
        {
            InitializeComponent();
        }
        //Inserindo
        private void button1_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso(
                txtNome.Text, int.Parse(txtCargaHr.Text), Convert.ToDouble(txtValorCurso.Text)
                );
            curso.InserirCurso(curso);
            MessageBox.Show("Curso inserido com sucesso!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.Id = int.Parse(txtId.Text);
            curso.Nome = txtNome.Text;
            curso.CargaHoraria = int.Parse(txtCargaHr.Text);
            curso.ValorCurso = Convert.ToDouble(txtValorCurso.Text);
            curso.AlterarCurso(curso);
            MessageBox.Show("Curso Alterado com sucesso!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Curso curso = new Curso();
            foreach (var item in curso.ListarCursos())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.CargaHoraria + " - " + item.ValorCurso);
            }
        }
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtValorCurso.Clear();
            txtCargaHr.Clear();
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
                    Curso curso = new Curso();
                    curso.ObterPorIdCurso(int.Parse(txtId.Text));
                    if (curso.Id > 0)
                    {
                        txtNome.Text = curso.Nome;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Curso não cadastrado!");
                        txtId.Focus();
                    }

                }
            }
        }

        private void FrmCurso_Load(object sender, EventArgs e)
        {

        }
    }
}
