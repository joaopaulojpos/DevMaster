using Biblioteca.Basicas;
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
using Biblioteca.DAO;

namespace GUI
{
    public partial class GUIInserirTurma : Form
    {
        #region Atributos

        GUITurma guiTurma;
        List<Ensino> listaEnsino;
        //Servico servico = new Servico();
        DAOEnsino daoEnsino; //TROCAR PRA SERVIÇO AQUI
        DAOTurma daoTurma;

        #endregion 

        #region Construtores

        //Padrão
        public GUIInserirTurma()
        {
            InitializeComponent();
            carregarComboEnsino();
            carregarComboTurno();
        }


        //Utilizado
        public GUIInserirTurma(GUITurma guiTurma)
        {
            InitializeComponent();
            this.guiTurma = guiTurma;
            carregarComboAno("Fundamental");
            carregarComboEnsino();
            carregarComboTurno();
        }

        #endregion

        #region Métodos Auxiliares

        #region Combobox Turno

        private void carregarComboTurno()
        {
            comboBoxTurno.Items.Add("M");
            comboBoxTurno.Items.Add("T");
            comboBoxTurno.Items.Add("N");
        }

        #endregion

        #region ComboBox Ano

        private void carregarComboAno(string ensino)
        {
            int totalAno = 0;

            if (ensino == "Fundamental")
            {
                totalAno = 9;
            }
            if (ensino == "Médio")
            {
                totalAno = 3;
            }
            int x = 1;
            while (x <= totalAno)
            {
                comboBoxAno.Items.Add(x);
                x++;
            }
                
        }

        #endregion

        #region Combobox Ensino

        private void carregarComboEnsino()
        {
            try
            {
                Ensino ensinoFiltro = new Ensino();
                daoEnsino = new DAOEnsino();
                ensinoFiltro.CodigoEnsino = 0;
                listaEnsino = daoEnsino.Listar(ensinoFiltro);
                foreach (Ensino ensino3 in listaEnsino)
                {
                    comboBoxEnsino.Items.Add(ensino3.DescricaoEnsino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                Ensino ensinoFiltro = new Ensino(); //só vai servir pra buscar o Ensino do banco

                turma.DescricaoTurma = textBoxDescricao.Text;
                turma.Ano = Convert.ToInt32(comboBoxAno.Text);
                turma.Turno = comboBoxTurno.Text;
                turma.DataInicio = dateDataInicio.Value;

                ensinoFiltro.DescricaoEnsino = comboBoxEnsino.Text;

                //TROCAR PRA SERVIÇO AQUI
                daoEnsino = new DAOEnsino();

                listaEnsino = daoEnsino.Listar(ensinoFiltro);
                if (listaEnsino.Count > 0)
                {
                    foreach (Ensino ensino2 in listaEnsino)
                    {
                        ensino = ensino2;
                    }
                }
                turma.Ensino = ensino;

                daoTurma = new DAOTurma();
                daoTurma.Inserir(turma);

                MessageBox.Show("Turma inserida com sucesso!");

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