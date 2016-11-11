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
    public partial class GUIDisciplina : Form
    {
        public GUIDisciplina()
        {
            InitializeComponent();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirDisciplina guiInserirDisciplina = new GUIInserirDisciplina();
            guiInserirDisciplina.ShowDialog();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            GUIAlterarDisciplina guiAlterarDisciplina = new GUIAlterarDisciplina();
            guiAlterarDisciplina.ShowDialog();
        }
    }
}
