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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAluno frmAluno = new FrmAluno();
            frmAluno.MdiParent = this; //FrmPrincipal;
            frmAluno.Show();
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfessor frmProfessor = new FrmProfessor();
            frmProfessor.MdiParent = this;
            frmProfessor.Show();
        }
        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCurso frmCurso = new FrmCurso();
            frmCurso.MdiParent = this;
            frmCurso.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }
        private void turmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTurma frmTurma = new FrmTurma();
            frmTurma.MdiParent = this; 
            frmTurma.Show();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (Program.usuarioLogado != null)
            {
                Text = " - " + Program.usuarioLogado.NomeUser;
            }            
        }

        private void matriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatricula frmMatricula = new FrmMatricula();
            frmMatricula.MdiParent = this;
            frmMatricula.Show();
        }
    }
}
