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
using WebService;
using Biblioteca.DAO;
using System.IO;
using System.Xml;

namespace GUI
{
    public partial class GUIChamada : Form
    {
        #region Atributos

        private Servico servico;
        private List<Turma> listaTurmas;
        private List<Aluno> listaAlunos;
        private List<Disciplina> listaDisciplinas;
        //private List<Disciplina_Turma> listaDisciplinaTurma;
        //private List<Aluno> listaFaltosos;
        private List<Aula> listaAulas;
        string caminhoXML = @"C:\Escola Pablo Neruda\Pablo Neruda Chamada.xml";

        #endregion

        #region Construtor

        public GUIChamada()
        {
            InitializeComponent();
            servico = new Servico();
            AlimentarComboTurma();
            AlimentarComboDisciplina();
            AbrirXML();
            PuxarXML();
        }

        #endregion

        #region Métodos Auxiliares

        #region Alimentar ComboBox Disciplina

        private void AlimentarComboDisciplina()
        {
            try
            {
                comboBoxDisciplina.Items.Clear();
                Disciplina disciplinaFiltro = new Disciplina();
                disciplinaFiltro.CodigoDisciplina = 0;
                listaDisciplinas = servico.ListarDisciplina(disciplinaFiltro);
                foreach (Disciplina dis in listaDisciplinas)
                {
                    comboBoxDisciplina.Items.Add(dis.NomeDisciplina);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //Quando mudar a Disciplina muda a aula
        #region Combobox Disciplina Change

        private void comboBoxDisciplina_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDisciplina.Text != String.Empty)
                {
                    AlimentarComboAulas(listaDisciplinas.ElementAt(comboBoxDisciplina.SelectedIndex));
                }
                else
                {
                    MessageBox.Show("fdsa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Alimentar ComboBox Turma

        private void AlimentarComboTurma()
        {
            try
            {
                comboBoxTurma.Items.Clear();
                Turma turmaFiltro = new Turma();
                turmaFiltro.CodigoTurma = 0;
                listaTurmas = servico.ListarTurma(turmaFiltro);
                foreach (Turma turma in listaTurmas)
                {
                    comboBoxTurma.Items.Add(turma.DescricaoTurma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //Quando mudar a Turma, muda a lista de alunos
        #region ComboBox Turma Change

        private void birl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTurma.Text != String.Empty)
                {
                    AlimentarCheckedListAlunos(listaTurmas.ElementAt(comboBoxTurma.SelectedIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Alimentar Checked List Alunos

        private void AlimentarCheckedListAlunos(Turma turma)
        {
            #region OLD
            /* 
              int index = comboBox1.SelectedIndex;
            if (!comboBox1.Items[index].Equals(""))
            {
                Disciplina d = new Disciplina();
                d.NomeDisciplina = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index - 1].CodigoTurma;
                aluno.Turma = t;
                dt.Turma = t;
                dt.Disciplina = d;
                Biblioteca.Basicas.Aula al = new Biblioteca.Basicas.Aula();
                al.DisciplinaTurma = dt;
                al.Data = dateTimePicker1.Text;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                checkedListBoxAlunos.Items.Clear();
            }
             */

            #endregion

            try
            {
                checkedListBoxAlunos.Items.Clear();

                DAOChamada daoParticipa = new DAOChamada();

                listaAlunos = daoParticipa.ListarAlunosDaTurma(turma);

                if (listaAlunos.Count > 0)
                {
                    foreach (Aluno a in listaAlunos)
                    {
                        checkedListBoxAlunos.Items.Add(a.Nome);
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

        #region Alimentar ComboBox Aula

        private void AlimentarComboAulas(Disciplina disciplinaTurma)
        {
            try
            {
                comboBoxAula.Items.Clear();

                DAOAula daoAula = new DAOAula();
                listaAulas = daoAula.ListarParaChamada(disciplinaTurma);
                //listaAulas = servico.ListarAula(disciplinaTurma);

                if (listaAulas.Count > 0)
                {
                    foreach (Aula a in listaAulas)
                    {
                        comboBoxAula.Items.Add(a.Assunto);
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

        #region Carregar Aulas

        private void carregarAulas(Disciplina_Turma disciplinaTurma)
        {
            try
            {
                comboBoxAula.Items.Clear();
                Aula aulaFiltro = new Aula();
                aulaFiltro.CodigoAula = 0;
                listaAulas = servico.ListarAula(aulaFiltro);
                foreach (Aula al in listaAulas)
                {
                    comboBoxAula.Items.Add(al.Assunto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Métodos XML

        #region Abrir XML

        public void AbrirXML()
        {
            try
            {
                if (File.Exists(caminhoXML) == false)
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode raiz = doc.CreateElement("telaChamadas");
                    doc.AppendChild(raiz);
                    doc.Save(caminhoXML);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o XML da Chamada. Erro:\n" + ex.Message);
            }
        }

        #endregion

        #region Nova Linha XML

        public void NovaLinhaXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(caminhoXML);

                XmlNode linha = doc.CreateElement("chamada");
                XmlNode DescricaoTurma = doc.CreateElement("turma");
                XmlNode NomeDisciplina = doc.CreateElement("disciplina");
                XmlNode Dia = doc.CreateElement("dia");
                XmlNode AssuntoAula = doc.CreateElement("aula");

                DescricaoTurma.InnerText = comboBoxTurma.Text;
                NomeDisciplina.InnerText = comboBoxDisciplina.Text;
                AssuntoAula.InnerText = comboBoxAula.Text;
                Dia.InnerText = dateDia.Value.ToShortDateString();


                linha.AppendChild(DescricaoTurma);
                linha.AppendChild(NomeDisciplina);
                linha.AppendChild(Dia);
                linha.AppendChild(AssuntoAula);

                doc.SelectSingleNode("/telaChamadas").AppendChild(linha);

                doc.Save(caminhoXML);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar informações da tela no XML. Erro:\n" + ex.Message);
            }
        }

        #endregion

        #region Puxar XML

        public void PuxarXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(caminhoXML);

                foreach (XmlNode no in doc.DocumentElement.ChildNodes)
                {
                    //Turma
                    comboBoxTurma.SelectedItem = no.ChildNodes.Item(0).ChildNodes.Item(0).InnerText;
                    //Disciplina
                    comboBoxDisciplina.SelectedItem = no.ChildNodes.Item(1).ChildNodes.Item(0).InnerText;
                    //Dia
                    dateDia.Value = Convert.ToDateTime(no.ChildNodes.Item(2).ChildNodes.Item(0).InnerText);
                    //Aula
                    comboBoxAula.SelectedItem = no.ChildNodes.Item(3).ChildNodes.Item(0).InnerText;
                }
                doc.Save(caminhoXML);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível puxar o XML. Erro:\n" + ex.Message);
            }
            //return;
        }

        #endregion

        #region Apaga Linha XML

        public void ApagarLinhaXML()
        {
            try
            {
                if (File.Exists(caminhoXML))
                {
                    File.Delete(caminhoXML);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível apagar o XML. Erro:\n" + ex.Message);
            }
        }

        #endregion

        #endregion

        #region Botão Finalizar Chamada

        private void btnFinalizarChamada_Click(object sender, EventArgs e)
        {
            try
            {
                /* Incompleto
                NovaLinhaXML();
                Aluno alunoFiltro = new Aluno();
                listaFaltosos = new List<Aluno>();

                foreach (object nome in checkedListBoxAlunos.Items)
                {
                    //Pega nos não checados
                    if (!checkedListBoxAlunos.CheckedItems.Contains(nome))
                    {
                        alunoFiltro.Nome = Convert.ToString(nome);
                        MessageBox.Show(alunoFiltro.Nome);
                        listaFaltosos.Add;
                    }
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region OLD

        /*
        try
        {
            Aluno aluno = new Aluno();

            Biblioteca.Basicas.Aula aula = new Biblioteca.Basicas.Aula();
            Falta falta = new Falta();
            int indexA = comboBoxAula.SelectedIndex;
            foreach (int c in checkedListBoxAlunos.CheckedIndices)
            {
                int indexAl = Int32.Parse(c.ToString());
                aluno = listaAlunos[indexAl];
                aula = listaAulas[indexA];
                falta.Data = dateDia.Text;
                falta.Aluno = aluno;
                falta.Aula = aula;
                falta.Abono = false;
                falta.Motivo = "";
                servico.InserirFalta(falta);
            }
            MessageBox.Show("Chamada registrada.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }*/

        #endregion

        #endregion

        #region Data Change

        private void dateDia_ValueChanged(object sender, EventArgs e)
        {/*
            int index = comboBoxTurma.SelectedIndex;
            if (!comboBoxTurma.Items[index].Equals(""))
            {
                Disciplina d = new Disciplina();
                d.NomeDisciplina = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                Turma t = new Turma();
                t.CodigoTurma = listaTurmas[index - 1].CodigoTurma;
                aluno.Turma = t;
                dt.Turma = t;
                dt.Disciplina = d;
                Biblioteca.Basicas.Aula al = new Biblioteca.Basicas.Aula();
                al.DisciplinaTurma = dt;
                al.Data = dateDia.Text;
                carregarAlunos(aluno);
                carregarAulas(al);
            }
            else
            {
                checkedListBoxAlunos.Items.Clear();
            }
            */
        }

        #endregion

        #region Botão Voltar

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Outros

        private void GUIChamada_Load(object sender, EventArgs e)
        {

        }



        private void comboBoxAula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testeXMLCLIck_Click(object sender, EventArgs e)
        {
            try
            {
                int varleandro = 1;
                NovaLinhaXML();
                if (varleandro == 2)
                {
                    MessageBox.Show("Digamos q conseguiu Finalizar Chamada");
                    ApagarLinhaXML();
                    MessageBox.Show("Apagou a linha, já q Conseguiu");
                }
                else
                {
                    MessageBox.Show("Digamos q o server caiu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar nova linha no XML. Erro: \n" + ex.Message);
            }
        }

        #endregion


    }
}