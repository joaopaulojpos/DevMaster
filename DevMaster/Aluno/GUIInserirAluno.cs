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
using WebService;

namespace GUI
{
    public partial class GUIInserirAluno : Form
    {
        #region Atributos

        GUIAluno guiAluno;
        List<Turma> listaTurma;
        Servico servico = new Servico();

        #endregion

        #region Construtores

        public GUIInserirAluno(GUIAluno guiAluno)
        {
            InitializeComponent();
            this.guiAluno = guiAluno;
            AlimentarComboSexo();
            AlimentarComboTurma();
        }

        #endregion

        #region Métodos Auxiliares

        #region Alimentar Campos

        void AlimentarComboTurma()
        {
            try
            {
                Turma turmaFiltro = new Turma();
                turmaFiltro.CodigoTurma = 0;
                turmaFiltro.DescricaoTurma = "";
                listaTurma = servico.ListarTurma(turmaFiltro);

                foreach (Turma turma in listaTurma)
                {
                    comboBoxTurma.Items.Add(turma.DescricaoTurma);
                }
                comboBoxTurma.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AlimentarComboSexo()
        {
            comboBoxSexo.Items.Clear();
            comboBoxSexo.Items.Add("M");
            comboBoxSexo.Items.Add("F");
            comboBoxSexo.SelectedIndex = 0;
        }

        #endregion

        #endregion

        #region Botão Concluir

        private void Concluir_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno a = new Aluno();
                a.Matricula = textBoxMatricula.Text;
                a.Nome = textBoxNome.Text;
                a.DataNasc = dateNascimento.Value;
                a.Sexo = comboBoxSexo.Items[comboBoxSexo.SelectedIndex].ToString();
                a.Telefone = textBoxTelefone.Text;

                Turma t = new Turma();
                t = listaTurma[comboBoxTurma.SelectedIndex];

                a.Turma = t;

                servico.InserirAluno(a);
                MessageBox.Show("Aluno Inserido com sucesso!");
                guiAluno.CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
