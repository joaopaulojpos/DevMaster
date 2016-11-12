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
        public void alterar(Aluno aluno)
        {

            try
            {
                this.abrirConexao();
                string sql = "update aluno set matricula = @matricula ,nome=@nome,data_nasc=@dataNasc,sexo=@sexo,telefone=@telefone,cod_turma=@codigoTurma  where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.Int);
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
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void excluir(Aluno aluno)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from aluno where matricula = @matricula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void inserir(Aluno aluno)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into aluno (matricula,nome_aluno,data_nasc,sexo,telefone,cod_turma) values(@matricula,@nome,@dataNasc,@sexo,@telefone,@codTurma)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.Int);
                cmd.Parameters["@matricula"].Value = aluno.Matricula;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = aluno.Nome;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Aluno> listar(Aluno filtro)
        {
            List<Aluno> retorno = new List<Aluno>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT matricula,nome,data_nasc,sexo,telefone,cod_turma FROM aluno where matricula = matricula ";
                if (filtro.Matricula > 0)
                {
                    sql += " and matricula = @matricula";
                }
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome like '%" + filtro.Nome.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Matricula > 0)
                {
                    cmd.Parameters.Add("@matricula", SqlDbType.Int);
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
                    aluno.Matricula = DbReader.GetInt32(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    aluno.DataNasc = DbReader.GetString(DbReader.GetOrdinal("data_nasc"));
                    aluno.Sexo = DbReader.GetChar(DbReader.GetOrdinal("sexo"));
                    aluno.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));
                    aluno.Turma.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));

                    retorno.Add(aluno);
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

        public bool verificaDuplicidade(Aluno aluno)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
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