using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNAvaliacao
    {
        private DAOAvaliacao dao;

        public RNAvaliacao()
        {
            dao = new DAOAvaliacao();
        }

        #region Métodos Principais

        public void inserir(Avaliacao avaliacao)
        {
            validar(avaliacao);
            duplicidade(avaliacao);
            gravar(avaliacao);
        }
        public void alterar(Avaliacao avaliacao)
        {
            validar(avaliacao);
            atualizar(avaliacao);
        }

        public void excluir(Avaliacao avaliacao)
        {
            existe(avaliacao);
            apagar(avaliacao);
        }

        public List<Avaliacao> listar(Avaliacao avaliacao)
        {
            return lista(avaliacao);
        }

        #endregion


        #region Métodos auxiliares 

        private void gravar(Avaliacao avaliacao)
        {
            try
            {
                dao.Inserir(avaliacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao registrar avaliação.\nErro: " + ex.Message);
            }
        }

        private void validar(Avaliacao avaliacao)
        {

            if (avaliacao == null)
            {
                throw new Exception("Impossível efetuar registro.");
            }
            if (avaliacao.Nota <= 0)
            {
                throw new Exception("Nota inválida.");
            }
            if (avaliacao.Nota > 10)
            {
                throw new Exception("Nota inválida.");
            }
            if (avaliacao.Descricao.Equals(""))
            {
                throw new Exception("Tipo de Avaliação inválido");
            }
        }


        private void duplicidade(Avaliacao avaliacao)
        {
            try
            {
                if (dao.VerificaDuplicidade(avaliacao))
                {
                    throw new Exception(avaliacao.Descricao+" já registrada para este aluno.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void atualizar(Avaliacao avaliacao)
        {
            try
            {
                dao.Alterar(avaliacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar a avaliação.\nErro: " + ex.Message);
            }
        }

        private void existe(Avaliacao avaliacao)
        {
            try
            {
                if (dao.VerificaDuplicidade(avaliacao) == false)
                {
                    throw new Exception("Avaliacao não encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Avaliacao avaliacao)
        {
            try
            {
                dao.Excluir(avaliacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Avaliacao> lista(Avaliacao avaliacao)
        {
            try
            {
                return dao.Listar(avaliacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
