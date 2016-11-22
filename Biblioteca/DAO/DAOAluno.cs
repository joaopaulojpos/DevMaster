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
        public void Alterar(Aluno aluno)
        {

            try
            {
                this.AbrirConexao();
                string sql = "update aluno set matricula = @matricula ,nome_aluno=@nome,data_nasc=@dataNasc,sexo=@sexo,telefone=@telefone,cod_turma=@codigoTurma  where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = aluno.Nome;

                cmd.Parameters.Add("@dataNasc", SqlDbType.Date);
                cmd.Parameters["@dataNasc"].Value = aluno.DataNasc;

                cmd.Parameters.Add("@sexo", SqlDbType.Char);
                cmd.Parameters["@sexo"].Value = aluno.Sexo;

                cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
                cmd.Parameters["@telefone"].Value = aluno.Telefone;

                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = aluno.Turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Aluno aluno)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from aluno where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Aluno aluno)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into aluno (matricula,nome_aluno,data_nasc,sexo,telefone,cod_turma) values(@matricula,@nome,@dataNasc,@sexo,@telefone,@codTurma)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = aluno.Nome;

                cmd.Parameters.Add("@dataNasc", SqlDbType.Date);
                cmd.Parameters["@dataNasc"].Value = aluno.DataNasc;

                cmd.Parameters.Add("@sexo", SqlDbType.Char);
                cmd.Parameters["@sexo"].Value = aluno.Sexo;

                cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
                cmd.Parameters["@telefone"].Value = aluno.Telefone;

                cmd.Parameters.Add("@codTurma", SqlDbType.Int);
                cmd.Parameters["@codTurma"].Value = aluno.Turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Aluno> Listar(Aluno filtro)
        {
            List<Aluno> retorno = new List<Aluno>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT matricula,nome_aluno,data_nasc,sexo,telefone,cod_turma FROM aluno where matricula = matricula ";

                if (filtro.Matricula.Length > 0)
                {
                    sql += " and matricula = @matricula";
                }
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome_aluno like '%" + filtro.Nome.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Matricula.Length > 0)
                {
                    cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                    cmd.Parameters["@matricula"].Value = filtro.Matricula;
                }
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = filtro.Nome;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    Turma t = new Turma();
                    aluno.Matricula = DbReader.GetString(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome_aluno"));
                    aluno.DataNasc = DbReader.GetDateTime(DbReader.GetOrdinal("data_nasc")).ToString();
                    aluno.Sexo = DbReader.GetString(DbReader.GetOrdinal("sexo"));
                    aluno.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));
                    t.CodigoTurma= DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    aluno.Turma = t;

                    retorno.Add(aluno);
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

        public bool VerificaDuplicidade(Aluno aluno)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT matricula FROM aluno where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

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
    }
}