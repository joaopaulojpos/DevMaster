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
    class DAOProfessor: ConexaoBanco,InterfaceProfessor
    {
        public void alterar(Professor professor)
        {

            try
            {
                this.abrirConexao();
                string sql = "update professor set nome=@nomeProfessor,cod_usuario=@usuario where cod_professor = @codigoProfessor";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoProfessor", SqlDbType.Int);
                cmd.Parameters["@codigoProfessor"].Value = professor.CodigoProfessor;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = professor.NomeProfessor;

                cmd.Parameters.Add("@usuario", SqlDbType.Int);
                cmd.Parameters["@usuario"].Value = professor.Usuario.CodUsuario;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void excluir(Professor professor)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from professor where cod_professor = @codigoProfessor";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoProfessor", SqlDbType.Int);
                cmd.Parameters["@codigoProfessor"].Value = professor.CodigoProfessor;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void inserir(Professor professor)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into professor (nome,cod_usuario) values(@nomeProfessor,@usuario)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nomeProfessor", SqlDbType.VarChar);
                cmd.Parameters["@nomeProfessor"].Value = professor.NomeProfessor;

                cmd.Parameters.Add("@usuario", SqlDbType.Int);
                cmd.Parameters["@usuario"].Value = professor.Usuario.CodUsuario;
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Professor> listar(Professor filtro)
        {
            List<Professor> retorno = new List<Professor>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT nome FROM professor where nome = nome ";
                
                if (filtro.NomeProfessor != null && filtro.NomeProfessor.Trim().Equals("") == false)
                {
                    sql += " and nome like '%" + filtro.NomeProfessor.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                
                if (filtro.NomeProfessor != null && filtro.NomeProfessor.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = filtro.NomeProfessor;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Professor professor = new Professor();
                    professor.NomeProfessor = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    
                    retorno.Add(professor);
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

        public bool verificaDuplicidade(Professor professor)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT nome FROM professor where nome = @nomeProfessor";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@nomeProfessor", SqlDbType.VarChar);
                cmd.Parameters["@nomeProfessor"].Value = professor.NomeProfessor;

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
