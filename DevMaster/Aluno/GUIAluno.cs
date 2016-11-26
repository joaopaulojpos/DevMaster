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
    public partial class GUIAluno : Form
    {
        private RNAluno rn;
        private Servico servico;
        public GUIAluno()
        {
            InitializeComponent();
            rn = new RNAluno();
            servico = new Servico();
            
            carregarListAluno();
        }

        public void carregarListAluno()
        {
            try
            {
                listViewAlunos.Items.Clear();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome="";
                foreach (Aluno a in servico.ListarAluno(aluno))
                {
                    ListViewItem row = listViewAlunos.Items.Add(a.Matricula);
                    row.SubItems.Add(a.Nome);
                    row.SubItems.Add(a.Sexo);
                    row.SubItems.Add(a.Telefone);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIAlterarAluno guiAlterarAluno = new GUIAlterarAluno();
            guiAlterarAluno.ShowDialog();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirAluno guiInserirAluno = new GUIInserirAluno();
            guiInserirAluno.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno a = new Aluno();
                //a.Matricula = listViewAlunos.GetItemAt(0,0).Text;
                //servico.ExcluirAluno(a);
                MessageBox.Show("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
