using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;
using Biblioteca.DAO;
using Biblioteca.Erros;

namespace Biblioteca.RN
{
    class RNEnsino : DAOEnsino
    {
        #region Atributos

        private DAOEnsino daoEnsino;

        public RNEnsino()
        {
            daoEnsino = new DAOEnsino();
        }

        #endregion

        #region Métodos Principais
        public void inserir(Ensino ensino)
        {
            validar(ensino);
            duplicidade(ensino);
            gravar(ensino);
        }
        public void alterar(Ensino ensino)
        {
            validar(ensino);
            atualizar(ensino);
        }

        public void excluir(Ensino ensino)
        {
            existe(ensino);
            apagar(ensino);
        }

        public List<Ensino> listar(Ensino ensino)
        {
            return lista(ensino);
        }

        #endregion

        #region Métodos auxiliares 
        private void gravar(Ensino ensino)
        {
            try
            {
                daoEnsino.Inserir(ensino);
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

        private void validar(Ensino ensino)
        {
            if (ensino == null)
            {
                throw new ValidacaoException();
            }
            if (ensino.DescricaoEnsino.Trim().Length < 4 || ensino.DescricaoEnsino.Trim().Length > 100)
            {
                throw new ValidacaoException("Nome de ensino inválido. Minimo:4 , Máximo:100");
            }
        }


        private void duplicidade(Ensino ensino)
        {
            try
            {
                if (daoEnsino.VerificaDuplicidade(ensino))
                {
                    throw new ValidacaoException("Ensino já existe no sistema.");
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

        private void atualizar(Ensino ensino)
        {
            try
            {
                daoEnsino.Alterar(ensino);
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

        private void existe(Ensino ensino)
        {
            try
            {
                if (daoEnsino.VerificaDuplicidade(ensino) == false)
                {
                    throw new ValidacaoException("Ensino não existe");
                }
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possível conectar ao banco de dados.");
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte.");
            }
        }

        private void apagar(Ensino ensino)
        {
            try
            {
                daoEnsino.Excluir(ensino);
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

        private List<Ensino> lista(Ensino ensino)
        {
            try
            {
                return daoEnsino.Listar(ensino);
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
