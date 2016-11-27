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
using Biblioteca.RN;
using Biblioteca.DAO;
using WebService;

namespace GUI
{
    public partial class GUIUsuario : Form
    {
        #region Atributos

        List<Usuario> listaUsuario;
        int filtroCodigo;

        #endregion

        #region Construtor

        public GUIUsuario()
        {
            InitializeComponent();
            CarregarListView();
            listViewUsuario.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewUsuario.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        #region TextBoxCodigo

        //Métodos para ajudarem na validação de textBoxCodigo
        public void TirarZeroTextBoxCodigo()
        {
            if (textBoxCodigo.Text == "0")
            {
                LimpaTextBoxCodigo();
            }
        }

        public void LimpaTextBoxCodigo()
        {
            textBoxCodigo.Text = "";
        }

        public void ZeraTextBoxCod()
        {
            if (textBoxCodigo.Text == "")
            {
                textBoxCodigo.Text = "0";
            }
        }

        #endregion

        #region Carrega List View

        public void CarregarListView()
        {
            try
            {
                //Limpando a List View
                listViewUsuario.Items.Clear();

                Usuario usuarioFiltro = new Usuario();
                DAOUsuario daoUsuario = new DAOUsuario();

                //                  CÓDIGO TIPO DE USUÁRIO
                ZeraTextBoxCod();
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo))
                {
                    TirarZeroTextBoxCodigo(); 
                    usuarioFiltro.CodUsuario = filtroCodigo;
                }
                else
                {
                    LimpaTextBoxCodigo();
                    throw new FormatException("Digite apenas números válidos.");
                }


                //                  DESCRIÇÃO TIPO DE USUÁRIO
                usuarioFiltro.Nome = textBoxNome.Text;

                listaUsuario = daoUsuario.Listar(usuarioFiltro);

                if (listaUsuario.Count > 0)
                {
                    foreach (Usuario usuario in listaUsuario)
                    {
                        ListViewItem linha = listViewUsuario.Items.Add(Convert.ToString(usuario.CodUsuario));
                        linha.SubItems.Add(usuario.LoginUsuario);
                        linha.SubItems.Add(usuario.Nome);
                        linha.SubItems.Add(usuario.Telefone);
                        linha.SubItems.Add(usuario.TipoUsuario.DescricaoTipoUsuario);
                    }
                }
                else
                {
                    MessageBox.Show("Sem resultados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Botão Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CarregarListView();
        }

        #endregion

        #region Botão Alterar

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Botão Remover

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Botão Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Outros

        #endregion

        
    }
}
