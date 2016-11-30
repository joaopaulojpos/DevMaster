using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNDisciplinaTurma
    {
        DAODisciplinaTurma dao;

        public RNDisciplinaTurma()
        {
            dao = new DAODisciplinaTurma();
        }

        #region Métodos Princiapais
        public void inserir(Disciplina_Turma dt)
        {
            validar(dt);
            duplicidade(dt);
            gravar(dt);
        }

        public List<Disciplina_Turma> listar(Disciplina_Turma dt)
        {
            return lista(dt);
        }
        #endregion

        #region Métodos Auxiliares

        private void gravar(Disciplina_Turma dt)
        {
            try
            {
                dao.Inserir(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void validar(Disciplina_Turma dt)
        {
            if (dt.Disciplina.CodigoDisciplina <= 0)
            {
                throw new Exception("Disciplina inválida");
            }
            if (dt.Turma.CodigoTurma <= 0)
            {
                throw new Exception("Turma inválida");
            }
        }

        private void duplicidade(Disciplina_Turma dt)
        {
            if (dao.VerificaDuplicidade(dt))
            {
                throw new Exception("Disciplina "+dt.Disciplina.NomeDisciplina+" já cadastrada na turma");
            }
        }

        private List<Disciplina_Turma> lista(Disciplina_Turma dt)
        {
            try
            {
                return dao.Listar(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
