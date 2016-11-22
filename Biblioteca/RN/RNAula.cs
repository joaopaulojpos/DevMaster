using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;

namespace Biblioteca.RN
{
    public class RNAula
    {
        private DAOAula dao;

        public RNAula()
        {
            dao = new DAOAula();
        }
        #region Métodos Principais

        public void inserir(Aula aula)
        {
            validar(aula);
            duplicidade(aula);
            gravar(aula);
        }
        public void alterar(Aula aula)
        {
            validar(aula);
            atualizar(aula);
        }

        public void excluir(Aula aula)
        {
            existe(aula);
            apagar(aula);
        }

        public List<Aula> listar(Aula aula)
        {
            return lista(aula);
        }

        #endregion


        #region Métodos auxiliares 

        private void gravar(Aula aula)
        {
            try
            {
                dao.Inserir(aula);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao registrar aula.\nErro: " + ex.Message);
            }
        }

        private void validar(Aula aula)
        {

            if (aula == null)
            {
                throw new Exception("Impossível efetuar registro.");
            }
        }


        private void duplicidade(Aula aula)
        {
            try
            {
                if (dao.VerificaDuplicidade(aula))
                {
                    throw new Exception("Aula já registrada para este dia.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void atualizar(Aula aula)
        {
            try
            {
                dao.Alterar(aula);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar a aula.\nErro: " + ex.Message);
            }
        }

        private void existe(Aula aula)
        {
            try
            {
                if (dao.VerificaDuplicidade(aula) == false)
                {
                    throw new Exception("Aula não encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Aula aula)
        {
            try
            {
                dao.Excluir(aula);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Aula> lista(Aula aula)
        {
            try
            {
                return dao.Listar(aula);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
