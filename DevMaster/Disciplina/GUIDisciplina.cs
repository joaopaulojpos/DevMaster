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
    public partial class GUIDisciplina : Form
    {
        #region Atributos

        List<Disciplina> listaDisciplina;

        string filtroDescricao;
        int filtroCodigo;

        #endregion

        #region Construtores

        //Padrão
        public GUIDisciplina()
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
                listViewDisciplinas.Items.Clear();

                Disciplina disciplinaFiltro = new Disciplina();
                DAODisciplina daoDisciplina = new DAODisciplina();

                //                  CÓDIGO TIPO DE USUÁRIO
                ZeraTextBoxCod();
                if (int.TryParse(textBoxCodigo.Text, out filtroCodigo))
                {
                    TirarZeroTextBoxCodigo();
                    disciplinaFiltro.CodigoDisciplina = filtroCodigo;
                }
                else
                {
                    LimpaTextBoxCodigo();
                    throw new FormatException("Digite apenas números válidos.");
                }


                //                  DESCRIÇÃO TIPO DE USUÁRIO
                filtroDescricao = textBoxDescricao.Text;
                disciplinaFiltro.NomeDisciplina = filtroDescricao;

                listaDisciplina = daoDisciplina.Listar(disciplinaFiltro);

                if (listaDisciplina.Count > 0)
                {
                    foreach (Disciplina disciplina in listaDisciplina)
                    {
                        ListViewItem linha = listViewDisciplinas.Items.Add(Convert.ToString(disciplina.CodigoDisciplina));
                        linha.SubItems.Add(disciplina.NomeDisciplina);
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
