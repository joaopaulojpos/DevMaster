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
using WebService;
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUIAlterarTurma : Form
    {
        #region Atributos

        Turma turma;
        GUITurma guiTurma;

        DAOTurma daoTurma;

        #endregion

        #region Construtores

        //Padrão
        private GUIAlterarTurma()
        {
            InitializeComponent();
        }

        public GUIAlterarTurma(Turma turma, GUITurma guiTurma)
        {
            InitializeComponent();
            this.turma = turma;
            AlimentarCampos(turma);
            this.guiTurma = guiTurma;
        }

        #endregion

        #region Métodos Auxiliares

        void AlimentarCampos(Turma turma)
        {
            textBoxDescricao.Text = turma.DescricaoTurma;
            comboBoxAno.Text = Convert.ToString(turma.Ano);
            comboBoxTurno.Text = turma.Turno;
            dateDataInicio.Value = turma.DataInicio;
            MessageBox.Show(turma.Ensino.DescricaoEnsino + turma.Ensino.CodigoEnsino);
            comboBoxEnsino.Text = turma.Ensino.DescricaoEnsino;
        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                daoTurma = new DAOTurma();
                daoTurma.Alterar(turma);
                MessageBox.Show("Turma alterada com sucesso!");

                guiTurma.CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Botão Voltar

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

    }
}
