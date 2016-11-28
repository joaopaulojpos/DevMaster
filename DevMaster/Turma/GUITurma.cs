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

        DAOEnsino daoEnsino;
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
            #region Old
            //try
            //{
            //    listViewTurmas.Items.Clear();

            //    Turma turma = new Turma();
            //    turma.CodigoTurma = 0;
            //    turma.DescricaoTurma = "";

            //    Servico servico = new Servico();

            //    //Tá dando erro pq RNTurma ainda não tá pronto
            //    listaTurma = servico.ListarTurma(turma);

            //    foreach (Turma t in listaTurma)
            //    {
            //        ListViewItem linha = listViewTurmas.Items.Add(t.CodigoTurma.ToString());
            //        linha.SubItems.Add(t.DescricaoTurma);
            //        linha.SubItems.Add(Convert.ToString(t.Turno));
            //        linha.SubItems.Add(Convert.ToString(t.Ano));
            //        linha.SubItems.Add(t.DataInicio);
            //        linha.SubItems.Add(t.Turma.DescricaoTurma);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            #endregion
            try
            {
                listViewTurma.Items.Clear();

                Turma turmaFiltro = new Turma();
                Turma ensinoFiltro = new Turma();
                DAOTurma daoTurma = new DAOTurma();

                //                  CÓDIGO TURMA FILTRO
                ZeraTextBox(textBoxCodigo);
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo)) //Ele valida o primeiro param e se for inteiro, joga o valor pra o segundo param, nesse caso filtroCodigo
                {
                    TirarZeroTextBox(textBoxCodigo); //Só pra não ficar o número zero 0 lá no textbox, perfumaria...
                    turmaFiltro.CodigoTurma = filtroCodigo;
                }
                else
                {
                    LimpaTextBox(textBoxCodigo);
                    throw new FormatException("Digite apenas números válidos.");
                }

                //                  DESCRIÇÃO TURMA FILTRO
                //Alimentando os campos num Objeto pra mandar pra DAO Pesquisar
                turmaFiltro.DescricaoTurma = textBoxDescricao.Text;

                listaTurma = daoTurma.Listar(turmaFiltro);

                if (listaTurma.Count > 0)
                {
                    foreach (Turma turma in listaTurma)
                    {
                        ListViewItem linha = listViewTurma.Items.Add(Convert.ToString(turma.CodigoTurma));
                        linha.SubItems.Add(turma.DescricaoTurma);
                        linha.SubItems.Add(turma.Turno);
                        linha.SubItems.Add(Convert.ToString(turma.Ano));
                        linha.SubItems.Add(Convert.ToString(turma.DataInicio.ToShortDateString()));
                        linha.SubItems.Add(turma.Ensino.DescricaoEnsino);
                        MessageBox.Show(turma.Ensino.DescricaoEnsino + turma.Ensino.CodigoEnsino);
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
                Turma alterarTurma = new Turma();
                daoEnsino = new DAOEnsino();
                Ensino ensino = new Ensino();
                Ensino ensinoFiltro = new Ensino();

                int codigoTurmaSelecionado = 0;

                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurma.SelectedItems;
                foreach (ListViewItem selecionado in colecaoSelecionada)
                {
                    codigoTurmaSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
                }

                foreach (Turma turma in listaTurma)
                {
                    if (turma.CodigoTurma == codigoTurmaSelecionado)
                    {
                        alterarTurma = turma;
                    }
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
