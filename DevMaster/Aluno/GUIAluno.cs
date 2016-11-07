using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMaster
{
    public partial class GUIAluno : Form
    {
        public GUIAluno()
        {
            InitializeComponent();
        }

        private void GUIAluno_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIInserirAluno guiInserirAluno = new GUIInserirAluno();
            guiInserirAluno.ShowDialog();
        }

        private void btnAlterarAluno_Click(object sender, EventArgs e)
        {
            GUIAlterarAluno guiAlterarAluno = new GUIAlterarAluno();
            guiAlterarAluno.ShowDialog();
        }

        private void btnRemoverAluno_Click(object sender, EventArgs e)
        {
            GUIRemoverAluno guiRemoverAluno = new GUIRemoverAluno();
            guiRemoverAluno.ShowDialog();
        }

        private void btnListarAluno_Click(object sender, EventArgs e)
        {
            GUIListarAluno guiListarAluno = new GUIListarAluno();
            guiListarAluno.ShowDialog();
        }

        private void btnPesquisarSerie_Click(object sender, EventArgs e)
        {
            GUIPesquisarAluno guiPesquisarAluno = new GUIPesquisarAluno();
            guiPesquisarAluno.ShowDialog();
        }
    }
}
