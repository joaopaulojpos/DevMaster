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
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUIInserirSerie : Form
    {
        #region Atributos

        //Esse atributo vai receber a tela anterior(a partir do Construtor) e assim poder chamar métodos dela.
        GUISerie guiSerie;
        
        #endregion

        #region Construtores

        //Construtor Padrão
        public GUIInserirSerie()
        {
            InitializeComponent();
        }

        //Construtor feito pra receber a tela anterior e assim acessar seus métodos
        public GUIInserirSerie(GUISerie guiSerie)
        {
            InitializeComponent();

            //De fato recebendo a tela anterior
            this.guiSerie = guiSerie;
        }

        #endregion

        #region Inserir

        private void btnInserirClick(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            serie.DescricaoSerie = textBoxDescricaoSerie.Text;
            DAOSerie.Instancia.Inserir(serie);
            MessageBox.Show("Série inserida com sucesso!");

            //Chamando o método Consultar da tela anterior
            guiSerie.Consultar();
        }

        #endregion

        #region Voltar

        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void GUIInserirSerie_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
