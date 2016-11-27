using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;
using Biblioteca.Util;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.DAO
{
    public class DAOTurma : ConexaoBanco, InterfaceTurma
    {
        #region Implementação da Interface

        #region Alterar

        public void Alterar(Turma turma)
        {

            try
            {
                this.AbrirConexao();
                string sql = "update turma set descricao_turma=@descricaoTurma,turno=@turno,ano=@ano,data_inicio=@dataInicio,codEnsino=@codEnsino where cod_turma = @codigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = turma.CodigoTurma;

                cmd.Parameters.Add("@descricao_turma", SqlDbType.VarChar);
                cmd.Parameters["@descricao_turma"].Value = turma.DescricaoTurma;

                cmd.Parameters.Add("@turno", SqlDbType.Char);
                cmd.Parameters["@turno"].Value = turma.Turno;

                cmd.Parameters.Add("@ano", SqlDbType.Int);
                cmd.Parameters["@ano"].Value = turma.Ano;

                cmd.Parameters.Add("@dataInicio", SqlDbType.Date);
                cmd.Parameters["@dataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@codEnsino", SqlDbType.Int);
                cmd.Parameters["@codEnsino"].Value = turma.Ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Excluir

        public void Excluir(Turma turma)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from turma where cod_turma = @codigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Inserir

        public void Inserir(Turma turma)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into turma (descricao,turno,ano,data_inicio,cod_ensino) values(@descricao,@turno,@ano,@dataInicio,@codEnsino)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = turma.CodigoTurma;

                cmd.Parameters.Add("@turno", SqlDbType.Char);
                cmd.Parameters["@turno"].Value = turma.Turno;

                cmd.Parameters.Add("@ano", SqlDbType.Int);
                cmd.Parameters["@ano"].Value = turma.Ano;

                cmd.Parameters.Add("@dataInicio", SqlDbType.VarChar);
                cmd.Parameters["@dataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@codEnsino", SqlDbType.Int);
                cmd.Parameters["@codEnsino"].Value = turma.Ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Listar

        public List<Turma> Listar(Turma filtro)
        {
            try
            {
                List<Turma> retorno = new List<Turma>();

                this.AbrirConexao();

                string sql = "SELECT T.cod_turma, T.descricao_turma, T.turno, T.ano, T.data_inicio, E.descricao_ensino FROM Turma as T INNER JOIN Ensino as E ON T.cod_ensino = E.cod_ensino";

                if (filtro.CodigoTurma > 0)
                {
                    sql += " AND T.cod_turma = @codigoTurma";
                }
                if (filtro.DescricaoTurma != null && filtro.DescricaoTurma.Trim().Equals("") == false)
                {
                    sql += " AND T.descricao_turma like '%" + filtro.DescricaoTurma.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoTurma > 0)
                {
                    cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                    cmd.Parameters["@codigoTurma"].Value = filtro.CodigoTurma;
                }
                if (filtro.DescricaoTurma != null && filtro.DescricaoTurma.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricaoTurma", SqlDbType.VarChar);
                    cmd.Parameters["@descricaoTurma"].Value = filtro.DescricaoTurma;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Turma t = new Turma();
                    Ensino e = new Ensino();
                    t.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    t.DataInicio = DbReader.GetDateTime(DbReader.GetOrdinal("data_inicio"));
                    t.Turno = DbReader.GetString(DbReader.GetOrdinal("turno"));
                    t.Ano= DbReader.GetInt32(DbReader.GetOrdinal("ano"));
                    e.DescricaoEnsino = DbReader.GetString(DbReader.GetOrdinal("descricao_ensino"));
                    t.Ensino = e;

                    retorno.Add(t);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();

                return retorno;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Verifica Duplicidade

        public bool VerificaDuplicidade(Turma turma)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT descricao_turma FROM turma where descricao_turma = @descricaoTurma";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@descricaoTurma", SqlDbType.VarChar);
                cmd.Parameters["@descricaoTurma"].Value = turma.DescricaoTurma;

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
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #endregion
    }
}
