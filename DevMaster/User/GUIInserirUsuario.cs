using GUI.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI.User
{
    public partial class GUIInserirUsuario : Form
    {

        #region Atributos

        Service1 servico;
        GUIUsuario guiUsuario;
        List<TipoUsuario> listaTipoUsuario;

        #endregion

        #region Construtor

        public GUIInserirUsuario(GUIUsuario guiUsuario)
        {
            InitializeComponent();
            this.guiUsuario = guiUsuario;
            servico = new Service1();
            AlimentarComboTipoUsuario();
        }

        #endregion

        #region Métodos Auxiliares

        private void Inserir()
        {
            try
            {
                Usuario usuario = new Usuario();
                TipoUsuario tipoUsuario = new TipoUsuario();

                usuario.LoginUsuario = textBoxLogin.Text;
                usuario.Nome = textBoxNome.Text;
                usuario.Senha = textBoxSenha.Text;
                usuario.Telefone = textBoxTelefone.Text;
                int index = comboBoxTipoUsuario.SelectedIndex;
                tipoUsuario =listaTipoUsuario[index];
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
            try
            {
                TipoUsuario tp = new TipoUsuario();
                tp.CodTipoUsuario = 0;
                tp.DescricaoTipoUsuario = "";
                listaTipoUsuario = servico.ListarTipoUsuario(tp).ToList() ;
                comboBoxTipoUsuario.Items.Clear();
                foreach(TipoUsuario t in listaTipoUsuario){
                    comboBoxTipoUsuario.Items.Add(t.DescricaoTipoUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
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