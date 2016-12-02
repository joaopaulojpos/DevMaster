using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Aula;
using GUI.localhost;

namespace GUI
{
    public partial class GUIAula : Form
    {
        Service1 servico;
        List<GUI.localhost.Aula> listaAulas;
        public GUIAula()
        {
            InitializeComponent();
            servico = new Service1();
            carregarAulas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void carregarAulas()
        {
            try
            {
                GUI.localhost.Aula aula = new GUI.localhost.Aula();
                listViewAulas.Items.Clear();
                aula.CodigoAula = 0;
                aula.Data = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Disciplina disciplina = new Disciplina();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                disciplina.NomeDisciplina = "";
                Turma t = new Turma();
                t.CodigoTurma = 0;
                dt.Disciplina = disciplina;
                aluno.Turma = t;
                dt.Turma = t;
                aula.DisciplinaTurma = dt;

                listaAulas = servico.ListarAula(aula).ToList();
                if (listaAulas.Count > 0)
                {
                    foreach(GUI.localhost.Aula a in listaAulas)
                    {
                        ListViewItem linha = listViewAulas.Items.Add(Convert.ToString(a.Data));
                        linha.SubItems.Add(a.DisciplinaTurma.Turma.DescricaoTurma);
                        linha.SubItems.Add(a.DisciplinaTurma.Turma.Turno);
                        linha.SubItems.Add(a.DisciplinaTurma.Disciplina.NomeDisciplina);
                        linha.SubItems.Add(a.Assunto);
                    }
                }
                else
                {
                    MessageBox.Show("Sem resultados!.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirAula gui = new GUIInserirAula();
            gui.ShowDialog();
        }
    }
}
