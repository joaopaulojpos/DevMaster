﻿using System;
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
using WebService;

namespace GUI
{
    public partial class GUITurma : Form
    {

        #region Atributos

        List<Turma> listaTurma;

        #endregion

        #region Construtores

        //Padrão
        public GUITurma()
        {
            InitializeComponent();
            //listViewTurmas
            //Comentei por enquanto
            Consultar();
            //Comentei por enquanto
            listViewTurmas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewTurmas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region Métodos Auxiliares

        public void Consultar()
        {
            try
            {
                listViewTurmas.Items.Clear();

                Turma turma = new Turma();
                turma.CodigoTurma = 0;
                turma.DescricaoTurma = "";

                Servico servico = new Servico();

                //Tá dando erro pq RNTurma ainda não tá pronto
                listaTurma = servico.ListarTurma(turma);

                foreach (Turma t in listaTurma)
                {
                    ListViewItem linha = listViewTurmas.Items.Add(t.CodigoTurma.ToString());
                    linha.SubItems.Add(t.DescricaoTurma);
                    linha.SubItems.Add(Convert.ToString(t.Turno));
                    linha.SubItems.Add(Convert.ToString(t.Ano));
                    linha.SubItems.Add(t.DataInicio);
                    linha.SubItems.Add(t.Ensino.DescricaoEnsino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        #endregion

        #region Botões



        #region Consultar

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }

        }

        #endregion

        #region Inserir

        private void novaTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirTurma guiInserirTurma = new GUIInserirTurma();
            guiInserirTurma.ShowDialog();
        }

        #endregion

        #region Alterar

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurmas.SelectedItems;

            Turma alterarTurma = new Turma();
            int codigoSelecionado = 0;

            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                codigoSelecionado = Convert.ToInt32(selecionado.SubItems[0].Text);
            }

            foreach (Turma turma in listaTurma)
            {
                if (turma.CodigoTurma == codigoSelecionado)
                {
                    alterarTurma = turma;
                }
            }

            GUIAlterarTurma guiAlterarTurma = new GUIAlterarTurma(alterarTurma, this);
            guiAlterarTurma.ShowDialog();
        }

        #endregion

        #region Remover

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Pega a Série selecionada, mesmo que só seja uma ele entende como uma coleção
            ListView.SelectedListViewItemCollection colecaoSelecionada = listViewTurmas.SelectedItems;

            Turma removerTurma = new Turma();

            //Percorrendo a coleção(a série selecionada)
            foreach (ListViewItem selecionado in colecaoSelecionada)
            {
                removerTurma.CodigoTurma = Convert.ToInt32(selecionado.SubItems[0].Text);

                if (MessageBox.Show("Tem certeza?", "Confirmar remoção da Turma.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DAOTurma rnTurma = new DAOTurma();
                    rnTurma.Excluir(removerTurma);

                    listViewTurmas.Items.Remove(selecionado);
                }
                else
                {
                    MessageBox.Show("Cancelado.", "Remoção da Turma.");
                }
            }
        }

        #endregion

        #region Voltar

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #endregion
    }
}
