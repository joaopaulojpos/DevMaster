using Biblioteca.Basicas;
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
    public partial class GUIInserirAula : Form
    {
        Servico servico;
        List<Aluno> listaAlunos;
        List<Disciplina_Turma> listaDisciplinas;
        List<Turma> listaTurmas;

        public GUIInserirAula()
        {
            InitializeComponent();
            servico = new Servico();
            carregarTurmas();
        }

        private void carregarDisciplinas(Disciplina_Turma disciplina)
        {
            try
            {
                comboBoxDisciplina.Items.Clear();
                Disciplina disc = new Disciplina();
                disc.CodigoDisciplina = 0;
                disc.NomeDisciplina = "";
                disciplina.Disciplina = disc;
                listaDisciplinas = servico.ListarDisciplinaTurma(disciplina);
                foreach (Disciplina_Turma dt in listaDisciplinas)
                {
                    comboBoxDisciplina.Items.Add(dt.Disciplina.NomeDisciplina);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void carregarTurmas()
        {
            try
            {
                comboBoxTurma.Items.Clear();
                comboBoxTurma.Items.Add("");
                Turma turma = new Turma();
                turma.CodigoTurma = 0;
                listaTurmas = servico.ListarTurma(turma);
                foreach (Turma t in listaTurmas)
                {
                    comboBoxTurma.Items.Add(t.DescricaoTurma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            List<Disciplina_Turma> listaDT;
            try
            {
                Biblioteca.Basicas.Aula aula = new Biblioteca.Basicas.Aula();
                Turma t = new Turma();
                Disciplina d = new Disciplina();
                Disciplina_Turma dt = new Disciplina_Turma();
                int indexT = comboBoxTurma.SelectedIndex;
                int indexD = comboBoxDisciplina.SelectedIndex;
                t.CodigoTurma = listaTurmas[indexT-1].CodigoTurma;
                d= listaDisciplinas[indexD].Disciplina;
                dt.Disciplina = d;
                dt.Turma = t;
                listaDT = servico.ListarDisciplinaTurma(dt);
                dt.CodigoDisciplinaTurma = listaDT[0].CodigoDisciplinaTurma;
                aula.Assunto = textBoxAssunto.Text;
                aula.Data = dateTimePicker1.Text;
                aula.DisciplinaTurma = dt;
                servico.InserirAula(aula);
                MessageBox.Show("Aula Cadastrada.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTurma.SelectedIndex;
            if (!comboBoxTurma.Items[index].Equals(""))
            {
                Disciplina_Turma dt = new Disciplina_Turma();
                Disciplina disciplina = new Disciplina();
                disciplina.NomeDisciplina = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index - 1].CodigoTurma;
                dt.Disciplina = disciplina;
                dt.Turma = t;
                carregarDisciplinas(dt);
            }
            else
            {
                comboBoxDisciplina.Items.Clear();
            }
        }
    }
}
