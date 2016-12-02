using GUI.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUIConsultarNota : Form
    {
        Service1 servico;
        List<Aluno> listaAlunos;
        List<Avaliacao> listaNotas;
        public GUIConsultarNota()
        {
            InitializeComponent();
            servico = new Service1();
            carregarAlunos();
        }

        private void carregarAlunos()
        {
            try
            {
                Aluno aluno = new Aluno();
                Turma t = new Turma();
                t.CodigoTurma = 0;
                aluno.Turma = t;
                aluno.Nome = "";
                aluno.Matricula = "";
                comboBoxNotas.Items.Clear();
                comboBoxNotas.Items.Add("");
                listaAlunos = servico.ListarAluno(aluno).ToList();
                foreach(Aluno a in listaAlunos)
                {
                    comboBoxNotas.Items.Add(a.Nome);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno();
                Disciplina_Turma dt = new Disciplina_Turma();
                Avaliacao avaliacao = new Avaliacao();
                Disciplina disc = new Disciplina();
                Turma t = new Turma();
                int indexA = comboBoxNotas.SelectedIndex;
                aluno = listaAlunos[indexA-1];
                avaliacao.Aluno = aluno;
                t.CodigoTurma = 0 ;
                dt.Turma = t;
                disc.NomeDisciplina = "";
                dt.Disciplina = disc;
                avaliacao.Disciplina_turma = dt;
                listView1.Items.Clear();
                listaNotas = servico.ListarAvaliacao(avaliacao).ToList();
                foreach (Avaliacao av in listaNotas)
                {
                    ListViewItem item = listView1.Items.Add(av.Aluno.Nome);
                    item.SubItems.Add(av.Descricao);
                    item.SubItems.Add(av.Disciplina_turma.Disciplina.NomeDisciplina);
                    item.SubItems.Add(Convert.ToString(av.Nota.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
