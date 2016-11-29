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
using Biblioteca.DAO;
using WebService;

namespace GUI
{
    public partial class GUITurma : Form
    {

        #region Atributos

        List<Turma> listaTurma;
        int filtroCodigo;
        Turma alterarTurma;

        DAOEnsino daoEnsino;
        DAOTurma daoTurma;
        List<Ensino> listaEnsino;

        #endregion

        #region Construtores

        //Padrão
        public GUITurma()
        {
            InitializeComponent();
            //listViewTurmas
            CarregarListView();

            listViewTurma.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewTurma.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        #region TextBoxCodigo

        //Métodos para ajudarem na validação de textBoxCodigo
        public void TirarZeroTextBox(TextBox textBox)
        {
            if (textBox.Text == "0")
            {
                LimpaTextBox(textBox);
            }
        }

        public void LimpaTextBox(TextBox textBox)
        {
            textBox.Text = "";
        }

        public void ZeraTextBox(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
        }

        #endregion

        #region Consultar

        public void CarregarListView()
        {
            try
            {
                listViewTurma.Items.Clear();

                Turma turmaFiltro = new Turma();

                //                  CÓDIGO TURMA
                ZeraTextBox(textBoxCodigo);
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo))
                {
                    TirarZeroTextBox(textBoxCodigo);
                    turmaFiltro.CodigoTurma = filtroCodigo;
                }
                else
                {
                    LimpaTextBox(textBoxCodigo);
                    throw new FormatException("Digite apenas números válidos.");
                }

                //                  DESCRIÇÃO TURMA
                if (textBoxDescricao.Text.Length > 0)
                {
                    turmaFiltro.DescricaoTurma = textBoxDescricao.Text;
                }
                else
                {
                    turmaFiltro.DescricaoTurma = "";
                }

                //Tá dando erro pq RNTurma ainda não tá pronto
                Servico servico = new Servico();
                listaTurma = servico.ListarTurma(turmaFiltro);

                if (listaTurma.Count > 0)
                {
                    foreach (Turma t in listaTurma)
                    {
                        ListViewItem linha = listViewTurma.Items.Add(t.CodigoTurma.ToString());
                        linha.SubItems.Add(t.DescricaoTurma);
                        linha.SubItems.Add(Convert.ToString(t.Turno));
                        linha.SubItems.Add(Convert.ToString(t.Ano));
                        linha.SubItems.Add(t.DataInicio.ToString());
                        linha.SubItems.Add(t.Ensino.DescricaoEnsino);
                    }
                }
                else
                {
                    MessageBox.Show("Sem resultados.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Old
        //    //try
        //    //{
        //    //    listViewTurmas.Items.Clear();

        //    //    Turma turma = new Turma();
        //    //    turma.CodigoTurma = 0;
        //    //    turma.DescricaoTurma = "";

        //    //    Servico servico = new Servico();

        //    //    //Tá dando erro pq RNTurma ainda não tá pronto
        //    //    listaTurma = servico.ListarTurma(turma);

        //    //    foreach (Turma t in listaTurma)
        //    //    {
        //    //        ListViewItem linha = listViewTurmas.Items.Add(t.CodigoTurma.ToString());
        //    //        linha.SubItems.Add(t.DescricaoTurma);
        //    //        linha.SubItems.Add(Convert.ToString(t.Turno));
        //    //        linha.SubItems.Add(Convert.ToString(t.Ano));
        //    //        linha.SubItems.Add(t.DataInicio);
        //    //        linha.SubItems.Add(t.Turma.DescricaoTurma);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}
        #endregion

        #endregion


        #endregion

        #region Botões

        #region Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CarregarListView();
        }

        #endregion

        #region Inserir

        private void novaTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
                //será possível chamar o método Consultar(); dessa tela.
                GUIInserirTurma guiInserirTurma = new GUIInserirTurma(this);
                guiInserirTurma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Alterar

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurma.SelectedItems;

                if (colecaoSelecionada.Count > 0)
                {
                    int codigoTurmaSelecionado = 0;

                    alterarTurma = new Turma();
                    daoEnsino = new DAOEnsino();
                    daoTurma = new DAOTurma();
                    Ensino ensino = new Ensino();
                    Ensino ensinoFiltro = new Ensino();

                    foreach (ListViewItem selecionado in colecaoSelecionada)
                    {
                        codigoTurmaSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
                        foreach (Turma turma in listaTurma)
                        {
                            if (turma.CodigoTurma == codigoTurmaSelecionado)
                            {
                                alterarTurma = turma;
                            }
                        }
                    }

                    GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma(alterarTurma, this);
                    guiAlterarTurma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione a Turma que deseja Alterar.");
                }

                /*
                                ensino.DescricaoEnsino = alterarTurma.Ensino.DescricaoEnsino;
                                listaEnsino = daoEnsino.Listar(ensino);
                                foreach (Ensino ensino2 in listaEnsino)
                                {
                                    ensino = ensino2;
                                }

                                GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma(alterarTurma, this);
                                guiAlterarTurma.ShowDialog();
                                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Remover

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurma.SelectedItems;

                if (colecaoSelecionada.Count > 0)
                {
                    Turma removerTurma = new Turma();

                    //Percorrendo a coleção(a série selecionada)
                    foreach (ListViewItem selecionado in colecaoSelecionada)
                    {
                        removerTurma.CodigoTurma = Convert.ToInt32(selecionado.SubItems[0].Text);
                        if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Turma.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DAOTurma daoTurma = new DAOTurma();
                            daoTurma.Excluir(removerTurma);

                            listViewTurma.Items.Remove(selecionado);
                            MessageBox.Show("Turma removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Cancelado.", "Remoção de Turma");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Turma que deseja Remover.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }

        #endregion

        #region Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #endregion
    }
}
