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

        //Construtor Padrão
        public GUISerie()
        {
            InitializeComponent();

            //Já abre o form jogando a Consulta na List View
            Consultar();

            //Faz com que as colunas da List View ocupem o espaço que precisar sem cortar
            listViewSerie.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewSerie.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                //ListViewItem é tipo uma linha, e cada coluna é um subitem dessa linha/Item
                ListViewItem linha = listViewSerie.Items.Add(Convert.ToString(serie.CodigoSerie));
                linha.SubItems.Add(serie.DescricaoSerie);
            }
        }

        #endregion

        #region Menu Inserir

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
                //será possível chamar o método Consultar(); dessa tela.
                GUIInserirSerie guiInserirSerie = new GUIInserirSerie(this);
                guiInserirSerie.ShowDialog();
        }

        #endregion

        #region Consultar

        private void btnConsultarClick(object sender, EventArgs e)
        {
            //Botei o código da Consulta dentro da função em vez de botar no botão pq é mais fácil
            //outras telas/construtor chamarem esse método do que o click do botão.
            Consultar();
        }

        #endregion




        #region Alterar

        private void btnAlterarClick(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewSerie.SelectedItems;

            Serie alterarSerie = new Serie();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                alterarSerie.CodigoSerie = Convert.ToInt32(selecionado.SubItems[0].Text);
                alterarSerie.DescricaoSerie = selecionado.SubItems[1].Text;

                //Enviando a série a ser alterada pra tela de Alterar:
                //O parâmetro this é essa própria tela, com isso lá na tela de Alterar 
                //será possível chamar o método Consultar(); dessa tela.
                GUIAlterarSerie guiAlterarSerie = new GUIAlterarSerie(alterarSerie, this);
                guiAlterarSerie.ShowDialog();
            }
        }

        #endregion

        #region Remover

        private void btnRemoverClick(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewSerie.SelectedItems;

            Serie removerSerie = new Serie();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                removerSerie.CodigoSerie = Convert.ToInt32(selecionado.SubItems[0].Text);
                if (MessageBox.Show("Tem certeza?", "Confirmar remoção da Série.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DAOSerie.Instancia.Excluir(removerSerie);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        private void listViewSerie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
