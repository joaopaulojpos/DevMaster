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
        public void Alterar(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "update ensino set descricao_ensino = @descricaoEnsino where cod_ensino = @codigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoEnsino", SqlDbType.Int);
                cmd.Parameters["@codigoEnsino"].Value = ensino.CodigoEnsino;

                cmd.Parameters.Add("@descricaoEnsino", SqlDbType.VarChar);
                cmd.Parameters["@descricaoEnsino"].Value = ensino.DescricaoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void Excluir(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from ensino where cod_ensino = @codigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoEnsino", SqlDbType.Int);
                cmd.Parameters["@codigoEnsino"].Value = ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void Inserir(Ensino ensino)
        {
            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Ensino (descricao_ensino) VALUES (@descricaoEnsino)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@descricaoEnsino", SqlDbType.VarChar);
                cmd.Parameters["@descricaoEnsino"].Value = ensino.DescricaoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Ensino> Listar(Ensino filtro)
        {
            List<Ensino> retorno = new List<Ensino>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_ensino,descricao_ensino FROM ensino where cod_ensino = cod_ensino";
                if (filtro.CodigoEnsino > 0)
                {
                    sql += " and cod_ensino = @codigoEnsino";
                }
                if (filtro.DescricaoEnsino != null && filtro.DescricaoEnsino.Trim().Equals("") == false)
                {
                    sql += " and descricao_ensino like '%" + filtro.DescricaoEnsino.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoEnsino > 0)
                {
                    cmd.Parameters.Add("@codigoEnsino", SqlDbType.Int);
                    cmd.Parameters["@codigoEnsino"].Value = filtro.CodigoEnsino;
                }
                if (filtro.DescricaoEnsino != null && filtro.DescricaoEnsino.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricaoEnsino", SqlDbType.VarChar);
                    cmd.Parameters["@descricaoEnsino"].Value = filtro.DescricaoEnsino;

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
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Ensino ensino)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_ensino FROM ensino where cod_ensino = @codigoEnsino";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@codigoEnsino", SqlDbType.Int);
                cmd.Parameters["@codigoEnsino"].Value = ensino.CodigoEnsino;

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
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
    }
    #endregion
}
