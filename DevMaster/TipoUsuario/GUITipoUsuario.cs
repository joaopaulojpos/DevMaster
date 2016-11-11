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
    public partial class GUITipoUsuario : Form
    {
        public GUITipoUsuario()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIAlterarTipoUsuario guiAlterarTipoUsuario = new GUIAlterarTipoUsuario();
            guiAlterarTipoUsuario.ShowDialog();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTipoUsuario guiInserirTipoUsuario = new GUIInserirTipoUsuario();
            guiInserirTipoUsuario.ShowDialog();
        }
    }
}
