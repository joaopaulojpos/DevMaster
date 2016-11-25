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
            carregarAlunos();
            //carregarDisciplinas();
            carregarTurmas();
        }

        private void carregarAlunos()
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                listaAlunos = servico.ListarAluno(aluno);
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
                Disciplina disc = new Disciplina();
                disc.CodigoDisciplina = 0;
                disc.NomeDisciplina = "";
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
                Turma turma = new Turma();
                turma.CodigoTurma = 0;
                turma.DataInicio = "";
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
            Disciplina_Turma dt = new Disciplina_Turma();
            Disciplina disciplina = new Disciplina();
            disciplina.NomeDisciplina = "";
            Turma t = new Turma();
            int index = comboBoxTurma.SelectedIndex;
            t.DescricaoTurma = comboBoxTurma.Items[index].ToString();

            carregarDisciplinas(dt);
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

        }
    }
}
