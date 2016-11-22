using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNTurma
    {
        private DAOTurma dao;

        public RNTurma()
        {
            dao = new DAOTurma();
        }
        #region Métodos Principais

        public void inserir(Turma turma)
        {
            validar(turma);
            duplicidade(turma);
            gravar(turma);
        }
        public void alterar(Turma turma)
        {
            validar(turma);
            atualizar(turma);
        }

        public void excluir(Turma turma)
        {
            existe(turma);
            apagar(turma);
        }

        public List<Turma> listar(Turma turma)
        {
            return lista(turma);
        }

        #endregion


        #region Métodos auxiliares 

        private void gravar(Turma turma)
        {
            try
            {
                dao.Inserir(turma);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir turma.\nErro: " + ex.Message);
            }
        }

        private void validar(Turma turma)
        {

            if (turma == null)
            {
                throw new Exception("Impossível efetuar registro.");
            }
            if (turma.Ano < 0)
            {
                throw new Exception("Campo 'ano' inválido.");
            }
            if(turma.Ensino.CodigoEnsino < 0)
            {
                throw new Exception("Campo 'ensino' inválido.");
            }
        }


        private void duplicidade(Turma turma)
        {
            try
            {
                if (dao.VerificaDuplicidade(turma))
                {
                    throw new Exception("Turma já existe no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void atualizar(Turma turma)
        {
            try
            {
                dao.Alterar(turma);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar Turma.\nErro: " + ex.Message);
            }
        }

        private void existe(Turma turma)
        {
            try
            {
                if (dao.VerificaDuplicidade(turma) == false)
                {
                    throw new Exception("Turma não existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Turma turma)
        {
            try
            {
                dao.Excluir(turma);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Turma> lista(Turma turma)
        {
            try
            {
                return dao.Listar(turma);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
