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


namespace GUI
{
    public partial class GUIInserirTurma : Form
    {
        #region Atributos

        GUITurma guiTurma;
        List<Ensino> listaEnsino;

        Service1 servico;

        #endregion 

        #region Construtores

        public GUIInserirTurma(GUITurma guiTurma)
        {
            InitializeComponent();
            this.guiTurma = guiTurma;
            servico = new Service1();
            AlimentarCampos();
        }

        #endregion

        #region Métodos Auxiliares

        #region Alimentar Campos

        void AlimentarCampos()
        {
            LimparComboAno();
            AlimentarComboTurno();
            AlimentarComboEnsino();
            comboBoxAno.SelectedIndex = 0;
        }

        #endregion

        #region ComboBox Ano

        void LimparComboAno()
        {
            comboBoxAno.Items.Clear();
        }

        //Ensino Médio tem 3 anos, Fundamental 9, dependendo do Ensino ele Alimenta o Combo com 3 ou 9
        void AlimentarComboAno(string ensinoDescricao)
        {
            int limite = 9;
            switch (ensinoDescricao)
            {
                case "Fundamental":
                    limite = 9;
                    break;
                case "Médio":
                    limite = 3;
                    break;
            }
            for (int x = 1; x <= limite; x++)
            {
                comboBoxAno.Items.Add(x);
            }
        }

        #endregion

        #region ComboBox Ensino Descrição

        void AlimentarComboEnsino()
        {
            try {
                Ensino ensino = new Ensino();
                ensino.CodigoEnsino = 0;
                ensino.DescricaoEnsino = "";
                comboBoxAno.Items.Clear();
                listaEnsino = servico.ListarEnsino(ensino).ToList();
                foreach (Ensino e in listaEnsino) {
                    comboBoxEnsino.Items.Add(e.DescricaoEnsino);
                }
            comboBoxEnsino.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region ComboBox Turno

        void AlimentarComboTurno()
        {
            comboBoxTurno.Items.Add("M");
            comboBoxTurno.Items.Add("T");
            comboBoxTurno.Items.Add("N");
            comboBoxTurno.SelectedIndex = 0;
        }

        #endregion

        #region Evento ComboBox Ensino Changed

        private void comboBoxEnsino_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LimparComboAno();
            AlimentarComboAno(comboBoxEnsino.Text);
            comboBoxAno.SelectedIndex = 0;

        }

        #endregion

        #endregion

        #region Botão Inserir

        private void Concluir_Click(object sender, EventArgs e)
        {
            try
            {
                Turma turma = new Turma();
                Ensino ensino = new Ensino();

                turma.DescricaoTurma = textBoxDescricao.Text;
                turma.Ano = Convert.ToInt32(comboBoxAno.Text);
                turma.Turno = comboBoxTurno.Text;
                turma.DataInicio = dateDataInicio.Value;

                int index = comboBoxEnsino.SelectedIndex;
                ensino = listaEnsino[index];
                
                turma.Ensino = ensino;

                //Chamando Web Service
                servico.InserirTurma(turma);

                //Informando Usuário
                MessageBox.Show("Turma inserida com sucesso!");

                //Atualizando List View
                guiTurma.CarregarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Voltar

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

    }
}