using Biblioteca.Basicas;
using Biblioteca.DAO;
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
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir Aluno.\nErro: " + ex.Message);
            }
        }

        private void validar(Usuario usuario)
        {
            if (usuario==null)
            {
                throw new Exception("Impossível inserir registro.");
            }
            if (usuario.Nome.Trim().Length<4|| usuario.Nome.Trim().Length > 100)
            {
                throw new Exception("Nome de usuário inválido. Minimo:4 , Máximo:100");
            }
            if (usuario.LoginUsuario.Trim().Length < 4 || usuario.LoginUsuario.Trim().Length > 100)
            {
                throw new Exception("Login para usuário inválido. Minimo:4 , Máximo:100");
            }
            if (usuario.Senha.Trim().Length < 5 || usuario.LoginUsuario.Trim().Length > 20)
            {
                throw new Exception("Senha para usuário inválida. Minimo:5 , Máximo:20");
            }
        }


        private void duplicidade(Usuario usuario)
        {
            try
            {
                if (daoUsuario.VerificaDuplicidade(usuario))
                {
                    throw new Exception("Usuário já existe no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void atualizar(Usuario usuario)
        {
            try
            {
                daoUsuario.Alterar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void existe(Usuario usuario)
        {
            try
            {
                if (daoUsuario.VerificaDuplicidade(usuario)==false)
                {
                    throw new Exception("Usuario nao existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Usuario usuario)
        {
            try
            {
                daoUsuario.Excluir(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Usuario> lista(Usuario usuario)
        {
            try {
                return daoUsuario.Listar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        #endregion
    }
}
