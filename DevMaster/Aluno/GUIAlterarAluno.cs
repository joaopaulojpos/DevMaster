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
    public partial class GUIAlterarAluno : Form
    {
        public GUIAlterarAluno()
        {
            InitializeComponent();
        }

        private void GUIAlterarAluno_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUIAlterar2Aluno guiAlterar2Aluno = new GUIAlterar2Aluno();
            guiAlterar2Aluno.ShowDialog();
        }
    }
}
