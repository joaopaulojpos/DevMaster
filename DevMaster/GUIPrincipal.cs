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
             NovoGUIAluno guiAluno = new NovoGUIAluno();
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
    }
}
