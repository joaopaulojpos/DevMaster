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
    public partial class GUILancarNota : Form
    {
        List<Aluno> listaAlunos;
        List<Disciplina_Turma> listaDisciplinas;
        List<Turma> listaTurmas;
        Servico servico = new Servico();

        public GUILancarNota()
        {
            InitializeComponent();
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
                foreach (Aluno a in listaAlunos)
                {
                    comboBox3.Items.Add(a.Nome);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        private void carregarDisciplinas(Disciplina_Turma disciplina)
        {
            try
            {
                comboBox1.Items.Clear();
                Disciplina disc = new Disciplina();
                disc.CodigoDisciplina = 0;
                disc.NomeDisciplina = "";
                disciplina.Disciplina = disc;
                listaDisciplinas = servico.ListarDisciplinaTurma(disciplina);
                foreach (Disciplina_Turma dt in listaDisciplinas)
                {
                    comboBox1.Items.Add(dt.Disciplina.NomeDisciplina);
                }
            }catch(Exception ex)
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Disciplina_Turma> listaDT;
            try
            {
                Aluno aluno = new Aluno();
                Disciplina_Turma dt = new Disciplina_Turma();
                Avaliacao avaliacao = new Avaliacao();
                Disciplina disc = new Disciplina();
                Turma t = new Turma();
                int indexA = comboBox3.SelectedIndex;
                int indexT = comboBoxTurma.SelectedIndex;
                aluno.Matricula = listaAlunos[indexA].Matricula;
                avaliacao.Nota = Double.Parse(textBox1.Text);
                int indexD = comboBox2.SelectedIndex;
                avaliacao.Descricao = comboBox2.Items[indexD].ToString();
                avaliacao.Aluno = aluno;
                t.CodigoTurma = listaTurmas[indexT-1].CodigoTurma;
                dt.Turma = t;
                int indexDisc = comboBox1.SelectedIndex;
                disc = listaDisciplinas[indexDisc].Disciplina;
                dt.Disciplina = disc;
                listaDT = servico.ListarDisciplinaTurma(dt);
                dt.CodigoDisciplinaTurma = listaDT[0].CodigoDisciplinaTurma;
                avaliacao.Disciplina_turma = dt;
                
                    servico.InserirAvaliacao(avaliacao);
                    MessageBox.Show("Nota inserida.");
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxTurma_DropDownStyleChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTurma.SelectedIndex;
            if (!comboBoxTurma.Items[index].Equals(""))
            {
                Disciplina_Turma dt = new Disciplina_Turma();
                Disciplina disciplina = new Disciplina();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                disciplina.NomeDisciplina = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index-1].CodigoTurma;
                dt.Disciplina = disciplina;
                aluno.Turma = t;
                dt.Turma = t;
                carregarAlunos(aluno);
                carregarDisciplinas(dt);
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
            }
        }
    }
}