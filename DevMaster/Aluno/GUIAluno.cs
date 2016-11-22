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

namespace GUI
{
    public partial class GUIAluno : Form
    {
        private RNAluno rn;
        public GUIAluno()
        {
            InitializeComponent();
            rn = new RNAluno();
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
                foreach (Aluno a in rn.listar(aluno))
                {
                    listViewAlunos.Items.Add(a.Nome);
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
                a.Matricula = "20160002";
                rn.excluir(a);
                MessageBox.Show("Excluido!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
