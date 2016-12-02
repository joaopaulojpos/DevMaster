using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebService;

namespace GUI
{
    public partial class GUIBoletim : Form
    {

       // private Service1 servico = new Service1();
        List<Boletim> listaBoletim;

        public GUIBoletim()
        {
            InitializeComponent();
            //carregarBoletim();
        }

        private void carregarBoletim()
        {
            try
            {
                Boletim bo = new Boletim();
                Avaliacao av = new Avaliacao();
                Disciplina_Turma dt = new Disciplina_Turma();
                Disciplina disciplina = new Disciplina();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                av.Aluno = aluno;
                bo.Avaliacao = av;
                listView1.Items.Clear();
                DAOBoletim dao = new DAOBoletim();
                //listaBoletim = servico.EmitirBoletim(bo).ToList();
                listaBoletim = dao.listar(bo).ToList();

                if (listaBoletim.Count > 0)
                {
                    foreach (Boletim b in listaBoletim)
                    {
                        ListViewItem item = listView1.Items.Add(b.Avaliacao.Aluno.Matricula);
                        item.SubItems.Add(b.Avaliacao.Aluno.Nome);
                        item.SubItems.Add(b.Avaliacao.Disciplina_turma.Turma.DescricaoTurma);
                        item.SubItems.Add(b.Avaliacao.Descricao);
                        item.SubItems.Add(Convert.ToString(b.Avaliacao.Nota));
                        item.SubItems.Add(b.Avaliacao.Disciplina_turma.Disciplina.NomeDisciplina);
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

        private void GUIBoletim_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
