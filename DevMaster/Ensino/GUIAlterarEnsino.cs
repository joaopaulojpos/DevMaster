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

namespace GUI
{
    public partial class GUIAlterarEnsino : Form
    {
        #region Atributos

        Ensino ensinoAlterado;

        //Esse atributo vai receber a tela anterior(a partir do Construtor) e assim poder chamar métodos dela.
        GUIEnsino guiEnsino;

        #endregion

        #region Construtores

        //Construtor Padrão
        public GUIAlterarEnsino(Ensino ensinoOld)
        {
            InitializeComponent();

            ensinoAlterado = ensinoOld;

            AlimentarCampos(ensinoOld);

        }

        //Construtor feito pra receber a tela anterior e assim acessar seus métodos
        public GUIAlterarEnsino(Ensino ensinoOld, GUIEnsino guiEnsino)
        {
            InitializeComponent();

            ensinoAlterado = ensinoOld;

            AlimentarCampos(ensinoOld);

            //De fato recebendo a tela anterior
            this.guiEnsino = guiEnsino;
        }

        #endregion

        #region Métodos Auxiliares

        void AlimentarCampos(Ensino ensino)
        {
            textBoxDescricaoEnsino.Text = ensino.DescricaoEnsino;
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
            try
            {
                ensinoAlterado.DescricaoEnsino = textBoxDescricaoEnsino.Text;

                RNEnsino rnEnsino = new RNEnsino();
                rnEnsino.Alterar(ensinoAlterado);
                MessageBox.Show("Ensino alterada com sucesso!");

                //Chamando o método Consultar da tela anterior
                guiEnsino.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
                throw;
            }
        }

        #endregion

        #region Outros

        private void GUIAlterarEnsino_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
