using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GUI.User;
using Biblioteca.Basicas;
using WebService;


namespace GUI
{
    public partial class GUIUsuario : Form
    {
        #region Atributos

        List<Usuario> listaUsuario;
        int filtroCodigo;
        Servico servico;

        #endregion

        #region Construtor

        public GUIUsuario()
        {
            InitializeComponent();
            servico = new Servico();
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

                listaUsuario = servico.ListarUsuario(usuarioFiltro);

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
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewUsuario.SelectedItems;

            if (colecaoSelecionada.Count > 0)
            {
                int codigoUsuarioSelecionado = 0;

                Usuario alterarUsuario = new Usuario();
                TipoUsuario tipoUsuario = new TipoUsuario();
                TipoUsuario tipoUsuarioFiltro = new TipoUsuario();

                foreach (ListViewItem selecionado in colecaoSelecionada)
                {

                    codigoUsuarioSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
                    foreach (Usuario usuario in listaUsuario)
                    {
                        if (usuario.CodUsuario == codigoUsuarioSelecionado)
                        {
                            alterarUsuario = usuario;
                        }
                    }
                    GUIAlterarUsuario gui = new GUIAlterarUsuario(alterarUsuario, this);
                    gui.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Usuário que deseja Alterar.");
            }
        }

        #endregion

        #region Botão Remover

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //Botei btn_Excluir em vez de btnExcluir pq tava dando conflito com uma tentativa de outro botão com esse msm nome
            try
            {
                ListView.SelectedListViewItemCollection colecaoSelecionada = listViewUsuario.SelectedItems;

                if (colecaoSelecionada.Count > 0)
                {

                    Usuario removerUsuario = new Usuario();

                    //Percorrendo a coleção(a série selecionada)
                    foreach (ListViewItem selecionado in colecaoSelecionada)
                    {
                        removerUsuario.CodUsuario = Convert.ToInt32(selecionado.SubItems[0].Text);
                        if (MessageBox.Show("Tem certeza?", "Confirmar remoção do Usuário.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            servico.ExcluirUsuario(removerUsuario);

                            listViewUsuario.Items.Remove(selecionado);
                            MessageBox.Show("Usuário removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Cancelado.", "Remoção de Usuário");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Usuário que deseja Excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirUsuario gui = new GUIInserirUsuario(this);
            gui.ShowDialog();
        }
    }
}
