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
    public partial class GUIInserirAluno : Form
    {
        GUIAluno guiAluno;
        private List<Turma> listaTurmas;
        Servico servico = new Servico();
        public GUIInserirAluno()
        {
            InitializeComponent();
        }

        public GUIInserirAluno(GUIAluno guiAluno)
        {
            InitializeComponent();
            carregarTurmas();
        }

        private void carregarTurmas()
        {
            try{
                Turma t = new Turma();
                comboBox2.Items.Clear();
                t.CodigoTurma = 0;
                t.DescricaoTurma = "";
                listaTurmas = servico.ListarTurma(t);
                foreach(Turma tm in listaTurmas)
                {
                    comboBox2.Items.Add(tm.DescricaoTurma);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno a = new Aluno();
                Turma t = new Turma();
                a.Matricula = textBox1.Text;
                a.Nome = textBox2.Text;
                a.DataNasc = Convert.ToDateTime(dateNascimento);
                a.Sexo = comboBox1.Items[comboBox1.SelectedIndex].ToString() ;
                a.Telefone = textBox4.Text;
                t.CodigoTurma = listaTurmas[comboBox2.SelectedIndex].CodigoTurma;
                a.Turma = t;
                servico.InserirAluno(a);
                MessageBox.Show("Inserido!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
