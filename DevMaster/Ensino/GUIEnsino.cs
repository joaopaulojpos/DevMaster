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
using WebService;

namespace GUI
{
    public partial class GUIEnsino : Form
    {
        #region Atributos

        List<Ensino> listaEnsino;
        int filtroCodigo;

        private Servico servico;
        Ensino ensinoFiltro;

        #endregion

        #region Construtores

        //Construtor Padrão
        public GUIEnsino()
        {
            InitializeComponent();

            //Já abre o form jogando a Consulta na List View
            CarregarListView();

            //Faz com que as colunas da List View ocupem o espaço que precisar sem cortar
            listViewEnsinos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEnsinos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        #region TextBoxCodigo

        //Métodos para ajudarem na validação de textBoxCodigo
        public void TirarZeroTextBoxCodigo()
        {
            if (textBoxCodigo.Text == "0")
            {
                LimpaTextBoxCodigo();
            }
        }

        public void LimpaTextBoxCodigo()
        {
            textBoxCodigo.Text = "";
        }

        public void ZeraTextBoxCod()
        {
            if (textBoxCodigo.Text == "")
            {
                textBoxCodigo.Text = "0";
            }
        }

        #endregion

        #region Carregar ListView

        public void CarregarListView()
        {
            try
            {
                listViewEnsinos.Items.Clear();

                ensinoFiltro = new Ensino();
                servico = new Servico();
                //                  CÓDIGO ENSINO
                ZeraTextBoxCod();
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo)) //Ele valida o primeiro param e se for inteiro, joga o valor pra o segundo param, nesse caso filtroCodigo
                {
                    TirarZeroTextBoxCodigo(); //Só pra não ficar o número zero 0 lá no textbox, perfumaria...
                    ensinoFiltro.CodigoEnsino = filtroCodigo;
                }
                else
                {
                    LimpaTextBoxCodigo();
                    throw new FormatException("Digite apenas números válidos.");
                }

                ensinoFiltro.DescricaoEnsino = textBoxEnsino.Text;

                listaEnsino = servico.ListarEnsino(ensinoFiltro);

                if (listaEnsino.Count > 0)
                {
                    foreach (Ensino ensino in listaEnsino)
                    {
                        //ListViewItem é tipo uma linha, e cada coluna é um subitem dessa linha/Item
                        ListViewItem linha = listViewEnsinos.Items.Add(Convert.ToString(ensino.CodigoEnsino));
                        linha.SubItems.Add(ensino.DescricaoEnsino);
                    }
                }
                else
                {
                    MessageBox.Show("Sem resultados.");
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
                CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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



        //Comentados
        #region Menu Inserir

        //private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
        //        //será possível chamar o método Consultar(); dessa tela.
        //        GUIInserirEnsino guiInserirEnsino = new GUIInserirEnsino(this);
        //        guiInserirEnsino.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro: \n" + ex.Message);
        //    }
        //}

        #endregion

        #region Alterar

        //private void btnAlterar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Ensino alterarEnsino = new Ensino();
        //        int codigoSelecionado = 0;

        //        //Pega o Ensino selecionado, mesmo que só seja um ele entende como uma coleção
        //        ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsinos.SelectedItems;
        //        //Percorrendo a coleção(a série selecionada)
        //        foreach (ListViewItem selecionado in colecaoSelecionada)
        //        {
        //            codigoSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
        //        }

        //        foreach (Ensino ensino in listaEnsino)
        //        {
        //            if (ensino.CodigoEnsino == codigoSelecionado)
        //            {
        //                alterarEnsino = ensino;
        //            }
        //        }

        //        //Enviando a série a ser alterada pra tela de Alterar:
        //        //O parâmetro this é essa própria tela, com isso lá na tela de Alterar 
        //        //será possível chamar o método Consultar(); dessa tela.
        //        GUIAlterarEnsino guiAlterarEnsino = new GUIAlterarEnsino(alterarEnsino, this);
        //        guiAlterarEnsino.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro: \n" + ex.Message);
        //    }
        //}

        #endregion

        #region Remover

        //private void btnRemover_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
        //        ListView.SelectedListViewItemCollection colecaoSelecionada = listViewEnsinos.SelectedItems;

        //        if (colecaoSelecionada.Count > 0)
        //        {
        //            Ensino removerEnsino = new Ensino();

        //            //Percorrendo a coleção(a série selecionada)
        //            foreach (ListViewItem selecionado in colecaoSelecionada)
        //            {
        //                removerEnsino.CodigoEnsino = Convert.ToInt32(selecionado.SubItems[0].Text);
        //                if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Ensino.", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //                {
        //                    servico = new Servico();
        //                    servico.Excluiren(removerEnsino);

        //                    listViewEnsinos.Items.Remove(selecionado);
        //                    MessageBox.Show("Ensino removido com sucesso!");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Cancelado.", "Remoção de Ensino");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Selecione o Ensino que deseja Remover.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro: \n" + ex.Message);
        //    }
        //}

        #endregion

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }
    }
}
