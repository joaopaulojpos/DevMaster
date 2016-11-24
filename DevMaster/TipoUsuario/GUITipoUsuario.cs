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

namespace GUI
{
    public partial class GUITipoUsuario : Form
    {
        #region Atributos

        List<TipoUsuario> listaTipoUsuario;

        string filtroTipo;
        int filtroCodigo;

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

        #region Consultar

        public void Consultar()
        {
            try
            {
                //Limpando a List View
                listViewTipoUsuarios.Items.Clear();

                TipoUsuario tipoUsuarioFiltro = new TipoUsuario();
                DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();

                //                  CÓDIGO TIPO DE USUÁRIO
                //Pro TryParse um textbox vazio = "" mas ai iria dar erro, q não é o nosso caso, então quando o textbox for "" vai virar "0" e assim não vai dar erro.
                ZeraTextBoxCod();
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo)) //Ele valida o primeiro param e se for inteiro, joga o valor pra o segundo param, nesse caso filtroCodigo
                {
                    TirarZeroTextBoxCodigo(); //Só pra não ficar o número zero 0 lá no textbox, perfumaria...
                    tipoUsuarioFiltro.CodTipoUsuario = filtroCodigo;
                }
                else
                {
                    LimpaTextBoxCodigo();
                    throw new FormatException("Digite apenas números válidos.");
                }
                

                //                  DESCRIÇÃO TIPO DE USUÁRIO
                filtroTipo = textBoxTipo.Text;
                //Alimentando os campos num Objeto pra mandar pra DAO Pesquisar
                tipoUsuarioFiltro.DescricaoTipoUsuario = filtroTipo;

                listaTipoUsuario = daoTipoUsuario.Listar(tipoUsuarioFiltro);

                if (listaTipoUsuario.Count > 0)
                {
                    foreach (TipoUsuario tipoUsuario in listaTipoUsuario)
                    {
                        ListViewItem linha = listViewTipoUsuarios.Items.Add(Convert.ToString(tipoUsuario.CodTipoUsuario));
                        linha.SubItems.Add(tipoUsuario.DescricaoTipoUsuario);
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

        #region Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
