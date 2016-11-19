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
    public partial class GUITurma : Form
    {
        public GUITurma()
        {
            InitializeComponent();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTurma guiInserirTurma = new GUIInserirTurma();
            guiInserirTurma.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma();
            guiAlterarTurma.ShowDialog();
        }
    }
}
