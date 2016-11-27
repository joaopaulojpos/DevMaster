using Biblioteca.Basicas;
using Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteca.RN
{
    public class RNAluno
    {
        private DAOAluno daoAluno;

        public RNAluno()
        {
            daoAluno = new DAOAluno();
        }

        #region Métodos Principais

        public void inserir(Aluno aluno)
        {
            validar(aluno);
            duplicidade(aluno);
            gravar(aluno);
        }
        public void alterar(Aluno aluno)
        {
            validar(aluno);
            atualizar(aluno);
        }

        public void excluir(Aluno aluno)
        {
            existe(aluno);
            apagar(aluno);
        }

        public List<Aluno> listar(Aluno aluno)
        {
            return lista(aluno);
        }

        #endregion


        #region Métodos auxiliares 

        private void gravar(Aluno aluno)
        {
            try
            {
                daoAluno.Inserir(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir Aluno.\nErro: " + ex.Message);
            }
        }

        private void validar(Aluno aluno)
        {

            if (aluno == null)
            {
                throw new Exception("Aluno nulo.");
            }
            if (aluno.Matricula == null || aluno.Matricula.Trim().Length < 0)
            {
                throw new Exception("Preencha o campo Matrícula.");
            }
            if (aluno.Nome.Trim().Length < 4 || aluno.Nome.Trim().Length > 100)
            {
                throw new Exception("Nome do aluno inválido. Minimo:4 , Máximo:100");
            }
            if (!aluno.Sexo.Equals("M") && !aluno.Sexo.Equals("F"))
            {
                throw new Exception("Campo Sexo inválido.");
            }

            String regex = @"^9.\\d{4}-\\d{4}$";
            Regex er = new Regex(regex);
            //if (aluno.Telefone != null)
            if (!er.IsMatch(aluno.Telefone))
            {
                throw new Exception("Telefone inválido.");
            }

        }


        private void duplicidade(Aluno aluno)
        {
            try
            {
                if (daoAluno.VerificaDuplicidade(aluno))
                {
                    throw new Exception("Este Aluno já existe no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void atualizar(Aluno aluno)
        {
            try
            {
                daoAluno.Alterar(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar Aluno.\nErro: " + ex.Message);
            }
        }

        private void existe(Aluno aluno)
        {
            try
            {
                if (daoAluno.VerificaDuplicidade(aluno) == false)
                {
                    throw new Exception("Aluno nao existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void apagar(Aluno aluno)
        {
            try
            {
                daoAluno.Excluir(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Aluno> lista(Aluno aluno)
        {
            try
            {
                return daoAluno.Listar(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        #endregion
    }
}
