using Biblioteca.Basicas;
using Biblioteca.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

//XML
using System.Xml;
using System.IO;

namespace WebService
{
    /// <summary>
    /// Summary description for Servico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servico : System.Web.Services.WebService
    {
        private Fachada fachada = Fachada.Instance;


        #region Aluno
        [WebMethod]
        public void InserirAluno(Aluno aluno)
        {
            fachada.InserirAluno(aluno);
        }
        [WebMethod]
        public void AlterarAluno(Aluno aluno)
        {
            fachada.AlterarAluno(aluno);
        }
        [WebMethod]
        public void ExcluirAluno(Aluno aluno)
        {
            fachada.ExcluirAluno(aluno);
        }
        [WebMethod]
        public List<Aluno> ListarAluno(Aluno aluno)
        {
            return fachada.ListarAluno(aluno);
        }
        #endregion

        #region Aula
        [WebMethod]
        public void InserirAula(Aula aula)
        {
            fachada.InserirAula(aula);
        }
        [WebMethod]
        public void AlterarAula(Aula aula)
        {
            fachada.AlterarAula(aula);
        }
        [WebMethod]
        public void ExcluirAula(Aula aula)
        {
            fachada.ExcluirAula(aula);
        }
        [WebMethod]
        public List<Aula> ListarAula(Aula aula)
        {
            return fachada.ListarAula(aula);
        }

        #endregion

        #region Avaliação
        [WebMethod]
        public void InserirAvaliacao(Avaliacao avaliacao)
        {
            fachada.InserirAvaliacao(avaliacao);
        }
        [WebMethod]
        public void AlterarAvaliacao(Avaliacao avaliacao)
        {
            fachada.AlterarAvaliacao(avaliacao);
        }
        [WebMethod]
        public void ExcluirAvaliacao(Avaliacao avaliacao)
        {
            fachada.ExcluirAvaliacao(avaliacao);
        }
        [WebMethod]
        public List<Avaliacao> ListarAvaliacao(Avaliacao avaliacao)
        {
            return fachada.ListarAvaliacao(avaliacao);
        }
        #endregion

        #region Disciplina
        [WebMethod]
        public List<Disciplina> ListarDisciplina(Disciplina disciplina)
        {
            return fachada.ListarDisciplina(disciplina);
        }

        #endregion

        #region Ensino

        [WebMethod]
        public List<Ensino> ListarEnsino(Ensino ensino)
        {
            return fachada.ListarEnsino(ensino);
        }

        #endregion

        #region Falta
        [WebMethod]
        public void InserirFalta(Falta falta)
        {
            fachada.InserirFalta(falta);
        }
        [WebMethod]
        public void AlterarFalta(Falta falta)
        {
            fachada.AlterarFalta(falta);
        }
        [WebMethod]
        public void ExcluirFalta(Falta falta)
        {
            fachada.ExcluirFalta(falta);
        }
        [WebMethod]
        public List<Falta> ListarFalta(Falta falta)
        {
            return fachada.ListarFalta(falta);
        }
        #endregion

        #region Turma
        [WebMethod]
        public void InserirTurma(Turma turma)
        {
            fachada.InserirTurma(turma);
        }
        [WebMethod]
        public void AlterarTurma(Turma turma)
        {
            fachada.AlterarTurma(turma);
        }
        [WebMethod]
        public void ExcluirTurma(Turma turma)
        {
            fachada.ExcluirTurma(turma);
        }
        [WebMethod]
        public List<Turma> ListarTurma(Turma turma)
        {
            return fachada.ListarTurma(turma);
        }
        #endregion

        #region Usuário
        [WebMethod]
        public void InserirUsuario(Usuario usuario)
        {
            fachada.InserirUsuario(usuario);
        }
        [WebMethod]
        public void AlterarUsuario(Usuario usuario)
        {
            fachada.AlterarUsuario(usuario);
        }
        [WebMethod]
        public void ExcluirUsuario(Usuario usuario)
        {
            fachada.ExcluirUsuario(usuario);
        }
        [WebMethod]
        public List<Usuario> ListarUsuario(Usuario usuario)
        {
            return fachada.ListarUsuario(usuario);
        }
        #endregion

        #region Tipo Usuário

        [WebMethod]
        public List<TipoUsuario> ListarTipoUsuario(TipoUsuario tipoUsuario)
        {
            return fachada.ListarTipoUsuario(tipoUsuario);
        }

        #endregion

        #region DisciplinaTurma
        [WebMethod]
        public void InserirDisciplinaTurma(Disciplina_Turma dt)
        {
            fachada.InserirDisciplinaTurma(dt);
        }
        [WebMethod]
        public List<Disciplina_Turma> ListarDisciplinaTurma(Disciplina_Turma dt)
        {
            return fachada.ListarDisciplinaTurma(dt);
        }
        #endregion


        #region XML
        /*
        #region Atributos 

        string caminho = @"C:\Pablo_Neruda_XML.xml";
        int pos = 0;

        #endregion

        #region Abrir Arquivo

        [WebMethod]
        public void abrirArquivo() //Esse é o Principal
        {
            if (File.Exists(caminho) == false)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode raiz = doc.CreateElement("empresa");
                doc.AppendChild(raiz);
                doc.Save(caminho);
            }
        }

        #endregion

        #region Carga Dados

        [WebMethod]
        public void cargaDados()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminho);

            for (int i = 0; i < 150; i++)
            {
                XmlNode linha = doc.CreateElement("funcionario");
                XmlNode Id = doc.CreateElement("id");
                XmlNode NomeCompleto = doc.CreateElement("nomecompleto");
                XmlNode Nome = doc.CreateElement("nome");
                XmlNode SobreNome = doc.CreateElement("sobrenome");
                XmlNode Idade = doc.CreateElement("idade");
                XmlNode Cargo = doc.CreateElement("cargo");
                Id.InnerText = "" + i;
                Nome.InnerText = "Funcionario " + i;
                Idade.InnerText = "" + (i * 2);
                Cargo.InnerText = "Financeiro";
                SobreNome.InnerText = "sobre func";
                NomeCompleto.AppendChild(Nome);
                NomeCompleto.AppendChild(SobreNome);
                linha.AppendChild(Id);
                linha.AppendChild(NomeCompleto);
                linha.AppendChild(Idade);
                linha.AppendChild(Cargo);
                doc.SelectSingleNode("/empresa").AppendChild(linha);
            }

            doc.Save(caminho);
            MessageBox.Show("Concluido");
        }

        #endregion

        #region Nova Linha

        public void novaLinha()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminho);

            XmlNode linha = doc.CreateElement("funcionario");
            XmlNode Id = doc.CreateElement("id");
            XmlNode NomeCompleto = doc.CreateElement("nomecompleto");
            XmlNode Nome = doc.CreateElement("nome");
            XmlNode SobreNome = doc.CreateElement("sobrenome");
            XmlNode Idade = doc.CreateElement("idade");
            XmlNode Cargo = doc.CreateElement("cargo");

            XmlAttribute idAtr = doc.CreateAttribute("idAtr");
            idAtr.InnerText = "" + pos;
            Id.InnerText = "" + pos;
            Nome.InnerText = "Funcionario " + pos;
            Idade.InnerText = "" + (pos * 2);
            Cargo.InnerText = "Financeiro";
            SobreNome.InnerText = "sobre func";
            NomeCompleto.AppendChild(Nome);
            NomeCompleto.AppendChild(SobreNome);

            Id.Attributes.Append(idAtr);
            linha.AppendChild(Id);
            linha.AppendChild(NomeCompleto);
            linha.AppendChild(Idade);
            linha.AppendChild(Cargo);
            doc.SelectSingleNode("/empresa").AppendChild(linha);

            doc.Save(caminho);
            pos++;
            MessageBox.Show("Concluido");
        }

        #endregion

        #region Alterar Linha

        public void alterarLinha()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminho);
            XmlNode no;

            no = doc.SelectSingleNode(String.Format("/empresa/funcionario[id={0}]", 10));
            if (no != null)
            {
                no.SelectSingleNode("./cargo").InnerText = "Gerente Administrativo";
                doc.Save(caminho);
                listar();
                MessageBox.Show("Concluido");
            }
            else
            {
                MessageBox.Show("Não encontrado");
            }
        }

        #endregion

        #region Remover Linha

        public void removerLinha()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminho);
            foreach (XmlNode no in doc.DocumentElement.ChildNodes)
            {
                if (int.Parse(no.ChildNodes.Item(0).InnerText) == 10)
                {
                    doc.DocumentElement.RemoveChild(no);
                    doc.Save(caminho);
                    return;
                }
            }
            listar();
        }

        #endregion

        #region Listar

        public void listar()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminho);

            listView1.Items.Clear();
            foreach (XmlNode no in doc.DocumentElement.ChildNodes)
            {
                //ID
                ListViewItem item = listView1.Items.Add("" + no.ChildNodes.Item(0).InnerText);
                //NOME
                item.SubItems.Add(no.ChildNodes.Item(1).ChildNodes.Item(0).InnerText);
                //SOBRENOME
                item.SubItems.Add(no.ChildNodes.Item(1).ChildNodes.Item(1).InnerText);
                //IDADE
                item.SubItems.Add(no.ChildNodes.Item(2).InnerText);
                //CARGO
                item.SubItems.Add(no.ChildNodes.Item(3).InnerText);
            }
            doc.Save(caminho);
            return;
        }

        #endregion
    */
        #endregion

    }
}
