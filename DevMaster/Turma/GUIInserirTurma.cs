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
    public partial class GUIInserirTurma : Form
    {
        Servico servico = new Servico();
        List<Ensino> listaEnsino;
        public GUIInserirTurma()
        {
            InitializeComponent();
            carregarComboEnsino();
            carregarComboTurno();
        }

        private void carregarComboEnsino()
        {
            try
            {
                Ensino ensino = new Ensino();
                ensino.CodigoEnsino = 0;
                ensino.DescricaoEnsino = "";
                listaEnsino = servico.ListarEnsino(ensino);
                foreach (Ensino e in listaEnsino) {
                    comboBoxSerie.Items.Add(e.DescricaoEnsino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarComboTurno()
        {
            comboBoxTurno.Items.Add("M");
            comboBoxTurno.Items.Add("T");
            comboBoxTurno.Items.Add("N");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
