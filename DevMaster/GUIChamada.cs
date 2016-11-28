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
    public partial class GUIChamada : Form
    {
        private Servico servico;
        private List<Turma> listaTurmas;
        private List<Aluno> listaAlunos;
        private List<Biblioteca.Basicas.Aula> listaAulas;
        public GUIChamada()
        {
            InitializeComponent();
            servico = new Servico();
            carregarTurmas();
        }
        private void carregarAlunos(Aluno aln)
        {
            try
            {
                checkedListBoxAlunos.Items.Clear();
                Aluno aluno = new Aluno();
                Turma t = new Turma();
                t.CodigoTurma = 0;
                aluno.Turma = t;
                aluno.Matricula = "";
                aluno.Nome = "";
                listaAlunos = servico.ListarAluno(aln);
                if (listaAlunos.Count > 0)
                {
                    foreach (Aluno a in listaAlunos)
                    {
                        checkedListBoxAlunos.Items.Add(a.Nome);
                    }
                }else
                {
                    MessageBox.Show("Sem resultados.");
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
                comboBox1.Items.Clear();
                comboBox1.Items.Add("");
                Turma turma = new Turma();
                turma.CodigoTurma = 0;
                listaTurmas = servico.ListarTurma(turma);
                foreach (Turma t in listaTurmas)
                {
                    comboBox1.Items.Add(t.DescricaoTurma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarAulas(Biblioteca.Basicas.Aula aula)
        {
            try
            {
                comboBox2.Items.Clear();
                
                listaAulas = servico.ListarAula(aula);
                foreach (Biblioteca.Basicas.Aula al in listaAulas)
                {
                    comboBox2.Items.Add(al.Assunto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno();

                Biblioteca.Basicas.Aula aula = new Biblioteca.Basicas.Aula();
                Falta falta = new Falta();
                int indexA = comboBox2.SelectedIndex;
                foreach(int c in checkedListBoxAlunos.CheckedIndices)
                {
                    int indexAl = Int32.Parse(c.ToString());
                    aluno = listaAlunos[indexAl];
                    aula = listaAulas[indexA];
                    falta.Data = dateTimePicker1.Text;
                    falta.Aluno = aluno;
                    falta.Aula = aula;
                    falta.Abono = false;
                    falta.Motivo = "";
                    servico.InserirFalta(falta);
                }
                MessageBox.Show("Chamada registrada.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GUIChamada_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
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
        }
    }
}