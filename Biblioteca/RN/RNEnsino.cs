using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;
using Biblioteca.DAO;

namespace Biblioteca.RN
{
    public class RNEnsino
    {
        #region Atributos

        private DAOEnsino daoEnsino;

        #endregion


        #region Construtor

        public RNEnsino()
        {
            daoEnsino = new DAOEnsino();
        }

        #endregion

        #region Métodos Principais

        //public void Inserir(Ensino ensino)
        //{
        //    Validar(ensino);
        //    Duplicidade(ensino);
        //    Gravar(ensino);
        //}
        //public void Alterar(Ensino ensino)
        //{
        //    Validar(ensino);
        //    Atualizar(ensino);
        //}

        //public void Excluir(Ensino ensino)
        //{
        //    Existe(ensino);
        //    Apagar(ensino);
        //}

        public List<Ensino> Listar(Ensino ensino)
        {
            ensino.DescricaoEnsino = Acentuacao(ensino);
            return Listar2(ensino);
        }

        #endregion

        #region Métodos auxiliares 

        private string Acentuacao(Ensino ensino)
        {
            string retorno = ensino.DescricaoEnsino;

            if (ensino.DescricaoEnsino == "Medio")
            {
                string ensinoMedioAcento = ensino.DescricaoEnsino.Replace("e", "é");
                retorno = ensinoMedioAcento;
            }
                
                return retorno;
        }

        private void Gravar(Ensino ensino)
        {
            try
            {
                daoEnsino.Inserir(ensino);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir Aluno.\nErro: " + ex.Message);
            }
        }

        private void Validar(Ensino ensino)
        {
            if (ensino == null)
            {
                throw new Exception("Impossível efetuar registro.");
            }
            if (ensino.DescricaoEnsino.Trim().Length < 4 || ensino.DescricaoEnsino.Trim().Length > 100)
            {
                throw new Exception("Nome de ensino inválido. Minimo:4 , Máximo:100");
            }
        }


        private void Duplicidade(Ensino ensino)
        {
            try
            {
                if (daoEnsino.VerificaDuplicidade(ensino))
                {
                    throw new Exception("Ensino já existe no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void Atualizar(Ensino ensino)
        {
            try
            {
                daoEnsino.Alterar(ensino);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void Existe(Ensino ensino)
        {
            try
            {
                if (daoEnsino.VerificaDuplicidade(ensino) == false)
                {
                    throw new Exception("Ensino não existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private void Apagar(Ensino ensino)
        {
            try
            {
                daoEnsino.Excluir(ensino);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        private List<Ensino> Listar2(Ensino ensino)
        {
            try
            {
                return daoEnsino.Listar(ensino);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        #endregion
    }
}