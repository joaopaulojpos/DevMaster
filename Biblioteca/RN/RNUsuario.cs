using Biblioteca.Basicas;
using Biblioteca.DAO;
using Biblioteca.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNUsuario
    {
        private DAOUsuario daoUsuario;

        public RNUsuario()
        {
            daoUsuario = new DAOUsuario();
        }

        #region Métodos Principais

        public void inserir(Usuario usuario)
        {
            validar(usuario);
            duplicidade(usuario);
            gravar(usuario);
        }
        public void alterar(Usuario usuario)
        {
            validar(usuario);
            atualizar(usuario);
        }

        public void excluir(Usuario usuario)
        {
            existe(usuario);
            apagar(usuario);
        }

        public List<Usuario> listar(Usuario usuario) {
            return lista(usuario);
        }

        #endregion

        #region Métodos auxiliares 
        private void gravar(Usuario usuario)
        {
            try {
                daoUsuario.Inserir(usuario);
                throw new ValidacaoException(""); //Leandro: Esse throw é aqui msm ou foi engano?
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

        private void validar(Usuario usuario)
        {
            if (usuario==null)
            {
                throw new ValidacaoException();
            }
            if (usuario.Nome.Trim().Length<4|| usuario.Nome.Trim().Length > 100)
            {
                throw new ValidacaoException("Nome de usuário inválido. Minimo:4 , Máximo:100");
            }
            if (usuario.LoginUsuario.Trim().Length < 4 || usuario.LoginUsuario.Trim().Length > 100)
            {
                throw new ValidacaoException("Login para usuário inválido. Minimo:4 , Máximo:100");
            }
            if (usuario.Senha.Trim().Length < 5 || usuario.LoginUsuario.Trim().Length > 20)
            {
                throw new ValidacaoException("Senha para usuário inválida. Minimo:5 , Máximo:20");
            }
        }


        private void duplicidade(Usuario usuario)
        {
            try
            {
                if (daoUsuario.VerificaDuplicidade(usuario))
                {
                    throw new ValidacaoException("Usuário já existe no sistema.");
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

        private void atualizar(Usuario usuario)
        {
            try
            {
                daoUsuario.Alterar(usuario);
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

        private void existe(Usuario usuario)
        {
            try
            {
                if (daoUsuario.VerificaDuplicidade(usuario)==false)
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

        private void apagar(Usuario usuario)
        {
            try
            {
                daoUsuario.Excluir(usuario);
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

        private List<Usuario> lista(Usuario usuario)
        {
            try {
                return daoUsuario.Listar(usuario);
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
