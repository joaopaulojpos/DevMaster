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

namespace GUI.User
{
    public partial class GUIInserirUsuario : Form
    {

        #region Atributos

        Servico servico;

        #endregion

        #region Construtor

        public GUIInserirUsuario()
        {
            InitializeComponent();
            servico = new Servico();
        }

        #endregion

        #region Botão Concluir


        #endregion

        #region Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
