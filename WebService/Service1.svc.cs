using Biblioteca.Basicas;
using Biblioteca.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.

    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {

        private Fachada fachada = Fachada.Instance;

        #region Aluno
        public void InserirAluno(Aluno aluno)
        {
            fachada.InserirAluno(aluno);
        }
        public void AlterarAluno(Aluno aluno)
        {
            fachada.AlterarAluno(aluno);
        }
        public void ExcluirAluno(Aluno aluno)
        {
            fachada.ExcluirAluno(aluno);
        }
        public List<Aluno> ListarAluno(Aluno aluno)
        {
            return fachada.ListarAluno(aluno);
        }
        #endregion

        #region Aula
        public void InserirAula(Aula aula)
        {
            fachada.InserirAula(aula);
        }
        public void AlterarAula(Aula aula)
        {
            fachada.AlterarAula(aula);
        }
        public void ExcluirAula(Aula aula)
        {
            fachada.ExcluirAula(aula);
        }
        public List<Aula> ListarAula(Aula aula)
        {
            return fachada.ListarAula(aula);
        }

        #endregion

        #region Avaliação
        public void InserirAvaliacao(Avaliacao avaliacao)
        {
            fachada.InserirAvaliacao(avaliacao);
        }
        public void AlterarAvaliacao(Avaliacao avaliacao)
        {
            fachada.AlterarAvaliacao(avaliacao);
        }
        public void ExcluirAvaliacao(Avaliacao avaliacao)
        {
            fachada.ExcluirAvaliacao(avaliacao);
        }
        public List<Avaliacao> ListarAvaliacao(Avaliacao avaliacao)
        {
            return fachada.ListarAvaliacao(avaliacao);
        }
        #endregion

        #region Disciplina
        public List<Disciplina> ListarDisciplina(Disciplina disciplina)
        {
            return fachada.ListarDisciplina(disciplina);
        }

        #endregion

        #region Ensino
        public List<Ensino> ListarEnsino(Ensino ensino)
        {
            return fachada.ListarEnsino(ensino);
        }
        #endregion

        #region Falta
        public void InserirFalta(Falta falta)
        {
            fachada.InserirFalta(falta);
        }
        public void AlterarFalta(Falta falta)
        {
            fachada.AlterarFalta(falta);
        }
        public void ExcluirFalta(Falta falta)
        {
            fachada.ExcluirFalta(falta);
        }
        public List<Falta> ListarFalta(Falta falta)
        {
            return fachada.ListarFalta(falta);
        }
        #endregion

        #region Turma
        public void InserirTurma(Turma turma)
        {
            fachada.InserirTurma(turma);
        }
        public void AlterarTurma(Turma turma)
        {
            fachada.AlterarTurma(turma);
        }
        [WebMethod]
        public void ExcluirTurma(Turma turma)
        {
            fachada.ExcluirTurma(turma);
        }
        public List<Turma> ListarTurma(Turma turma)
        {
            return fachada.ListarTurma(turma);
        }
        #endregion

        #region Usuário
        public void InserirUsuario(Usuario usuario)
        {
            fachada.InserirUsuario(usuario);
        }
        public void AlterarUsuario(Usuario usuario)
        {
            fachada.AlterarUsuario(usuario);
        }
        public void ExcluirUsuario(Usuario usuario)
        {
            fachada.ExcluirUsuario(usuario);
        }
        public List<Usuario> ListarUsuario(Usuario usuario)
        {
            return fachada.ListarUsuario(usuario);
        }
        #endregion

        #region Tipo Usuário

        public List<TipoUsuario> ListarTipoUsuario(TipoUsuario tipoUsuario)
        {
            return fachada.ListarTipoUsuario(tipoUsuario);
        }

        #endregion

        #region DisciplinaTurma
        public void InserirDisciplinaTurma(Disciplina_Turma dt)
        {
            fachada.InserirDisciplinaTurma(dt);
        }
        public List<Disciplina_Turma> ListarDisciplinaTurma(Disciplina_Turma dt)
        {
            return fachada.ListarDisciplinaTurma(dt);
        }
    }
    #endregion

}