using Biblioteca.Basicas;
using Biblioteca.RN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class Fachada
    {
        #region Atributos
        private static Fachada instance;

        private RNAluno rnAluno;
        private RNAula rnAula;
        private RNAvaliacao rnAvaliacao;
        private RNDisciplina rnDisciplina;
        private RNEnsino rnEnsino;
        private RNFalta rnFalta;
        private RNTurma rnTurma;
        private RNUsuario rnUsuario;
        private RNDisciplinaTurma rnDt;
        private RNTipoUsuario rnTipoUsuario;

        #endregion

        #region Construtor privado
        private Fachada()
        {
            rnAluno = new RNAluno();
            rnAula = new RNAula();
            rnAvaliacao = new RNAvaliacao();
            rnDisciplina = new RNDisciplina();
            rnEnsino = new RNEnsino();
            rnFalta = new RNFalta();
            rnTurma = new RNTurma();
            rnUsuario = new RNUsuario();
            rnDt = new RNDisciplinaTurma();
            rnTipoUsuario = new RNTipoUsuario();
        }
        #endregion

        #region Método Singleton
        public static Fachada Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Fachada();
                }
                return instance;
            }
        }
        #endregion

        #region Aluno
        public void InserirAluno(Aluno aluno)
        {
            rnAluno.inserir(aluno);
        }
        public void AlterarAluno(Aluno aluno)
        {
            rnAluno.alterar(aluno);
        }
        public void ExcluirAluno(Aluno aluno)
        {
            rnAluno.excluir(aluno);
        }
        public List<Aluno> ListarAluno(Aluno aluno)
        {
            return rnAluno.listar(aluno);
        }
        #endregion

        #region Aula
        public void InserirAula(Aula aula)
        {
            rnAula.inserir(aula);
        }
        public void AlterarAula(Aula aula)
        {
            rnAula.alterar(aula);
        }
        public void ExcluirAula(Aula aula)
        {
            rnAula.excluir(aula);
        }
        public List<Aula> ListarAula(Aula aula)
        {
            return rnAula.listar(aula);
        }
        #endregion

        #region Avaliação
        public void InserirAvaliacao(Avaliacao avaliacao)
        {
            rnAvaliacao.inserir(avaliacao);
        }
        public void AlterarAvaliacao(Avaliacao avaliacao)
        {
            rnAvaliacao.alterar(avaliacao);
        }
        public void ExcluirAvaliacao(Avaliacao avaliacao)
        {
            rnAvaliacao.excluir(avaliacao);
        }
        public List<Avaliacao> ListarAvaliacao(Avaliacao avaliacao)
        {
            return rnAvaliacao.listar(avaliacao);
        }
        #endregion

        #region Disciplina

        public List<Disciplina> ListarDisciplina(Disciplina disciplina)
        {
            return rnDisciplina.listar(disciplina);
        }
        #endregion

        #region Ensino

        public List<Ensino> ListarEnsino(Ensino ensino)
        {
            return rnEnsino.Listar(ensino);
        }
        #endregion

        #region Falta
        public void InserirFalta(Falta falta)
        {
            rnFalta.inserir(falta);
        }
        public void AlterarFalta(Falta falta)
        {
            rnFalta.alterar(falta);
        }
        public void ExcluirFalta(Falta falta)
        {
            rnFalta.excluir(falta);
        }
        public List<Falta> ListarFalta(Falta falta)
        {
            return rnFalta.listar(falta);
        }
        #endregion

        #region Turma
        public void InserirTurma(Turma turma)
        {
            rnTurma.Inserir(turma);
        }
        public void AlterarTurma(Turma turma)
        {
            rnTurma.Alterar(turma);
        }
        public void ExcluirTurma(Turma turma)
        {
            rnTurma.Excluir(turma);
        }
        public List<Turma> ListarTurma(Turma turma)
        {
            return rnTurma.Listar(turma);
        }
        #endregion

        #region Tipo Usuário

        public List<TipoUsuario> ListarTipoUsuario(TipoUsuario tipoUsuario)
        {
            return rnTipoUsuario.Listar(tipoUsuario);
        }


        #endregion

        #region Usuário
        public void InserirUsuario(Usuario usuario)
        {
            rnUsuario.inserir(usuario);
        }
        public void AlterarUsuario(Usuario usuario)
        {
            rnUsuario.alterar(usuario);
        }
        public void ExcluirUsuario(Usuario usuario)
        {
            rnUsuario.excluir(usuario);
        }
        public List<Usuario> ListarUsuario(Usuario usuario)
        {
            return rnUsuario.listar(usuario);
        }
        #endregion

        #region DisciplinaTurma
        public void InserirDisciplinaTurma(Disciplina_Turma dt)
        {
            rnDt.inserir(dt);
        }
        public List<Disciplina_Turma> ListarDisciplinaTurma(Disciplina_Turma dt)
        {
            return rnDt.listar(dt);
        }
        #endregion
    }
}
