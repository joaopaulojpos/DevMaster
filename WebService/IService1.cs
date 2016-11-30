using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        #region Aluno
        [OperationContract]
        void InserirAluno(Aluno aluno);

        [OperationContract]
        void AlterarAluno(Aluno aluno);

        [OperationContract]
        void ExcluirAluno(Aluno aluno);

        [OperationContract]
        List<Aluno> ListarAluno(Aluno aluno);

        #endregion

        #region Aula
        [OperationContract]
        void InserirAula(Aula aula);

        [OperationContract]
        void AlterarAula(Aula aula);

        [OperationContract]
        void ExcluirAula(Aula aula);

        [OperationContract]
        List<Aula> ListarAula(Aula aula);


        #endregion

        #region Avaliação
        [OperationContract]
        void InserirAvaliacao(Avaliacao avaliacao);

        [OperationContract]
        void AlterarAvaliacao(Avaliacao avaliacao);

        [OperationContract]
        void ExcluirAvaliacao(Avaliacao avaliacao);

        [OperationContract]
        List<Avaliacao> ListarAvaliacao(Avaliacao avaliacao);

        #endregion

        #region Disciplina
        [OperationContract]
        List<Disciplina> ListarDisciplina(Disciplina disciplina);

        #endregion

        #region Ensino
        [OperationContract]
        List<Ensino> ListarEnsino(Ensino ensino);

        #endregion

        #region Falta
        [OperationContract]
        void InserirFalta(Falta falta);

        [OperationContract]
        void AlterarFalta(Falta falta);

        [OperationContract]
        void ExcluirFalta(Falta falta);

        [OperationContract]
        List<Falta> ListarFalta(Falta falta);

        #endregion

        #region Turma
        [OperationContract]
        void InserirTurma(Turma turma);

        [OperationContract]
        void AlterarTurma(Turma turma);

        [OperationContract]
        void ExcluirTurma(Turma turma);

        [OperationContract]
        List<Turma> ListarTurma(Turma turma);

        #endregion

        #region Usuário
        [OperationContract]
        void InserirUsuario(Usuario usuario);

        [OperationContract]
        void AlterarUsuario(Usuario usuario);

        [OperationContract]
        void ExcluirUsuario(Usuario usuario);

        [OperationContract]
        List<Usuario> ListarUsuario(Usuario usuario);

        #endregion

        #region DisciplinaTurma
        [OperationContract]
        void InserirDisciplinaTurma(Disciplina_Turma dt);

        [OperationContract]
        List<Disciplina_Turma> ListarDisciplinaTurma(Disciplina_Turma dt);
        
        #endregion
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
   
}
