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
    public class DAOAvaliacao: ConexaoBanco,InterfaceAvaliacao
    {
        #region Implementação da Interface
        public void Alterar(Avaliacao avaliacao)
        {

            try
            {
                this.AbrirConexao();
                string sql = "update avaliacao set nota=@nota,descricao=@descricao,matricula=@matricula,cod_disciplina_turma=@codigoDisciplinaTurma where cod_avaliacao=@codigoAvaliacao;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoAvaliacao", SqlDbType.Int);
                cmd.Parameters["@codigoAvaliacao"].Value = avaliacao.CodigoAvaliacao;

                cmd.Parameters.Add("@nota", SqlDbType.Decimal);
                cmd.Parameters["@nota"].Value = avaliacao.Nota;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = avaliacao.Descricao;

                cmd.Parameters.Add("@codigoDisciplinaTurma", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplinaTurma"].Value = avaliacao.Disciplina_turma.CodigoDisciplinaTurma;
                
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = avaliacao.Aluno.Matricula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Avaliacao avaliacao)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from avaliacao where cod_avaliacao=@codigoAvaliacao";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoAvaliacao", SqlDbType.Int);
                cmd.Parameters["@codigoAvaliacao"].Value = avaliacao.CodigoAvaliacao;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Avaliacao avaliacao)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into Avaliacao(nota,descricao_avaliacao,matricula,cod_disciplina_turma) values(@nota,@descricao,@matricula,@codigoDisciplinaTurma)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nota", SqlDbType.Decimal);
                cmd.Parameters["@nota"].Value = avaliacao.Nota;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = avaliacao.Descricao;

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = avaliacao.Aluno.Matricula;

                cmd.Parameters.Add("@codigoDisciplinaTurma", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplinaTurma"].Value = avaliacao.Disciplina_turma.CodigoDisciplinaTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Avaliacao> Listar(Avaliacao filtro)
        {
            List<Avaliacao> retorno = new List<Avaliacao>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT av.cod_avaliacao,av.nota,av.descricao_avaliacao,av.matricula,al.nome_aluno,d.nome_disciplina,av.cod_disciplina_turma FROM avaliacao as av INNER JOIN aluno as al ON av.matricula=al.matricula INNER JOIN disciplina_turma as dt ON dt.cod_disciplina_turma=av.cod_disciplina_turma INNER JOIN disciplina as d ON d.cod_disciplina=dt.cod_disciplina where cod_avaliacao = cod_avaliacao";

                if (filtro.Aluno.Matricula.Length > 0)
                {
                    sql += " and av.matricula = @matricula";
                }
                if (filtro.Disciplina_turma.Disciplina.NomeDisciplina != null && filtro.Disciplina_turma.Disciplina.NomeDisciplina.Trim().Equals("") == false)
                {
                    sql += " and nome_disciplina like '%" + filtro.Disciplina_turma.Disciplina.NomeDisciplina.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Aluno.Matricula.Length > 0)
                {
                    cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                    cmd.Parameters["@matricula"].Value = filtro.Aluno.Matricula;
                }
                if (filtro.Disciplina_turma.Disciplina.NomeDisciplina != null && filtro.Disciplina_turma.Disciplina.NomeDisciplina.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nomeDisciplina", SqlDbType.VarChar);
                    cmd.Parameters["@nomeDisciplina"].Value = filtro.Disciplina_turma.Disciplina.NomeDisciplina;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    Avaliacao avaliacao = new Avaliacao();
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Disciplina disciplina = new Disciplina();
                    avaliacao.CodigoAvaliacao = DbReader.GetInt32(DbReader.GetOrdinal("cod_avaliacao"));
                    avaliacao.Nota = (Double )DbReader.GetDecimal(DbReader.GetOrdinal("nota"));
                    avaliacao.Descricao = DbReader.GetString(DbReader.GetOrdinal("descricao_avaliacao"));
                    aluno.Matricula = DbReader.GetString(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome_aluno"));
                    avaliacao.Aluno = aluno;
                    disciplina.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));
                    dt.Disciplina = disciplina;
                    dt.CodigoDisciplinaTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina_turma"));
                    avaliacao.Disciplina_turma = dt;
                    retorno.Add(avaliacao);
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

        public bool VerificaDuplicidade(Avaliacao avaliacao)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT matricula FROM avaliacao where matricula = @matricula AND cod_disciplina_turma=@codigoDisciplinaTurma AND descricao_avaliacao=@descricao";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = avaliacao.Aluno.Matricula;

                cmd.Parameters.Add("@codigoDisciplinaTurma", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplinaTurma"].Value = avaliacao.Disciplina_turma.CodigoDisciplinaTurma;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = avaliacao.Descricao;

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
