using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Util;
using Biblioteca.Interfaces;
using Biblioteca.Basicas;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.DAO
{
    public class DAOEnsino : ConexaoBanco, InterfaceEnsino
    {

        #region Singleton(Não está sendo usado, mas caso for usar tá aqui comentado)
        //private static DAOEnsino instancia;

        //private DAOEnsino() { }

        //public static DAOEnsino Instancia
        //{
        //    get
        //    {
        //        if (instancia == null)
        //        {
        //            instancia = new DAOEnsino();
        //        }
        //        return instancia;
        //    }
        //}
        #endregion

        #region Implementação da Interface

        #region Alterar

        public void Alterar(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "update ensino set descricao_ensino = @DescricaoEnsino where cod_ensino = @CodigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoEnsino", SqlDbType.Int);
                cmd.Parameters["@CodigoEnsino"].Value = ensino.CodigoEnsino;

                cmd.Parameters.Add("@DescricaoEnsino", SqlDbType.VarChar);
                cmd.Parameters["@DescricaoEnsino"].Value = ensino.DescricaoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Alterar o Ensino.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Excluir

        public void Excluir(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from ensino where cod_ensino = @CodigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@CodigoEnsino", SqlDbType.Int);
                cmd.Parameters["@CodigoEnsino"].Value = ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Nâo foi possível Excluir o Ensino.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Inserir

        public void Inserir(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Ensino (descricao_ensino) VALUES (@DescricaoEnsino)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@DescricaoEnsino", SqlDbType.VarChar);
                cmd.Parameters["@DescricaoEnsino"].Value = ensino.DescricaoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Inserir o Ensino.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Listar

        public List<Ensino> Listar(Ensino filtro)
        {
            List<Ensino> retorno = new List<Ensino>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_ensino,descricao_ensino FROM ensino where cod_ensino = cod_ensino";
                
                if (filtro.CodigoEnsino > 0)
                {
                    sql += " and cod_ensino = @CodigoEnsino";
                }
                if (filtro.DescricaoEnsino != null && filtro.DescricaoEnsino.Trim().Equals("") == false)
                {
                    sql += " and descricao_ensino like '%" + filtro.DescricaoEnsino.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoEnsino > 0)
                {
                    cmd.Parameters.Add("@CodigoEnsino", SqlDbType.Int);
                    cmd.Parameters["@CodigoEnsino"].Value = filtro.CodigoEnsino;
                }
                if (filtro.DescricaoEnsino != null && filtro.DescricaoEnsino.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@DescricaoEnsino", SqlDbType.VarChar);
                    cmd.Parameters["@DescricaoEnsino"].Value = filtro.DescricaoEnsino;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Ensino ensino = new Ensino();
                    ensino.CodigoEnsino = DbReader.GetInt32(DbReader.GetOrdinal("cod_ensino"));
                    ensino.DescricaoEnsino = DbReader.GetString(DbReader.GetOrdinal("descricao_ensino"));
                    retorno.Add(ensino);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Listar os Ensinos.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #region Verifica Duplicidade 

        public bool VerificaDuplicidade(Ensino ensino)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_ensino FROM ensino where cod_ensino = @CodigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@CodigoEnsino", SqlDbType.Int);
                cmd.Parameters["@CodigoEnsino"].Value = ensino.CodigoEnsino;

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Verificar Duplicidade do Ensino.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #endregion

    }
}
