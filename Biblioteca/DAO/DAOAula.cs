using Biblioteca.Basicas;
using Biblioteca.Interfaces;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DAO
{
    class DAOAula: ConexaoBanco, InterfaceAula
    {
        #region Implementação da Interface
        public void Alterar(Aula aula)
        {

            try
            {
                this.abrirConexao();
                string sql = "update aula set data=@data,assunto=@assunto where cod_aula = @codigoAula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = aula.CodigoAula;

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = aula.Data;

                cmd.Parameters.Add("@assunto", SqlDbType.VarChar);
                cmd.Parameters["@assunto"].Value = aula.Assunto;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Aula aula)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from aula where cod_aula = @codigoAula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = aula.CodigoAula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Aula aula)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into aula (data,assunto) values(@data,@assunto)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = aula.Data;

                cmd.Parameters.Add("@assunto", SqlDbType.VarChar);
                cmd.Parameters["@assunto"].Value = aula.Assunto;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Aula> Listar(Aula filtro)
        {
            List<Aula> retorno = new List<Aula>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_aula,data,assunto FROM aula where cod_aula = cod_aula";

                if (filtro.Data.Length > 0)
                {
                    sql += " and cod_aula = @codigoAula";
                }
                
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Data.Length > 0)
                {
                    cmd.Parameters.Add("@data", SqlDbType.Int);
                    cmd.Parameters["@data"].Value = filtro.Data;
                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aula aula = new Aula();
                    aula.CodigoAula = DbReader.GetInt32(DbReader.GetOrdinal("cod_aula"));
                    aula.Data = DbReader.GetDateTime(DbReader.GetOrdinal("data")).ToString();
                    aula.Assunto = DbReader.GetString(DbReader.GetOrdinal("assunto"));

                    retorno.Add(aula);
                }
                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Aula aula)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT data FROM aula where data = @data";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@data", SqlDbType.Int);
                cmd.Parameters["@data"].Value = aula.Data;

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
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
            return retorno;
        }
        #endregion
    }
}
