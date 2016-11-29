using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Temp
using Biblioteca;

namespace GUI
{
    public partial class GUIPrincipal : Form
    {
        #region Atributos



        #endregion

        #region Construtores

        public GUIPrincipal()
        {
            InitializeComponent();
            /*Outra opção, fazer na mão em vez de usar as propriedades da IDE ->
            //Bota pra a posição inicial do Form ser no centro da tela
            StartPosition = FormStartPosition.CenterScreen;
            //Maximiza a tela
            this.WindowState = FormWindowState.Maximized;
            */
        }

        #endregion

        #region Consultar Ensino

        private void consultarEnsinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEnsino guiEnsino = new GUIEnsino();
            guiEnsino.ShowDialog();
        }

        #endregion

        #region Cadastro de Alunos

        private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAluno guiAluno = new GUIAluno();
            guiAluno.ShowDialog();
        }

        #endregion

        #region Novo Aluno

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Cadastro Disciplina

        private void cadastroDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIDisciplina guiDisciplina = new GUIDisciplina();
            guiDisciplina.ShowDialog();
        }

        #endregion

        #region Lançar Faltas

        private void lançarFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIChamada guiPresenca = new GUIChamada();
            guiPresenca.ShowDialog();
        }

        #endregion



        #region Professor??Oo

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region Lançar Notas

        private void lançarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUILancarNota guiNotas = new GUILancarNota();
            //Mostra a tela e impede q o usuário tente mexer na tela de trás
            guiNotas.ShowDialog();
        }

        #endregion


        #region Coordenação

        private void coordenaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Cadastro Tipo de Usuário

        private void consultarTipoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUITipoUsuario guiTipoUsuario = new GUITipoUsuario();
            guiTipoUsuario.ShowDialog();
        }

        #endregion

        #region Cadastro Turma

        private void cadastroDeTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUITurma guiTurma = new GUITurma();
            guiTurma.ShowDialog();
        }

        #endregion

        #region Abono

        private void abonoDeFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAbono guiAbono = new GUIAbono();
            guiAbono.ShowDialog();
        }

        #endregion

        #region Cadastro Aula

        private void cadastroAulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAula guiAula = new GUIAula();
            guiAula.ShowDialog();
        }

        #endregion

        #region Cadastro Usuário

        private void cadastroUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIUsuario guiUsuario = new GUIUsuario();
            guiUsuario.ShowDialog();
        }

        #endregion

        #region Sair

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
         
        }

        #endregion


        #region Outros

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        #endregion

        private void ToolStripMenuItemLogOut_Click(object sender, EventArgs e)
        {
           
        }

        private void ToolStripMenuItemSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
