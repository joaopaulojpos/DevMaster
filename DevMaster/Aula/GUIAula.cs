using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Aula;
using GUI.localhost;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace GUI
{
    public partial class GUIAula : Form
    {
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private TcpClient tcpClient;
        private Thread thread;

        Service1 servico;
        List<GUI.localhost.Aula> listaAulas;
        public GUIAula()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunClient));
            thread.Start();
            servico = new Service1();
            //carregarAulas();
        }

        public void RunClient()
        {
            try
            {
                tcpClient = new TcpClient();
                //conectando ao servidor
                tcpClient.Connect("127.0.0.1", 2001);

                networkStream = tcpClient.GetStream();
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);
                binaryWriter.Write("Conexão requisitada pelo cliente");
                String message = "";

                #region laço para receber mensagem do servidor
                do
                {
                    try
                    {
                        message = binaryReader.ReadString();
                        Invoke(new MethodInvoker(
                          delegate {

                              GUI.localhost.Aula aula = new GUI.localhost.Aula();
                              listViewAulas.Items.Clear();
                              aula.CodigoAula = 0;
                              aula.Data = "";
                              Disciplina_Turma dt = new Disciplina_Turma();
                              Disciplina disciplina = new Disciplina();
                              Aluno aluno = new Aluno();
                              aluno.Matricula = "";
                              aluno.Nome = "";
                              disciplina.NomeDisciplina = "";
                              Turma t = new Turma();
                              t.CodigoTurma = 0;
                              dt.Disciplina = disciplina;
                              aluno.Turma = t;
                              dt.Turma = t;
                              aula.DisciplinaTurma = dt;

                              listaAulas = servico.ListarAula(aula).ToList();
                              if (listaAulas.Count > 0)
                              {
                                  foreach (GUI.localhost.Aula a in listaAulas)
                                  {
                                      ListViewItem linha = listViewAulas.Items.Add(Convert.ToString(a.Data));
                                      linha.SubItems.Add(a.DisciplinaTurma.Turma.DescricaoTurma);
                                      linha.SubItems.Add(a.DisciplinaTurma.Turma.Turno);
                                      linha.SubItems.Add(a.DisciplinaTurma.Disciplina.NomeDisciplina);
                                      linha.SubItems.Add(a.Assunto);
                                  }
                              }
                              else
                              {
                                  MessageBox.Show("Sem resultados!.");
                              }

                          }
                          ));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro");
                        message = "FIM";
                    }
                } while (message != "FIM");
                #endregion

                binaryWriter.Close();
                binaryReader.Close();
                networkStream.Close();
                tcpClient.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void carregarAulas()
        {
            try
            {
                GUI.localhost.Aula aula = new GUI.localhost.Aula();
                listViewAulas.Items.Clear();
                aula.CodigoAula = 0;
                aula.Data = "";
                Disciplina_Turma dt = new Disciplina_Turma();
                Disciplina disciplina = new Disciplina();
                Aluno aluno = new Aluno();
                aluno.Matricula = "";
                aluno.Nome = "";
                disciplina.NomeDisciplina = "";
                Turma t = new Turma();
                t.CodigoTurma = 0;
                dt.Disciplina = disciplina;
                aluno.Turma = t;
                dt.Turma = t;
                aula.DisciplinaTurma = dt;

                listaAulas = servico.ListarAula(aula).ToList();
                if (listaAulas.Count > 0)
                {
                    foreach(GUI.localhost.Aula a in listaAulas)
                    {
                        ListViewItem linha = listViewAulas.Items.Add(Convert.ToString(a.Data));
                        linha.SubItems.Add(a.DisciplinaTurma.Turma.DescricaoTurma);
                        linha.SubItems.Add(a.DisciplinaTurma.Turma.Turno);
                        linha.SubItems.Add(a.DisciplinaTurma.Disciplina.NomeDisciplina);
                        linha.SubItems.Add(a.Assunto);
                    }
                }
                else
                {
                    MessageBox.Show("Sem resultados!.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIInserirAula gui = new GUIInserirAula();
            gui.ShowDialog();
        }
    }
}
