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
    class DAODisciplina: ConexaoBanco, InterfaceDisciplina
    {
        public void alterar(Disciplina disciplina)
        {

            try
            {
                this.abrirConexao();
                string sql = "update disciplina set nome_disciplina=@nomeDisciplina where cod_disciplina = @codigoDisciplina";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                
                cmd.Parameters.Add("@nomeDisciplina", SqlDbType.VarChar);
                cmd.Parameters["@nomeDisciplina"].Value = disciplina.NomeDisciplina;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void excluir(Disciplina disciplina)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from disciplina where cod_disciplina = @codigoDisciplina";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoDisciplina", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplina"].Value = disciplina.CodigoDisciplina;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void inserir(Disciplina disciplina)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into disciplina (nome_disciplina) values(@nomeDisciplina)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nomeDisciplina", SqlDbType.VarChar);
                cmd.Parameters["@nomeDisciplina"].Value = disciplina.CodigoDisciplina;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Disciplina> listar(Disciplina filtro)
        {
            List<Disciplina> retorno = new List<Disciplina>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_disciplina,nome_disciplina from disciplina where cod_disciplina = cod_disciplina";
                if (filtro.CodigoDisciplina > 0)
                {
                    sql += " and cod_disciplina = @codigoDisciplina";
                }
                if (filtro.NomeDisciplina != null && filtro.NomeDisciplina.Trim().Equals("") == false)
                {
                    sql += " and nome_disciplina like '%" + filtro.NomeDisciplina.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoDisciplina > 0)
                {
                    cmd.Parameters.Add("@codigoDisciplina", SqlDbType.Int);
                    cmd.Parameters["@codigoTurma"].Value = filtro.CodigoDisciplina;
                }
                if (filtro.NomeDisciplina != null && filtro.NomeDisciplina.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                    cmd.Parameters["@descricao"].Value = filtro.NomeDisciplina;

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
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }

        public bool verificaDuplicidade(Disciplina disciplina)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT nome_disciplina FROM disciplina where nome_disciplina = @nomeDisciplina";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@nomeDisciplina", SqlDbType.Int);
                cmd.Parameters["@nomeDisciplina"].Value = disciplina.NomeDisciplina;

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
