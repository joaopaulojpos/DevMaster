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
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUISerie : Form
    {
        List<Serie> listaSerie;
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
            DAOSerie daoSerie = new DAOSerie();
            string filtro = textBoxFiltro.Text;
            Serie serie = new Serie();
            serie.DescricaoSerie = filtro;
            listaSerie = daoSerie.Listar(serie);

            foreach (Serie valor in listaSerie)
            {
                listBoxSerie.Items.AddRange(new object[] {
                valor.CodigoSerie + " " + valor.DescricaoSerie,
                });
            }

            /*
            List<string> nomes = new List<string>();
            nomes.Add("leandro");
            listBoxSerie.Items.Add(nomes[0]);
            */
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
