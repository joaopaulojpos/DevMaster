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
    public class RNEnsino
    {
        #region Atributos

        private DAOEnsino daoEnsino;

        public RNEnsino()
        {
            daoEnsino = new DAOEnsino();
        }

        #endregion

        #region Métodos Principais

        public void Inserir(Ensino ensino)
        {
            Validar(ensino);
            Duplicidade(ensino);
            Gravar(ensino);
        }
        public void Alterar(Ensino ensino)
        {
            Validar(ensino);
            Atualizar(ensino);
        }

        public void Excluir(Ensino ensino)
        {
            Existe(ensino);
            Apagar(ensino);
        }

        public List<Ensino> Listar(Ensino ensino)
        {
            return Listar2(ensino);
        }

        #endregion

        #region Métodos auxiliares 

        private void Gravar(Ensino ensino)
        {
            try
            {
                daoEnsino.Inserir(ensino);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        private void Validar(Ensino ensino)
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


        private void Duplicidade(Ensino ensino)
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
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        private void Atualizar(Ensino ensino)
        {
            try
            {
                daoEnsino.Alterar(ensino);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        private void Existe(Ensino ensino)
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
                throw new ValidacaoException("Não foi possível conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        private void Apagar(Ensino ensino)
        {
            try
            {
                daoEnsino.Excluir(ensino);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        private List<Ensino> Listar2(Ensino ensino)
        {
            try
            {
                return daoEnsino.Listar(ensino);
            }
            catch (ConexaoException ex)
            {
                throw new ValidacaoException("Não foi possivel conectar ao banco de dados. Erro: " + ex.Message);
            }
            catch (RepositorioException ex)
            {
                throw new ValidacaoException("Consulte o suporte. Erro: " + ex.Message);
            }
        }

        #endregion
    }
}