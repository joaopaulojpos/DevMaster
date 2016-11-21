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
    public partial class GUIInserirEnsino : Form
    {
        #region Atributos

        //Esse atributo vai receber a tela anterior(a partir do Construtor) e assim poder chamar métodos dela.
        GUIEnsino guiEnsino;

        #endregion

        #region Construtores

        //Construtor Padrão
        public GUIInserirEnsino()
        {
            InitializeComponent();
        }

        //Construtor feito pra receber a tela anterior e assim acessar seus métodos
        public GUIInserirEnsino(GUIEnsino guiEnsino)
        {
            InitializeComponent();

            //De fato recebendo a tela anterior
            this.guiEnsino = guiEnsino;
        }

        #endregion

        #region Inserir

        private void btnInserirClick(object sender, EventArgs e)
        {
            try
            {
                Ensino ensino = new Ensino();
                ensino.DescricaoEnsino = textBoxDescricaoEnsino.Text;

                RNEnsino rnEnsino = new RNEnsino();
                rnEnsino.Inserir(ensino);

                MessageBox.Show("Série inserida com sucesso!");

                //Chamando o método Consultar da tela anterior
                guiEnsino.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Voltar

        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void GUIInserirEnsino_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
