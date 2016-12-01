using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;
using Biblioteca.DAO;

namespace Biblioteca.RN
{
    public class RNTipoUsuario
    {
        #region Atributos

        DAOTipoUsuario daoTipoUsuario;

        #endregion

        #region Construtor

        public RNTipoUsuario()
        {
            daoTipoUsuario = new DAOTipoUsuario();
        }

        #endregion

        #region Métodos Principais

        public List<TipoUsuario> Listar(TipoUsuario tipoUsuario)
        {
            return Listar2(tipoUsuario);
        }

        #endregion

        #region Métodos Auxiliares

        private List<TipoUsuario> Listar2(TipoUsuario tipoUsuario)
        {
            try
            {
                return daoTipoUsuario.Listar(tipoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível validar Listagem.\nErro: " + ex.Message);
            }
        }

        #endregion

    }
}
