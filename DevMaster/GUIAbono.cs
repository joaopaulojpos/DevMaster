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
    public partial class GUIAbono : Form
    {

        private Servico servico;
        private List<Turma> listaTurmas;
        private List<Aluno> listaAlunos;
        private List<Biblioteca.Basicas.Aula> listaAulas;
        
        public GUIAbono()
        {
            InitializeComponent();


            servico = new Servico();
            carregarTurmas();
        }

        private void carregarAlunos(Aluno aln)
        {
            try
            {
                comboBox3.Items.Clear();
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
                        comboBox3.Items.Add(a.Nome);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                al.Data = dateTimePicker1.Value;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                comboBox3.Items.Clear();
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
                al.Data = dateTimePicker1.Value;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                comboBox3.Items.Clear();
            }
        }
    }
}
