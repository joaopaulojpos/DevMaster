using Biblioteca.Interfaces;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.DAO
{
    public class DAOAluno : ConexaoBanco, InterfaceAluno
    {
        #region Implementação da Interface

        #region Alterar

        public void Alterar(Aluno aluno)
        {
            try
            {
                this.AbrirConexao();
                string sql = "update aluno set matricula = @Matricula,nome_aluno=@Nome,data_nasc=@DataNasc,sexo=@Sexo,telefone=@Telefone,cod_turma=@CodigoTurma where matricula = @Matricula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                cmd.Parameters["@Matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                cmd.Parameters["@Nome"].Value = aluno.Nome;

                cmd.Parameters.Add("@DataNasc", SqlDbType.DateTime);
                cmd.Parameters["@DataNasc"].Value = aluno.DataNasc;

                cmd.Parameters.Add("@Sexo", SqlDbType.Char);
                cmd.Parameters["@Sexo"].Value = aluno.Sexo;

                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar);
                cmd.Parameters["@Telefone"].Value = aluno.Telefone;

                cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                cmd.Parameters["@CodigoTurma"].Value = aluno.Turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Alterar o Aluno.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Excluir

        public void Excluir(Aluno aluno)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from aluno where matricula = @Matricula";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                cmd.Parameters["@Matricula"].Value = aluno.Matricula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Excluir o Aluno.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Inserir

        public void Inserir(Aluno aluno)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into aluno (matricula,nome_aluno,data_nasc,sexo,telefone,cod_turma) values(@Matricula,@Nome,@DataNasc,@Sexo,@Telefone,@CodigoTurma)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                cmd.Parameters["@Matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                cmd.Parameters["@Nome"].Value = aluno.Nome;

                cmd.Parameters.Add("@DataNasc", SqlDbType.DateTime);
                cmd.Parameters["@DataNasc"].Value = aluno.DataNasc;

                cmd.Parameters.Add("@Sexo", SqlDbType.Char);
                cmd.Parameters["@Sexo"].Value = aluno.Sexo;

                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar);
                cmd.Parameters["@Telefone"].Value = aluno.Telefone;

                cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                cmd.Parameters["@CodigoTurma"].Value = aluno.Turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Inserir o Aluno.\nErro: " + ex.Message);
            }
        }

        #endregion

        #region Listar

        public List<Aluno> Listar(Aluno filtro)
        {
            List<Aluno> retorno = new List<Aluno>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT A.matricula, A.nome_aluno, A.data_nasc, A.sexo, A.telefone, T.descricao_turma, T.cod_turma " + 
                             "FROM Aluno A " +
                             "INNER JOIN Turma T " +
                             "ON A.cod_turma = T.cod_turma " +
                             "WHERE matricula = matricula";

                if (filtro.Matricula.Length > 0)
                {
                    sql += " and matricula like '%" + filtro.Matricula.Trim() + "%'";
                }
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome_aluno like '%" + filtro.Nome.Trim() + "%'";
                }
                if (filtro.Turma.CodigoTurma > 0)
                {
                    sql += " and t.cod_turma = @CodigoTurma";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Matricula.Length > 0)
                {
                    cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                    cmd.Parameters["@Matricula"].Value = filtro.Matricula;
                }
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                    cmd.Parameters["@Nome"].Value = filtro.Nome;
                }
                if (filtro.Turma.CodigoTurma > 0)
                {
                    cmd.Parameters.Add("@CodigoTurma", SqlDbType.Int);
                    cmd.Parameters["@CodigoTurma"].Value = filtro.Turma.CodigoTurma;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    aluno.Matricula = DbReader.GetString(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome_aluno"));
                    aluno.DataNasc = DbReader.GetDateTime(DbReader.GetOrdinal("data_nasc"));
                    aluno.Sexo = DbReader.GetString(DbReader.GetOrdinal("sexo"));
                    aluno.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));

                    Turma t = new Turma();
                    t.CodigoTurma= DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));

                    aluno.Turma = t;

                    retorno.Add(aluno);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Listar os Alunos.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #region Verifica Duplicidade

        public bool VerificaDuplicidade(Aluno aluno)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT matricula FROM aluno where matricula = @Matricula";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@Matricula", SqlDbType.Int);
                cmd.Parameters["@Matricula"].Value = aluno.Matricula;

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
                throw new Exception("Não foi possível Verificar a Duplicidade do Aluno.\nErro: " + ex.Message);
            }
            return retorno;
        }

        #endregion

        #endregion
    }
}