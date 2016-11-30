
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

namespace GUI.DisciplinaTurma
{
    public partial class GUIDisciplinaTurma : Form
    {
        Servico servico;
        private int codigoTurma;
        private List<Disciplina> listaDisciplina;
        public GUIDisciplinaTurma()
        {
            InitializeComponent();
            servico = new Servico();
            carregarDisciplinas();
        }
        public GUIDisciplinaTurma(int codigoTurma)
        {
            InitializeComponent();
            this.codigoTurma = codigoTurma;
            servico = new Servico();
            carregarDisciplinas();
        }

        private void carregarDisciplinas()
        {
            try
            {
                Disciplina d = new Disciplina();
                d.CodigoDisciplina = 0;
                checkedListBoxDisciplinas.Items.Clear();
                listaDisciplina= servico.ListarDisciplina(d);
                foreach (Disciplina disc in listaDisciplina)
                {
                    checkedListBoxDisciplinas.Items.Add(disc.NomeDisciplina);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region
        private void buttonRight_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int c in checkedListBoxDisciplinas.CheckedIndices)
                {
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Turma t = new Turma();
                    t.CodigoTurma = this.codigoTurma;
                    Disciplina d = new Disciplina();
                    int index = Int32.Parse(c.ToString());
                    d = listaDisciplina[index];
                    dt.Disciplina = d;
                    Usuario u = new Usuario();
                    u.CodUsuario = 2;
                    dt.Usuario = u;
                    dt.Turma = t;
                    servico.InserirDisciplinaTurma(dt);
                }
                MessageBox.Show("Disciplinas inseridas");
                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
