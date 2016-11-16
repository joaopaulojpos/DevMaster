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
        #region Atributos

        List<Serie> listaSerie;

        #endregion

        #region Construtores

        public GUISerie()
        {
            InitializeComponent();

            //To tentando fazer pra ele já clicar no Consultar quando abrir a tela

            //btnConsultar.PerformClick();
            //btnConsultarClick.PerformClick();

            //Enquanto eu não to conseguindo, tirei tudo do botão Consultar e botei num método, 
            //ai o botão e esse construtor vai chamar o método:

            Consultar();
        }

        #endregion

        #region Métodos Auxiliares

        public void Consultar()
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

        #endregion

        #region Menu Inserir

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirSerie guiInserirSerie = new GUIInserirSerie();
            guiInserirSerie.ShowDialog();
        }

        #endregion

        #region Consultar

        private void btnConsultarClick(object sender, EventArgs e)
        {
            Consultar();
        }

        #endregion




        #region Alterar

        private void btnAlterarClick(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewSerie.SelectedItems;
            //Instanciando objeto que vai ser alterado
            Serie alterarSerie = new Serie();
            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                //Alimentando a série a ser alterada
                alterarSerie.CodigoSerie = Convert.ToInt32(selecionado.SubItems[0].Text);
                alterarSerie.DescricaoSerie = selecionado.SubItems[1].Text;
                //Enviando a série a ser alterada pra tela de Alterar
                GUIAlterarSerie guiAlterarSerie = new GUIAlterarSerie(alterarSerie);
                guiAlterarSerie.ShowDialog();
            }
        }

        #endregion

        #region Remover

        private void btnRemoverClick(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewSerie.SelectedItems;
            //Instanciando objeto que vai ser removido
            Serie removerSerie = new Serie();
            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                removerSerie.CodigoSerie = Convert.ToInt32(selecionado.SubItems[0].Text);
                if (MessageBox.Show("Tem certeza?", "Confirmar remoção da Série.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Remove do Banco
                    DAOSerie.Instancia.Excluir(removerSerie);
                    //Remove da ListView
                    listViewSerie.Items.Remove(selecionado);
                }
                else
                {
                    MessageBox.Show("Cancelado.", "Remoção de Série");
                }
            }
        }

        #endregion

        #region Voltar

        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void GUISerie_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
    }
}
