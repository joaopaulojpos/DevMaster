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
            PopularComboBox();
            Consultar();

            //Faz com que as colunas da List View ocupem o espaço que precisar sem cortar
            listViewEnsinos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEnsinos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        #region Popular ComboBox

        public void PopularComboBox()
        {
            comboBoxCampos.Items.Clear();
            comboBoxCampos.Items.Add("Código");
            comboBoxCampos.Items.Add("Descrição");
        }

        #endregion

        #region Consultar

        public void Consultar()
        {
            try
            {
                listViewEnsinos.Items.Clear();

                string filtro = textBoxFiltro.Text;

                Ensino ensinoFiltro = new Ensino();

                if (comboBoxCampos.Items.Equals("Código"))
                {
                    ensinoFiltro.CodigoEnsino = Convert.ToInt32(filtro);
                }
                else if (comboBoxCampos.Items.Equals("Descrição"))
                {
                    ensinoFiltro.DescricaoEnsino = filtro;
                }
                
                RNEnsino rnEnsino = new RNEnsino();

                listaEnsino = rnEnsino.Listar(ensinoFiltro);

                foreach (Ensino ensino in listaEnsino)
                {
                    //ListViewItem é tipo uma linha, e cada coluna é um subitem dessa linha/Item
                    ListViewItem linha = listViewEnsinos.Items.Add(Convert.ToString(ensino.CodigoEnsino));
                    linha.SubItems.Add(ensino.DescricaoEnsino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }

        #endregion

        #endregion

        #region Consultar

        private void btnConsultarClick(object sender, EventArgs e)
        {
            try
            {
                //Botei o código da Consulta dentro da função em vez de botar no botão pq é mais fácil
                //outras telas/construtor chamarem esse método do que o click do botão.
                Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Menu Inserir

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
                //será possível chamar o método Consultar(); dessa tela.
                GUIInserirEnsino guiInserirEnsino = new GUIInserirEnsino(this);
                guiInserirEnsino.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }

        #endregion

        #region Alterar

        private void btnAlterarClick(object sender, EventArgs e)
        {
            try
            {
                //Pega o Ensino selecionado, mesmo que só seja um ele entende como uma coleção
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsinos.SelectedItems;

                Ensino alterarEnsino = new Ensino();
                int codigoSelecionado = 0;

                //Percorrendo a coleção(a série selecionada)
                foreach (ListViewItem selecionado in colecaoSelecionada)
                {
                    codigoSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
                }

                foreach (Ensino ensino in listaEnsino)
                {
                    if (ensino.CodigoEnsino == codigoSelecionado)
                    {
                        alterarEnsino = ensino;
                    }
                }

                //Enviando a série a ser alterada pra tela de Alterar:
                //O parâmetro this é essa própria tela, com isso lá na tela de Alterar 
                //será possível chamar o método Consultar(); dessa tela.
                GUIAlterarEnsino guiAlterarEnsino = new GUIAlterarEnsino(alterarEnsino, this);
                guiAlterarEnsino.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }

        #endregion

        #region Remover

        private void btnRemoverClick(object sender, EventArgs e)
        {
            try
            {
                //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsinos.SelectedItems;

                Ensino removerEnsino = new Ensino();

                //Percorrendo a coleção(a série selecionada)
                foreach (ListViewItem selecionado in colecaoSelecionada)
                {
                    removerEnsino.CodigoEnsino = Convert.ToInt32(selecionado.SubItems[0].Text);
                    if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Ensino.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RNEnsino rnEnsino = new RNEnsino();
                        rnEnsino.Excluir(removerEnsino);

                        listViewEnsinos.Items.Remove(selecionado);
                    }
                    else
                    {
                        MessageBox.Show("Cancelado.", "Remoção de Ensino");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
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

        private void listViewEnsino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
