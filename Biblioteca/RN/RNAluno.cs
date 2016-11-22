using Biblioteca.Basicas;
using Biblioteca.DAO;
using Biblioteca.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNAluno
    {
        private DAOAluno daoAluno;

        public RNAluno()
        {
            daoAluno = new DAOAluno();
        }

        #region Métodos Principais

        public void inserir(Aluno aluno)
        {
            validar(aluno);
            duplicidade(aluno);
            gravar(aluno);
        }
        public void alterar(Aluno aluno)
        {
            validar(aluno);
            atualizar(aluno);
        }

        public void excluir(Aluno aluno)
        {
            existe(aluno);
            apagar(aluno);
        }

        public List<Aluno> listar(Aluno aluno)
        {
            return lista(aluno);
        }

        #endregion


        #region Métodos auxiliares 
      
        private void gravar(Aluno aluno)
        {
            try {
                daoAluno.Inserir(aluno);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private void validar(Aluno aluno)
        {
            
            if (aluno == null)
            {
                throw new ValidacaoException();
            }
            if (aluno.Nome.Trim().Length<4|| aluno.Nome.Trim().Length > 100)
            {
                throw new ValidacaoException("Nome do aluno inválido. Minimo:4 , Máximo:100");
            }
            if (aluno.Matricula.Length<0)
            {
                throw new ValidacaoException("Campo matrícula inválida");
            }
            if (!aluno.Sexo.Equals("M") && !aluno.Sexo.Equals("F"))
            {
                throw new ValidacaoException("Campo sexo inválido.");
            }
            String regex = "^9.\\d{4}-\\d{4}$";
            Regex er = new Regex(regex);
            if (aluno.Telefone != null)
                if (!er.IsMatch(aluno.Telefone))
                    throw new ValidacaoException("Telefone inválido.");
        }


        private void duplicidade(Aluno aluno)
        {
            try
            {
                if (daoAluno.VerificaDuplicidade(aluno))
                {
                    throw new ValidacaoException("Aluno já existe no sistema.");
                }     
            }catch(ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private void atualizar(Aluno aluno)
        {
            try
            {
                daoAluno.Alterar(aluno);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private void existe(Aluno aluno)
        {
            try
            {
                if (daoAluno.VerificaDuplicidade(aluno) ==false)
                {
                    throw new ValidacaoException("Usuario nao existe");
                }
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private void apagar(Aluno aluno)
        {
            try
            {
                daoAluno.Excluir(aluno);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private List<Aluno> lista(Aluno aluno)
        {
            try {
                return daoAluno.Listar(aluno);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        #endregion
    }
}
