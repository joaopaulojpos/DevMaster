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
            this.Close();
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

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            listViewSerie.Items.Clear();

            string filtro = textBoxFiltro.Text;

            Serie serie2 = new Serie();
            serie2.DescricaoSerie = filtro;

            listaSerie = DAOSerie.Instancia.Listar(serie2);

            foreach (Serie serie in listaSerie)
            {
                ListViewItem linha = listViewSerie.Items.Add(Convert.ToString(serie.CodigoSerie));
                linha.SubItems.Add(serie.DescricaoSerie);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnRemover_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selecionado = listViewSerie.SelectedItems;

            Serie removerSerie = new Serie();
            foreach (ListViewItem serie in selecionado)
            {
                removerSerie.CodigoSerie = Convert.ToInt32(serie.SubItems[0].Text);
                if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Funcionário", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DAOSerie.Instancia.Excluir(removerSerie);
                    listViewSerie.Items.Remove(serie);
                }
                else
                {
                    MessageBox.Show("Cancelado.", "Remoção de Série");
                }
            }
        }
    }
}
