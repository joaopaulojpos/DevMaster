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
    public partial class GUIAlterarTurma : Form
    {
        #region Atributos

        Turma turma;
        Turma novaTurma;
        GUITurma guiTurma;
        List<Ensino> listaEnsino;

        Service1 servico;

        //Servico servico;

        #endregion

        #region Construtores

        public GUIAlterarTurma(Turma turma, GUITurma guiTurma)
        {
            InitializeComponent();
            servico = new Service1();
            this.turma = turma;
            AlimentarCampos(turma);
            this.guiTurma = guiTurma;
        }

        #endregion

        #region Métodos Auxiliares
        
        void AlimentarCampos(Turma turma)
        {
            LimparComboAno();
            textBoxDescricao.Text = turma.DescricaoTurma;

            AlimentarComboAno(turma.Ensino.DescricaoEnsino);
            comboBoxAno.SelectedIndex = comboBoxAno.FindStringExact(Convert.ToString(turma.Ano));

            AlimentarComboTurno();
            comboBoxTurno.SelectedIndex = comboBoxTurno.FindStringExact(turma.Turno);

            dateDataInicio.Value = turma.DataInicio;

            AlimentarComboEnsino(turma);
            comboBoxEnsino.SelectedIndex = comboBoxEnsino.FindStringExact(turma.Ensino.DescricaoEnsino);
        }

        void LimparComboAno()
        {
            comboBoxAno.Items.Clear();
        }

        void AlimentarComboEnsino(Turma turma)
        {
            try {
                Ensino ensino = new Ensino();
                ensino.CodigoEnsino = 0;
                ensino.DescricaoEnsino = "";
                comboBoxAno.Items.Clear();
                listaEnsino = servico.ListarEnsino(ensino).ToList();
                foreach (Ensino e in listaEnsino)
                {
                    comboBoxEnsino.Items.Add(e.DescricaoEnsino);
                }
                comboBoxEnsino.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        void AlimentarComboTurno()
        {
            comboBoxTurno.Items.Add("M");
            comboBoxTurno.Items.Add("T");
            comboBoxTurno.Items.Add("N");
        }

        private void comboBoxEnsino_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparComboAno();
            AlimentarComboAno(comboBoxEnsino.Text);
        }

        #endregion

        #region Botão Concluir

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                novaTurma = new Turma();
                novaTurma.CodigoTurma = turma.CodigoTurma;
                novaTurma.DescricaoTurma = textBoxDescricao.Text;
                novaTurma.Turno = comboBoxTurno.Text;
                novaTurma.Ano = Convert.ToInt32(comboBoxAno.Text);
                novaTurma.DataInicio = dateDataInicio.Value;

                Ensino ensino = new Ensino();
                ensino.DescricaoEnsino = comboBoxEnsino.Text;

                List<Ensino> listaEnsino = new List<Ensino>();

                listaEnsino = servico.ListarEnsino(ensino).ToList();

                foreach (Ensino ensino2 in listaEnsino)
                {
                    ensino.CodigoEnsino = ensino2.CodigoEnsino;
                    ensino.DescricaoEnsino = ensino2.DescricaoEnsino;
                }
                novaTurma.Ensino = ensino;

                servico.AlterarTurma(novaTurma);

                MessageBox.Show("Turma Alterada com sucesso!");
                //servico = new Servico();
                //servico.AlterarTurma(turma);

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
