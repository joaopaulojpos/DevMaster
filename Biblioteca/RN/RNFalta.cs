using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    class RNFalta
    {
        private DAOFalta dao;

        public RNFalta()
        {
            dao = new DAOFalta();
        }

        #region Métodos Principais

        public void inserir(Falta falta)
        {
            validar(falta);
            duplicidade(falta);
            gravar(falta);
        }
        public void alterar(Falta falta)
        {
            validar(falta);
            atualizar(falta);
        }

        public void excluir(Falta falta)
        {
            existe(falta);
            apagar(falta);
        }

        public List<Falta> listar(Falta falta)
        {
            return lista(falta);
        }

        #endregion


        #region Métodos auxiliares 

        private void gravar(Falta falta)
        {
            try
            {
                dao.Inserir(falta);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao registrar falta.\nErro: " + ex.Message);
            }
        }

        private void validar(Falta falta)
        {

            if (falta == null)
            {
                throw new Exception("Impossível efetuar registro.");
            }
            if (falta.Aula.CodigoAula < 0)
            {
                throw new Exception("Aula inválida.");
            }
            if (falta.Aluno.Matricula.Length < 0)
            {
                throw new Exception("Matrícula do aluno inválida.");
            }
        }


        private void duplicidade(Falta falta)
        {
            try
            {
                if (dao.VerificaDuplicidade(falta))
                {
                    throw new Exception("Falta já registrada para este aluno.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void atualizar(Falta falta)
        {
            try
            {
                dao.Alterar(falta);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar a falta.\nErro: " + ex.Message);
            }
        }

        private void existe(Falta falta)
        {
            try
            {
                if (dao.VerificaDuplicidade(falta) == false)
                {
                    throw new Exception("Falta não encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Falta falta)
        {
            try
            {
                dao.Excluir(falta);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Falta> lista(Falta falta)
        {
            try
            {
                return dao.Listar(falta);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
