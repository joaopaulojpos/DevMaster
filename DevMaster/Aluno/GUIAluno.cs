using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebService;
using Biblioteca.Basicas;
using Biblioteca.RN;
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUIAluno : Form
    {
        #region Atributos 

        private RNAluno rn;
        List<Aluno> listaAluno;
        private Servico servico;

        #endregion

        #region Construtores

        public GUIAluno()
        {
            InitializeComponent();

            rn = new RNAluno();
            servico = new Servico();
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

        public void CarregarListView()
        {
            try
            {
                //Limpando a List View
                listViewAluno.Items.Clear();

                Aluno alunoFiltro = new Aluno();
                //DAOAluno daoAluno = new DAOAluno();

                //                  MATRÍCULA ALUNO
                alunoFiltro.Matricula = textBoxMatricula.Text;

                //                  DESCRIÇÃO TIPO DE USUÁRIO
                alunoFiltro.Nome = textBoxNome.Text;
                Turma t = new Turma();
                t.CodigoTurma = 0;
                alunoFiltro.Turma = t;
                //listaAluno = daoAluno.Listar(alunoFiltro);
                listaAluno = servico.ListarAluno(alunoFiltro);

                if (listaAluno.Count > 0)
                {
                    foreach (Aluno aluno in listaAluno)
                    {
                        ListViewItem linha = listViewAluno.Items.Add(aluno.Matricula);
                        linha.SubItems.Add(aluno.Nome);
                        linha.SubItems.Add(aluno.DataNasc.ToShortDateString());
                        linha.SubItems.Add(aluno.Sexo);
                        linha.SubItems.Add(aluno.Telefone);
                        linha.SubItems.Add(aluno.Turma.DescricaoTurma);
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

        #region Botão Excluir

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewAluno.SelectedItems;

                if (colecaoSelecionada.Count > 0)
                {

                    Aluno removerAluno = new Aluno();

                    //Percorrendo a coleção(a série selecionada)
                    foreach (ListViewItem selecionado in colecaoSelecionada)
                    {
                        removerAluno.Matricula = selecionado.SubItems[0].Text;
                        if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Aluno.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DAOAluno daoAluno = new DAOAluno();
                            daoAluno.Excluir(removerAluno);
                            //servico.Excluir(removerTurma);

                            listViewAluno.Items.Remove(selecionado);
                            MessageBox.Show("Aluno removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Cancelado.", "Remoção de Turma");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Aluno que deseja Excluir.");
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
