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
using Biblioteca.Teste;

namespace GUI
{
    public partial class GUIPrincipal : Form
    {
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lançarFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIChamada guiPresenca = new GUIChamada();
            //Mostra a tela e impede q o usuário tente mexer na tela de trás
            guiPresenca.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Finaliza o programa
            Application.Exit();
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lançarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUILancarNota guiNotas = new GUILancarNota();
            //Mostra a tela e impede q o usuário tente mexer na tela de trás
            guiNotas.ShowDialog();
        }

        private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAluno guiAluno = new GUIAluno();
            guiAluno.ShowDialog();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroSérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUISerie guiSerie = new GUISerie();
            guiSerie.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cadastroDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIDisciplina guiDisciplina = new GUIDisciplina();
            guiDisciplina.ShowDialog();
        }

        private void coordenaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroTipoDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUITipoUsuario guiTipoUsuario = new GUITipoUsuario();
            guiTipoUsuario.ShowDialog();
        }

        private void cadastroTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUITurma guiTurma = new GUITurma();
            guiTurma.ShowDialog();
        }

        private void abonoDeFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAbono guiAbono = new GUIAbono();
            guiAbono.ShowDialog();
        }

        private void cadastroAulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAula guiAula = new GUIAula();
            guiAula.ShowDialog();
        }

        private void cadastroUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIUsuario guiUsuario = new GUIUsuario();
            guiUsuario.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TestaSerie testa = new TestaSerie();
            testa.ShowDialog();
        }
    }
}
