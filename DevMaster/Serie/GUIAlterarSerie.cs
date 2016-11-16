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
    public partial class GUIAlterarSerie : Form
    {
        #region Atributos

        Serie serieAlterada;

        #endregion

        #region Construtores

        public GUIAlterarSerie(Serie serieOld)
        {
            InitializeComponent();

            serieAlterada = serieOld;

            AlimentarCampos(serieOld);
        }

        #endregion

        #region Métodos Auxiliares

        void AlimentarCampos(Serie serie)
        {
            textBoxDescricaoSerie.Text = serie.DescricaoSerie;
        }

        #endregion

        #region Voltar

        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Alterar

        private void btnAlterarClick(object sender, EventArgs e)
        {
            serieAlterada.DescricaoSerie = textBoxDescricaoSerie.Text;

            DAOSerie.Instancia.Alterar(serieAlterada);
            MessageBox.Show("Série alterada com sucesso!");
        }

        #endregion

        #region Outros

        private void GUIAlterarSerie_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
