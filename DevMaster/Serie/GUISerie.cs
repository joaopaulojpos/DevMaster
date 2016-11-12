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
    public partial class GUISerie : Form
    {
        public GUISerie()
        {
            InitializeComponent();
        }

        private void GUISerie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIInserirSerie guiInserirSerie = new GUIInserirSerie();
            guiInserirSerie.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUIAlterarSerie guiAlterarSerie = new GUIAlterarSerie();
            guiAlterarSerie.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
    
        }

        private void button5_Click(object sender, EventArgs e)
        {
   
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirSerie guiInserirSerie = new GUIInserirSerie();
            guiInserirSerie.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GUIAlterarSerie guiAlterarSerie = new GUIAlterarSerie();
            guiAlterarSerie.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
