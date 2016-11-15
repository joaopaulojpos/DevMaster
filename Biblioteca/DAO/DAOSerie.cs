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
    public class DAOSerie : ConexaoBanco, InterfaceSerie
    {
        public void Alterar(Serie serie)
        {
            try
            {
                this.abrirConexao();
                string sql = "update serie set descricao_serie=@descricaoSerie where cod_serie = @codigoSerie";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoSerie", SqlDbType.Int);
                cmd.Parameters["@codigoSerie"].Value = serie.CodigoSerie;

                cmd.Parameters.Add("@descricaoSerie", SqlDbType.VarChar);
                cmd.Parameters["@descricaoSerie"].Value = serie.DescricaoSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void Excluir(Serie serie)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from serie where cod_serie = @codigoSerie";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoSerie", SqlDbType.Int);
                cmd.Parameters["@codigoSerie"].Value = serie.CodigoSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void Inserir(Serie serie)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERTO INTO Serie (descricao_serie) VALUES (@descricao_serie)"; 

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@descricao_serie", SqlDbType.VarChar);
                cmd.Parameters["@descricao_serie"].Value = serie.DescricaoSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Serie> Listar(Serie filtro)
        {
            List<Serie> retorno = new List<Serie>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_serie,descricao_serie FROM serie where cod_serie = cod_serie";
                if (filtro.CodigoSerie> 0)
                {
                    sql += " and cod_serie = @codigoSerie";
                }
                if (filtro.DescricaoSerie != null && filtro.DescricaoSerie.Trim().Equals("") == false)
                {
                    sql += " and descricao_serie like '%" + filtro.DescricaoSerie.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoSerie > 0)
                {
                    cmd.Parameters.Add("@codigoSerie", SqlDbType.Int);
                    cmd.Parameters["@codigoSerie"].Value = filtro.CodigoSerie;
                }
                if (filtro.DescricaoSerie != null && filtro.DescricaoSerie.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricaoSerie", SqlDbType.VarChar);
                    cmd.Parameters["@descricaoSerie"].Value = filtro.DescricaoSerie;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Serie serie = new Serie();
                    serie.CodigoSerie = DbReader.GetInt32(DbReader.GetOrdinal("cod_serie"));
                    serie.DescricaoSerie = DbReader.GetString(DbReader.GetOrdinal("descricao_serie"));
                    retorno.Add(serie);
                }
                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Serie serie)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_serie FROM serie where cod_serie = @codigoSerie";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@codigoSerie", SqlDbType.Int);
                cmd.Parameters["@codigoSerie"].Value = serie.CodigoSerie;

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }
                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
    }
}
