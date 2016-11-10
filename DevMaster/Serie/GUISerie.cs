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
            GUIRemoverSerie guiRemoverSerie = new GUIRemoverSerie();
            guiRemoverSerie.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUIListarSeries guiListarSeries = new GUIListarSeries();
            guiListarSeries.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUIPesquisarSerie guiPesquisarSerie = new GUIPesquisarSerie();
            guiPesquisarSerie.ShowDialog();
        }
    }
}
