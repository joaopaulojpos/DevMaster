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
    public partial class GUIInserirAluno : Form
    {
        GUIAluno guiAluno;

        public GUIInserirAluno()
        {
            InitializeComponent();
        }

        public GUIInserirAluno(GUIAluno guiAluno)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DAOAluno dao = new DAOAluno();
                RNAluno rn = new RNAluno();
                Aluno a = new Aluno();
                Turma t = new Turma();
                a.Matricula = textBox1.Text;
                a.Nome = textBox2.Text;
                a.DataNasc = Convert.ToDateTime(dateNascimento);
                a.Sexo = "M";
                a.Telefone = textBox4.Text;
                t.CodigoTurma = 1;
                a.Turma = t;
                rn.inserir(a);
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
