using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Basicas;

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
            //dateNascimento.Text = aluno.DataNasc.tosh
        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {

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
