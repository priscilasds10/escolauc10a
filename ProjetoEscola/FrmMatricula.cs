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
    public partial class FrmMatricula : Form
    {
        public FrmMatricula()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMatricula_Load(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            var listaALuno = aluno.ListarTodos();
            cmbAluno.DataSource = listaALuno;
            cmbAluno.DisplayMember = "Nome";
            cmbAluno.ValueMember = "Id";

            Curso curso = new Curso();
            var listarCurso = curso.ListarCursos();
            cmbCurso.DataSource = listarCurso;
            cmbCurso.DisplayMember = "Nome";
            cmbCurso.ValueMember = "Id";
        }

        private void btnMatricular_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.ObterPorId(Convert.ToInt32(cmbAluno.SelectedValue));
            Curso curso = new Curso();
            curso.ObterPorIdCurso(Convert.ToInt32(cmbCurso.SelectedValue));

            Matricula matricula = new Matricula();
            matricula.InserirMatri(aluno,curso, Program.usuarioLogado);

            MessageBox.Show("Matricula efetuada com sucesso!");
        }
    }
}
