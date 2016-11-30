using Biblioteca.Basicas;
using Biblioteca.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
    }
}
