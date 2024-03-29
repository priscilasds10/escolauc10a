﻿using System;
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
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        //Inserindo Professor
        private void button1_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor(
                txtNome.Text, txtCpf.Text, txtEmail.Text, txtTelefone.Text
                );
            professor.InserirProf(professor);
            MessageBox.Show("Professor inserido com sucesso!");
        }
        //Alterando Professor
        private void button4_Click_1(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.IdProf = int.Parse(txtId.Text);
            professor.NomeProf = txtNome.Text;
            professor.CpfProf = txtCpf.Text;
            professor.EmailProf = txtEmail.Text;
            professor.TelefoneProf = txtTelefone.Text;
            professor.AlterarProf(professor);
            MessageBox.Show("Professor Alterado com sucesso!");
        }
        //Focar no campo Id
        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
        
        //Listar Professor
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Professor professor = new Professor();
            foreach (var item in professor.ListarProfessor())
            {
                listBox2.Items.Add(item.IdProf + " - " + item.NomeProf + " - " +
                    item.EmailProf + " - " + item.DataCadastroProf);
            }
        }
        
        //Limpar Campos apos bucar
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }

        //Verificando se o Professor esta registrado
        private void button3_Click_1(object sender, EventArgs e)
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
                    Professor professor = new Professor();
                    professor.ObterPorIdProf(int.Parse(txtId.Text));
                    if (professor.IdProf > 0)
                    {
                        txtNome.Text = professor.NomeProf;
                        txtCpf.Text = professor.CpfProf;                  
                        txtEmail.Text = professor.EmailProf;
                        txtTelefone.Text = professor.TelefoneProf;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Professor não cadastrado!");
                        txtId.Focus();
                    }
                }
            }
        }
        //fechar o formulario
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }     
    }
}
