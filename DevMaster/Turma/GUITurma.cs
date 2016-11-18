using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Basicas;
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUITurma : Form
    {
        public GUITurma()
        {
            InitializeComponent();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTurma guiInserirTurma = new GUIInserirTurma();
            guiInserirTurma.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma();
            guiAlterarTurma.ShowDialog();
        }










        #region Atributos

        List<Turma> listaTurma;

        #endregion


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        #region Métodos Auxiliares

        public void Consultar()
        {
            listViewTurma.Items.Clear();

            string filtro = textBoxFiltro.Text;

            Turma turma2 = new Turma();
            turma2.DescricaoTurma = filtro;

            //listaEnsino = DAOEnsino.Instancia.Listar(ensino2);
            DAOTurma daoTurma = new DAOTurma();
            daoTurma.Listar(turma2);

            foreach (Turma turma in listaTurma)
            {
                //ListViewItem é tipo uma linha, e cada coluna é um subitem dessa linha/Item
                ListViewItem linha = listViewTurma.Items.Add(Convert.ToString(turma.CodigoTurma));
                linha.SubItems.Add(turma.DescricaoTurma);
            }
        }

        #endregion
    }
}
