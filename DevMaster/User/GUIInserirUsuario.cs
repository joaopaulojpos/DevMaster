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
        GUIUsuario guiUsuario;
        List<TipoUsuario> listaTipoUsuario;

        #endregion

        #region Construtor

        public GUIInserirUsuario(GUIUsuario guiUsuario)
        {
            InitializeComponent();
            this.guiUsuario = guiUsuario;
            //servico = new Servico();
            AlimentarComboTipoUsuario();
        }

        #endregion

        #region Métodos Auxiliares

        private void Inserir()
        {
            try
            {
                //servico = new Servico();
                Usuario usuario = new Usuario();
                TipoUsuario tipoUsuarioFiltro = new TipoUsuario();
                TipoUsuario tipoUsuario = new TipoUsuario();

                usuario.LoginUsuario = textBoxLogin.Text;
                usuario.Nome = textBoxNome.Text;
                usuario.Senha = textBoxSenha.Text;
                usuario.Telefone = textBoxTelefone.Text;

                tipoUsuarioFiltro.DescricaoTipoUsuario = comboBoxTipoUsuario.Text;
                listaTipoUsuario = servico.ListarTipoUsuario(tipoUsuarioFiltro);
                foreach (TipoUsuario tipoU in listaTipoUsuario)
                {
                    tipoUsuario.DescricaoTipoUsuario = tipoU.DescricaoTipoUsuario;
                    tipoUsuario.CodTipoUsuario = tipoU.CodTipoUsuario; 
                }
                usuario.TipoUsuario = tipoUsuario;

                servico.InserirUsuario(usuario);
                MessageBox.Show("Turma inserida com sucesso!");
                this.guiUsuario.CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlimentarComboTipoUsuario()
        {
            comboBoxTipoUsuario.Items.Add("Coordenador");
            comboBoxTipoUsuario.Items.Add("Professor");
            comboBoxTipoUsuario.Items.Add("Secretaria");
            comboBoxTipoUsuario.SelectedIndex = 0;
        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Inserir();
        }

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
