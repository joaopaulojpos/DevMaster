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
        int filtroAno;
        DateTime filtroDataInicio;

        #endregion

        #region Construtores

        //Padrão
        public GUITurma()
        {
            InitializeComponent();
            //listViewTurmas
            //Comentei por enquanto
            //Consultar();
            //Comentei por enquanto
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

        public void Consultar()
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
            //        linha.SubItems.Add(t.Ensino.DescricaoEnsino);
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
                Ensino ensinoFiltro = new Ensino();
                DAOTurma daoTurma = new DAOTurma();

                //                  CÓDIGO TURMA
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

                //                  ANO
                ZeraTextBox(textBoxAno);
                if (int.TryParse(textBoxAno.Text, out filtroAno))
                {
                    TirarZeroTextBox(textBoxAno);
                    turmaFiltro.Ano = filtroAno;
                }
                else
                {
                    LimpaTextBox(textBoxAno);
                    throw new FormatException("Digite apenas números válidos.");
                }

                //                  TURNO
                turmaFiltro.Turno = textBoxTurno.Text;

                //                  DATA INÍCIO
                
                ZeraTextBox(textBoxDataInicio);
                if (DateTime.TryParse(textBoxDataInicio.Text, out filtroDataInicio))
                {
                    TirarZeroTextBox(textBoxDataInicio);
                    turmaFiltro.DataInicio = Convert.ToDateTime(textBoxDataInicio.Text);
                }
                else
                {
                    LimpaTextBox(textBoxDataInicio);
                    throw new FormatException("Digite uma data válida.");
                }
                //                  ENSINO
                ensinoFiltro.DescricaoEnsino = textBoxEnsino.Text;
                turmaFiltro.Ensino = ensinoFiltro;

                //                  DESCRIÇÃO TURMA
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
                        //linha.SubItems.Add(turma.DataInicio.ToShortDateString);
                        linha.SubItems.Add(turma.Ensino.DescricaoEnsino);
                        //MessageBox.Show(turma.DataInicio.ToShortDateString);
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

        #region Botões

        #region Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
                //Consultar();
        }

        #endregion

        #region Inserir

        private void novaTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTurma guiInserirTurma = new GUIInserirTurma();
            guiInserirTurma.ShowDialog();
        }

        #endregion

        #region Alterar

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurma.SelectedItems;

            Turma alterarTurma = new Turma();
            int codigoSelecionado = 0;

            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                codigoSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
            }

            foreach (Turma turma in listaTurma)
            {
                if (turma.CodigoTurma == codigoSelecionado)
                {
                    alterarTurma = turma;
                }
            }

            GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma(alterarTurma, this);
            guiAlterarTurma.ShowDialog();
        }

        #endregion

        #region Remover

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurma.SelectedItems;

            Turma removerTurma = new Turma();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                removerTurma.CodigoTurma = Convert.ToInt32(selecionado.SubItems[0].Text);

                if (MessageBox.Show("Tem certeza?", "Confirmar remoção da Turma.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DAOTurma rnTurma = new DAOTurma();
                    rnTurma.Excluir(removerTurma);

                    listViewTurma.Items.Remove(selecionado);
                }
                else
                {
                    MessageBox.Show("Cancelado.", "Remoção da Turma.");
                }
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
