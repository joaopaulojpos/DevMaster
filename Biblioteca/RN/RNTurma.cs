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

        public void Inserir(Turma turma)
        {
            Validar(turma);
            Duplicidade(turma);
            Gravar(turma);
        }
        public void Alterar(Turma turma)
        {
            Validar(turma);
            Atualizar(turma);
        }

        public void Excluir(Turma turma)
        {
            Existe(turma);
            Apagar(turma);
        }

        public List<Turma> Listar(Turma turma)
        {
            return Lista(turma);
        }

        #endregion


        #region Métodos auxiliares 

        private void Gravar(Turma turma)
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

        private void Validar(Turma turma)
        {
            if (turma == null)
            {
                throw new Exception("A turma não pode ser Nulo.");
            }

            if (turma.DescricaoTurma == null || turma.DescricaoTurma.Trim() == "")
            {
                throw new Exception("O campo Descrição não pode ser nulo.");
            }

            if (Convert.ToString(turma.Ano) == null || (Convert.ToString(turma.Ano) == ""))
            {
                throw new Exception("Preencha o campo Ano.");
            }

            if (turma.Ano < 1 || turma.Ano > 9)
            {
                throw new Exception("Campo 'ano' inválido.");
            }

            if (turma.DataInicio == null)
            {
                throw new Exception("O campo Data não pode ser nulo.");
            }

            if(turma.Ensino.CodigoEnsino < 0)
            {
                throw new Exception("Campo 'ensino' inválido.");
            }
        }


        private void Duplicidade(Turma turma)
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

        private void Atualizar(Turma turma)
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

        private void Existe(Turma turma)
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

        private void Apagar(Turma turma)
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

        private List<Turma> Lista(Turma turma)
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
