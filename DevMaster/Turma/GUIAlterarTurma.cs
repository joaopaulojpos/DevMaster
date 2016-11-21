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
using Biblioteca.RN;

namespace GUI
{
    public partial class GUIAlterarTurma : Form
    {
        public GUIAlterarTurma(Turma turmaOld)
        {
            InitializeComponent();
        }

        public GUIAlterarTurma(Turma turmaOld, GUITurma guiTurma)
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
