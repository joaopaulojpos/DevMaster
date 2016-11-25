using Biblioteca.Basicas;
using Biblioteca.DAO;
using Biblioteca.RN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WebService.localhost1;

namespace GUI
{
    public partial class GUIAluno : Form
    {
        #region Atributos 

        private RNAluno rn;
        List<Aluno> listaAluno;
        //private Servico servico;

        #endregion

        #region Construtores

        public GUIAluno()
        {
            InitializeComponent();
            
            //rn = new RNAluno();
            //OLD servico = new Servico();
            CarregarListView();

            //Faz com que as colunas da List View ocupem o espaço que precisar sem cortar
            listViewAluno.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewAluno.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        #region TextBoxCodigo

        //Métodos para ajudarem na validação de textBoxCodigo
        public void TirarZeroTextBoxCodigo()
        {
            if (textBoxMatricula.Text == "0")
            {
                LimpaTextBoxCodigo();
            }
        }

        public void LimpaTextBoxCodigo()
        {
            textBoxMatricula.Text = "";
        }

        public void ZeraTextBoxCod()
        {
            if (textBoxMatricula.Text == "")
            {
                textBoxMatricula.Text = "0";
            }
        }

        #endregion

        #region Carregar List View

        #region OLD

        //public void carregarListAluno()
        //{
        //    try
        //    {
        //        listViewAlunos.Items.Clear();
        //        Aluno aluno = new Aluno();
        //        aluno.Matricula = "";
        //        aluno.Nome = "";
        //        foreach (Aluno a in servico.ListarAluno(aluno))
        //        {
        //            ListViewItem row = listViewAlunos.Items.Add(a.Matricula);
        //            row.SubItems.Add(a.Nome);
        //            row.SubItems.Add(a.Sexo);
        //            row.SubItems.Add(a.Telefone);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        #endregion

        #region Direto na DAO

        public void CarregarListView()
        {
            try
            {
                //Limpando a List View
                listViewAluno.Items.Clear();

                Aluno alunoFiltro = new Aluno();
                DAOAluno daoAluno = new DAOAluno();

                //                  MATRÍCULA ALUNO
                alunoFiltro.Matricula = textBoxMatricula.Text;


                //                  DESCRIÇÃO TIPO DE USUÁRIO
                alunoFiltro.Nome = textBoxNome.Text;

                listaAluno = daoAluno.Listar(alunoFiltro);

                if (listaAluno.Count > 0)
                {
                    foreach (Aluno aluno in listaAluno)
                    {
                        ListViewItem linha = listViewAluno.Items.Add(aluno.Matricula);
                        linha.SubItems.Add(aluno.Nome);
                        linha.SubItems.Add(aluno.Sexo);
                        linha.SubItems.Add(aluno.Telefone);
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

        #endregion

        #region Botão Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CarregarListView();
        }

        #endregion

        #region Menu Inserir

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //O parâmetro this é essa própria tela, com isso lá na tela de Inserir 
                //será possível chamar o método Consultar(); dessa tela.
                GUIInserirAluno guiInserirAluno = new GUIInserirAluno(this);
                guiInserirAluno.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Botão Alterar

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno alunoSelecionado = new Aluno();
                string matriculaSelecionada = "";

                //Pega o Ensino selecionado, mesmo que só seja um ele entende como uma coleção
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewAluno.SelectedItems;
                //Percorrendo a coleção(a série selecionada)
                foreach (ListViewItem itemSelecionado in colecaoSelecionada)
                {
                    matriculaSelecionada = itemSelecionado.SubItems[0].Text;
                }

                foreach (Aluno aluno in listaAluno)
                {
                    if (aluno.Matricula == matriculaSelecionada)
                    {
                        alunoSelecionado = aluno;
                    }
                }

                //Enviando a série a ser alterada pra tela de Alterar:
                //O parâmetro this é essa própria tela, com isso lá na tela de Alterar 
                //será possível chamar o método Consultar(); dessa tela.
                GUIAlterarAluno guiAlterarAluno = new GUIAlterarAluno(alunoSelecionado, this);
                guiAlterarAluno.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }

        #endregion

        #region Botão Remover

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewAluno.SelectedItems;

                Ensino removerEnsino = new Ensino();

                //Percorrendo a coleção(a série selecionada)
                foreach (ListViewItem selecionado in colecaoSelecionada)
                {
                    removerEnsino.CodigoEnsino = Convert.ToInt32(selecionado.SubItems[0].Text);
                    if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Ensino.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RNEnsino rnEnsino = new RNEnsino();
                        rnEnsino.Excluir(removerEnsino);

                        listViewAluno.Items.Remove(selecionado);
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

        #region Botão Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Outros


        #endregion

    }
}
