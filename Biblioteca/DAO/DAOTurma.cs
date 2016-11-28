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
                string sql = "update turma set descricao_turma = @DescricaoTurma, turno = @Turno, ano = @Ano, data_inicio = @DataInicio, cod_ensino = @CodEnsino where cod_turma = @CodigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                cmd.Parameters["@CodigoTurma"].Value = turma.CodigoTurma;

                cmd.Parameters.Add("@DescricaoTurma", SqlDbType.VarChar);
                cmd.Parameters["@DescricaoTurma"].Value = turma.DescricaoTurma;

                cmd.Parameters.Add("@Turno", SqlDbType.Char);
                cmd.Parameters["@Turno"].Value = turma.Turno;

                cmd.Parameters.Add("@Ano", SqlDbType.Int);
                cmd.Parameters["@Ano"].Value = turma.Ano;

                cmd.Parameters.Add("@DataInicio", SqlDbType.Date);
                cmd.Parameters["@DataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@CodEnsino", SqlDbType.Int);
                cmd.Parameters["@CodEnsino"].Value = turma.Ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Alterar a Turma.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Excluir

        public void Excluir(Turma turma)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from turma where cod_turma = @CodigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                cmd.Parameters["@CodigoTurma"].Value = turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Excluir a Turma.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Inserir

        public void Inserir(Turma turma)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into turma (descricao_turma, turno,ano,data_inicio,cod_ensino) values(@Descricao,@Turno,@Ano,@DataInicio,@CodEnsino)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar);
                cmd.Parameters["@Descricao"].Value = turma.DescricaoTurma;

                cmd.Parameters.Add("@Turno", SqlDbType.Char);
                cmd.Parameters["@Turno"].Value = turma.Turno;

                cmd.Parameters.Add("@Ano", SqlDbType.Int);
                cmd.Parameters["@Ano"].Value = turma.Ano;

                cmd.Parameters.Add("@DataInicio", SqlDbType.DateTime);
                cmd.Parameters["@DataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@CodEnsino", SqlDbType.Int);
                cmd.Parameters["@CodEnsino"].Value = turma.Ensino.CodigoEnsino;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Inserir a Turma. Erro:\n" + ex.Message);
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

                string sql = "SELECT T.cod_turma, T.descricao_turma, T.turno, T.ano, T.data_inicio, E.descricao_ensino, E.cod_ensino FROM Turma as T INNER JOIN Ensino as E ON T.cod_ensino = E.cod_ensino";

                if (filtro.CodigoTurma > 0)
                {
                    sql += " AND T.cod_turma = @CodTurma";
                }
                if (filtro.DescricaoTurma != null && filtro.DescricaoTurma.Trim().Equals("") == false)
                {
                    sql += " AND T.descricao_turma like '%@DescricaoTurma%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoTurma > 0)
                {
                    cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                    cmd.Parameters["@CodigoTurma"].Value = filtro.CodigoTurma;
                }
                if (filtro.DescricaoTurma != null && filtro.DescricaoTurma.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@DescricaoTurma", SqlDbType.VarChar);
                    cmd.Parameters["@DescricaoTurma"].Value = filtro.DescricaoTurma;
                }
    
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Turma t = new Turma();
                    t.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    t.DataInicio = DbReader.GetDateTime(DbReader.GetOrdinal("data_inicio"));
                    t.Turno = DbReader.GetString(DbReader.GetOrdinal("turno"));
                    t.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));

                    Ensino e = new Ensino();
                    e.DescricaoEnsino = DbReader.GetString(DbReader.GetOrdinal("descricao_ensino"));
                    e.CodigoEnsino = DbReader.GetInt32(DbReader.GetOrdinal("cod_ensino"));
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
                throw new Exception("Não foi possível Listar as Turmas.\nErro: " + ex.Message);
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
                string sql = "SELECT descricao_turma FROM turma where descricao_turma = @DescricaoTurma";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@DescricaoTurma", SqlDbType.VarChar);
                cmd.Parameters["@DescricaoTurma"].Value = turma.DescricaoTurma;

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
                throw new Exception("Não foi possível verificar a duplicidade da Turma.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #endregion
    }
}
