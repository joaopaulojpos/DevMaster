using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Basicas; //Só pra testar
using Biblioteca.RN;
using Biblioteca.DAO;  

namespace GUI
{
    public partial class GUITipoUsuario : Form
    {
        #region Atributos

        List<TipoUsuario> listaTipoUsuario;

        #endregion

        #region Construtores

        //Padrão
        public GUITipoUsuario()
        {
            InitializeComponent();
            Consultar();
        }

        #endregion

        #region Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        #endregion

        #region Métodos Auxiliares

        public void Consultar()
        {
            try
            {
                listViewTipoUsuarios.Items.Clear();

                string filtro = textBoxFiltro.Text;

                TipoUsuario tipoUsuarioFiltro = new TipoUsuario();
                tipoUsuarioFiltro.DescricaoTipoUsuario = filtro;
                DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();

                listaTipoUsuario = daoTipoUsuario.Listar(tipoUsuarioFiltro);

                foreach (TipoUsuario tipoUsuario in listaTipoUsuario)
                {
                    ListViewItem linha = listViewTipoUsuarios.Items.Add(Convert.ToString(tipoUsuario.CodTipoUsuario));
                    linha.SubItems.Add(tipoUsuario.DescricaoTipoUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Outros

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            GUIAlterarTipoUsuario guiAlterarTipoUsuario = new GUIAlterarTipoUsuario();
            guiAlterarTipoUsuario.ShowDialog();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTipoUsuario guiInserirTipoUsuario = new GUIInserirTipoUsuario();
            guiInserirTipoUsuario.ShowDialog();
        }

        #endregion
    }
}
