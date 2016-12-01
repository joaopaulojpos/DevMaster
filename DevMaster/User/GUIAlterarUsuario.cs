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
using Biblioteca.Basicas;

namespace GUI.User
{
    public partial class GUIAlterarUsuario : Form
    {

        #region Atributos

        GUIUsuario guiUsuario;
        Usuario usuario;
        Usuario novoUsuario;

        Servico servico;

        #endregion

        #region Construtor

        public GUIAlterarUsuario(Usuario usuario, GUIUsuario guiUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            AlimentarCampos();
            this.guiUsuario = guiUsuario;
        }

        #endregion

        #region Métodos Auxiliares

        private void AlimentarCampos()
        {
            comboBoxTipoUsuario.Items.Clear();
            textBoxNome.Text = usuario.Nome;
            textBoxLogin.Text = usuario.LoginUsuario;
            textBoxSenha.Text = usuario.Senha;
            textBoxTelefone.Text = usuario.Telefone;

            AlimentarComboTipoUsuario();
            comboBoxTipoUsuario.SelectedIndex = comboBoxTipoUsuario.FindStringExact(usuario.TipoUsuario.DescricaoTipoUsuario);

        }

        private void AlimentarComboTipoUsuario()
        {
            comboBoxTipoUsuario.Items.Add("Coordenador");
            comboBoxTipoUsuario.Items.Add("Professor");
            comboBoxTipoUsuario.Items.Add("Secretaria");
        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                novoUsuario = new Usuario();
                novoUsuario.CodUsuario = usuario.CodUsuario;
                novoUsuario.LoginUsuario = textBoxLogin.Text;
                novoUsuario.Nome = textBoxNome.Text;
                novoUsuario.Senha = textBoxSenha.Text;
                novoUsuario.Telefone = textBoxTelefone.Text;

                TipoUsuario tipoUsuario = new TipoUsuario();
                servico = new Servico();
                tipoUsuario.DescricaoTipoUsuario = comboBoxTipoUsuario.Text;
                List<TipoUsuario> listaTipoUsuario = new List<TipoUsuario>();

                listaTipoUsuario = servico.ListarTipoUsuario(tipoUsuario);
                foreach (TipoUsuario tipoUsuario2 in listaTipoUsuario)
                {
                    tipoUsuario.CodTipoUsuario = tipoUsuario2.CodTipoUsuario;
                    tipoUsuario.DescricaoTipoUsuario = tipoUsuario2.DescricaoTipoUsuario;
                }

                novoUsuario.TipoUsuario = tipoUsuario;

                servico.AlterarUsuario(novoUsuario);

                MessageBox.Show("Turma Alterada com sucesso!");

                guiUsuario.CarregarListView();
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


    }
}
