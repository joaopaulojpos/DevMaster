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
    public partial class GUIEnsino : Form
    {
        #region Atributos

        List<Ensino> listaEnsino;
        
        #endregion

        #region Construtores

        //Construtor Padrão
        public GUIEnsino()
        {
            InitializeComponent();

            //Já abre o form jogando a Consulta na List View
            Consultar();

            //Faz com que as colunas da List View ocupem o espaço que precisar sem cortar
            listViewEnsino.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEnsino.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        public void Consultar()
        {
            listViewEnsino.Items.Clear();

            string filtro = textBoxFiltro.Text;

            Ensino ensino2 = new Ensino();
            ensino2.DescricaoEnsino = filtro;

            DAOEnsino daoEnsino = new DAOEnsino();
            listaEnsino = daoEnsino.Listar(ensino2);

            foreach (Ensino ensino in listaEnsino)
            {
                //ListViewItem é tipo uma linha, e cada coluna é um subitem dessa linha/Item
                ListViewItem linha = listViewEnsino.Items.Add(Convert.ToString(ensino.CodigoEnsino));
                linha.SubItems.Add(ensino.DescricaoEnsino);
            }
        }

        #endregion

        #region Menu Inserir

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
                //será possível chamar o método Consultar(); dessa tela.
                GUIInserirEnsino guiInserirEnsino = new GUIInserirEnsino(this);
                guiInserirEnsino.ShowDialog();
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
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsino.SelectedItems;

            Ensino alterarEnsino = new Ensino();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                alterarEnsino.CodigoEnsino= Convert.ToInt32(selecionado.SubItems[0].Text);
                alterarEnsino.DescricaoEnsino = selecionado.SubItems[1].Text;

                //Enviando a série a ser alterada pra tela de Alterar:
                //O parâmetro this é essa própria tela, com isso lá na tela de Alterar 
                //será possível chamar o método Consultar(); dessa tela.
                GUIAlterarEnsino guiAlterarEnsino = new GUIAlterarEnsino(alterarEnsino, this);
                guiAlterarEnsino.ShowDialog();
            }
        }

        #endregion

        #region Remover

        private void btnRemoverClick(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsino.SelectedItems;

            Ensino removerEnsino = new Ensino();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                removerEnsino.CodigoEnsino = Convert.ToInt32(selecionado.SubItems[0].Text);
                if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Ensino.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DAOEnsino daoEnsino = new DAOEnsino();
                    daoEnsino.Excluir(removerEnsino);

                    listViewEnsino.Items.Remove(selecionado);
                }
                else
                {
                    MessageBox.Show("Cancelado.", "Remoção de Ensino");
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

        private void GUIEnsino_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        private void listViewEnsino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
