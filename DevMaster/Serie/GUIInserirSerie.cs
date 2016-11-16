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
    public partial class GUIInserirSerie : Form
    {
        #region Construtores

        public GUIInserirSerie()
        {
            InitializeComponent();
        }

        #endregion

        #region Inserir

        private void btnInserirClick(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            serie.DescricaoSerie = textBoxDescricaoSerie.Text;
            DAOSerie.Instancia.Inserir(serie);
            MessageBox.Show("Série inserida com sucesso!");
            Consultar();
        }

        #endregion

        #region Voltar

        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void GUIInserirSerie_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
