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
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUIChamada : Form
    {
        #region Atributos

        private Servico servico;
        private List<Turma> listaTurmas;
        private List<Aluno> listaAlunos;
        private List<Disciplina> listaDisciplinas;
        private List<Disciplina_Turma> listaDisciplinaTurma;
        private List<Aula> listaAulas;


        #endregion

        #region Construtor

        public GUIChamada()
        {
            InitializeComponent();
            servico = new Servico();
            AlimentarComboTurma();
            AlimentarComboDisciplina();
        }

        #endregion

        #region Métodos Auxiliares

        #region Alimentar ComboBox Disciplina

        private void AlimentarComboDisciplina()
        {
            try
            {
                comboBoxDisciplina.Items.Clear();
                Disciplina disciplinaFiltro = new Disciplina();
                disciplinaFiltro.CodigoDisciplina = 0;
                listaDisciplinas = servico.ListarDisciplina(disciplinaFiltro);
                foreach (Disciplina dis in listaDisciplinas)
                {
                    comboBoxDisciplina.Items.Add(dis.NomeDisciplina);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //Quando mudar a Disciplina muda a aula
        #region Combobox Disciplina Change

        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDisciplina.Text != String.Empty)
                {
                    AlimentarComboAulas(listaDisciplinas.ElementAt(comboBoxDisciplina.SelectedIndex));
                }
                else
                {
                    MessageBox.Show("fdsa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Alimentar ComboBox Turma

        private void AlimentarComboTurma()
        {
            try
            {
                comboBoxTurma.Items.Clear();
                Turma turmaFiltro = new Turma();
                turmaFiltro.CodigoTurma = 0;
                listaTurmas = servico.ListarTurma(turmaFiltro);
                foreach (Turma turma in listaTurmas)
                {
                    comboBoxTurma.Items.Add(turma.DescricaoTurma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //Quando mudar a Turma, muda a lista de alunos
        #region ComboBox Turma Change

        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTurma.Text != String.Empty)
                {
                    AlimentarCheckedListAlunos(listaTurmas.ElementAt(comboBoxTurma.SelectedIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Alimentar Checked List Alunos

        private void AlimentarCheckedListAlunos(Turma turma)
        {
            #region OLD
            /* 
              int index = comboBox1.SelectedIndex;
            if (!comboBox1.Items[index].Equals(""))
            {
                Disciplina d = new Disciplina();
                d.NomeDisciplina = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index - 1].CodigoTurma;
                aluno.Turma = t;
                dt.Turma = t;
                dt.Disciplina = d;
                Biblioteca.Basicas.Aula al = new Biblioteca.Basicas.Aula();
                al.DisciplinaTurma = dt;
                al.Data = dateTimePicker1.Text;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                checkedListBoxAlunos.Items.Clear();
            }
             */

            #endregion

            try
            {
                checkedListBoxAlunos.Items.Clear();

                DAOParticipa daoParticipa = new DAOParticipa();
                listaAlunos = daoParticipa.ListarAlunos(turma);

                if (listaAlunos.Count > 0)
                {
                    foreach (Aluno a in listaAlunos)
                    {
                        checkedListBoxAlunos.Items.Add(a.Nome);
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

        #region Alimentar ComboBox Aula

        private void AlimentarComboAulas(Disciplina disciplinaTurma)
        {
            try
            {
                comboBoxAula.Items.Clear();

                DAOAula daoAula = new DAOAula();
                listaAulas = daoAula.ListarParaChamada(disciplinaTurma);
                //listaAulas = servico.ListarAula(disciplinaTurma);

                if (listaAulas.Count > 0)
                {
                    foreach (Aula a in listaAulas)
                    {
                        comboBoxAula.Items.Add(a.Assunto);
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

        #region Carregar Aulas

        private void carregarAulas(Disciplina_Turma disciplinaTurma)
        {
            try
            {
                comboBoxAula.Items.Clear();
                Aula aulaFiltro = new Aula();
                aulaFiltro.CodigoAula = 0;
                listaAulas = servico.ListarAula(aulaFiltro);
                foreach (Aula al in listaAulas)
                {
                    comboBoxAula.Items.Add(al.Assunto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Botão Finalizar Chamada

        private void btnFinalizarChamada_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                Aluno aluno = new Aluno();

                Biblioteca.Basicas.Aula aula = new Biblioteca.Basicas.Aula();
                Falta falta = new Falta();
                int indexA = comboBoxAula.SelectedIndex;
                foreach (int c in checkedListBoxAlunos.CheckedIndices)
                {
                    int indexAl = Int32.Parse(c.ToString());
                    aluno = listaAlunos[indexAl];
                    aula = listaAulas[indexA];
                    falta.Data = dateDia.Text;
                    falta.Aluno = aluno;
                    falta.Aula = aula;
                    falta.Abono = false;
                    falta.Motivo = "";
                    servico.InserirFalta(falta);
                }
                MessageBox.Show("Chamada registrada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        #endregion

        #region Data Change

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {/*
            int index = comboBoxTurma.SelectedIndex;
            if (!comboBoxTurma.Items[index].Equals(""))
            {
                Disciplina d = new Disciplina();
                d.NomeDisciplina = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index - 1].CodigoTurma;
                aluno.Turma = t;
                dt.Turma = t;
                dt.Disciplina = d;
                Biblioteca.Basicas.Aula al = new Biblioteca.Basicas.Aula();
                al.DisciplinaTurma = dt;
                al.Data = dateDia.Text;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                checkedListBoxAlunos.Items.Clear();
            }
            */
        }

        #endregion

        #region Botão Voltar

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GUIChamada_Load(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}