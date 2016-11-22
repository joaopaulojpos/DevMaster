using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNDisciplina
    {
        private DAODisciplina dao;

        public RNDisciplina()
        {
            dao = new DAODisciplina();
        }

        #region Métodos Princiapais
        public List<Disciplina> listar(Disciplina disciplina)
        {
            return lista(disciplina);
        }
        #endregion

        #region Métodos Auxiliares
        
        //<summary>
        //
        //</summary>
        private List<Disciplina> lista(Disciplina disciplina)
        {
            try
            {
                return dao.Listar(disciplina);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
