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
    public class DAODisciplina : ConexaoBanco, InterfaceDisciplina
    {
        #region Implementação da Interface

        public void Alterar(Disciplina disciplina)
        {
            try
            {
                this.AbrirConexao();
                string sql = "update disciplina set nome_disciplina = @NomeDisciplina where cod_disciplina = @CodigoDisciplina";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoDisciplina", SqlDbType.Int);
                cmd.Parameters["@CodigoDisciplina"].Value = disciplina.CodigoDisciplina;

                cmd.Parameters.Add("@NomeDisciplina", SqlDbType.VarChar);
                cmd.Parameters["@NomeDisciplina"].Value = disciplina.NomeDisciplina;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Alterar a Disciplina.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Disciplina disciplina)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from disciplina where cod_disciplina = @CodigoDisciplina";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoDisciplina", SqlDbType.Int);
                cmd.Parameters["@CodigoDiscplina"].Value = disciplina.CodigoDisciplina;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Excluir a Disciplina.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Disciplina disciplina)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into disciplina (nome_disciplina) values(@NomeDisciplina)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@NomeDisciplina", SqlDbType.VarChar);
                cmd.Parameters["@NomeDisciplina"].Value = disciplina.NomeDisciplina;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Inserir a Disciplina.\nErro: " + ex.Message);
            }
        }

        public List<Disciplina> Listar(Disciplina filtro)
        {
            List<Disciplina> retorno = new List<Disciplina>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_disciplina, nome_disciplina FROM disciplina where cod_disciplina = cod_disciplina";

                if (filtro.CodigoDisciplina > 0)
                {
                    sql += " and cod_disciplina = @CodigoDisciplina";
                }
                if (filtro.NomeDisciplina != null && filtro.NomeDisciplina.Trim().Equals("") == false)
                {
                    sql += " and nome_disciplina like '%@NomeDisciplina%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoDisciplina > 0)
                {
                    cmd.Parameters.Add("@CodigoDisciplina", SqlDbType.Int);
                    cmd.Parameters["@CodigoDisciplina"].Value = filtro.CodigoDisciplina;
                }
                if (filtro.NomeDisciplina != null && filtro.NomeDisciplina.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@NomeDisciplina", SqlDbType.VarChar);
                    cmd.Parameters["@NomeDisciplina"].Value = filtro.NomeDisciplina;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.CodigoDisciplina = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina"));
                    disciplina.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));

                    retorno.Add(disciplina);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Listar as Disciplinas.\nErro: " + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Disciplina disciplina)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_disciplina FROM disciplina where cod_disciplina = @CodigoDisciplina";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@CodigoDisciplina", SqlDbType.Int);
                cmd.Parameters["@CodigoDisciplina"].Value = disciplina.CodigoDisciplina;

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
                throw new Exception("Não foi possível Verificar a Duplicidade da Disciplina.\nErro: " + ex.Message);
            }
            return retorno;
        }
        #endregion
    }
}
