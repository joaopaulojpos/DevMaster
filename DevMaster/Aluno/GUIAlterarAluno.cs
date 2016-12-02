using GUI.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUIAlterarAluno : Form
    {
        #region Atributos

        Aluno alunoSelecionado;
        Aluno alunoAlterado;
        GUIAluno guiAluno;

        #endregion

        #region Construtores

        //Padrão
        private GUIAlterarAluno()
        {
            InitializeComponent();
        }

        //
        public GUIAlterarAluno(Aluno alunoOld, GUIAluno guiAluno)
        {
            InitializeComponent();

            alunoAlterado = alunoOld;
            AlimentarCampos(alunoOld);
            this.guiAluno = guiAluno;
        }

        #endregion

        #region Métodos Auxiliares

        void AlimentarCampos(Aluno aluno)
        {
            textBoxMatricula.Text = aluno.Matricula;
            textBoxNome.Text = aluno.Nome;
            dateNascimento.Text = aluno.DataNasc.ToShortDateString();
            comboBoxSexo.Text = aluno.Sexo;
            textBoxTelefone.Text = aluno.Telefone;
            comboBoxTurma.Text = aluno.Turma.DescricaoTurma;

        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {/*
            try
            {
                alunoAlterado.Matricula = textBoxMatricula.Text;
                alunoAlterado.Nome = textBoxNome.Text;
                alunoAlterado.DataNasc = Convert.ToDateTime(dateNascimento.Text);

                alunoAlterado.Sexo = comboBoxSexo.Text;
                alunoAlterado.Telefone = textBoxTelefone.Text;
                Turma fdsa;
                fdsa.CodigoTurma = Convert.ToInt32(comboBoxTurma.Text);
                alunoAlterado.Turma = turma;

                RNEnsino rnEnsino = new RNEnsino();
                rnEnsino.Alterar(ensinoAlterado);
                MessageBox.Show("Ensino alterada com sucesso!");

                //Chamando o método Consultar da tela anterior
                guiEnsino.CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
                throw;
            }*/
        }

        #endregion

        #region Botão VOltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
