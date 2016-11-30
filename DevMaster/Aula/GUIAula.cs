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
using WebService;
using GUI.Aula;

namespace GUI
{
    public partial class GUIAula : Form
    {
        Servico servico;
        List<Biblioteca.Basicas.Aula> listaAulas;
        public GUIAula()
        {
            InitializeComponent();
            servico = new Servico();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void carregarAulas()
        {
            try
            {
                Biblioteca.Basicas.Aula aula = new Biblioteca.Basicas.Aula();
                listViewAulas.Items.Clear();
                aula.CodigoAula = 0;
                aula.Data = "";

                listaAulas = servico.ListarAula(aula);
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
