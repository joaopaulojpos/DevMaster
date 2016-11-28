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
    public class DAOAula: ConexaoBanco, InterfaceAula
    {
        #region Implementação da Interface
        public void Alterar(Aula aula)
        {

            try
            {
                this.AbrirConexao();
                string sql = "update aula set data=@data,assunto=@assunto,cod_disciplina_turma=@codigoDisciplinaTurma where cod_aula = @codigoAula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = aula.CodigoAula;

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = aula.Data;

                cmd.Parameters.Add("@assunto", SqlDbType.VarChar);
                cmd.Parameters["@assunto"].Value = aula.Assunto;

                cmd.Parameters.Add("@codigoDisciplinaTurma", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplinaTurma"].Value = aula.DisciplinaTurma.CodigoDisciplinaTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
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
                this.AbrirConexao();
                string sql = "delete from aula where cod_aula = @codigoAula";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = aula.CodigoAula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
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
                this.AbrirConexao();
                string sql = "insert into aula (data,assunto,cod_disciplina_turma) values(@data,@assunto,@codigoDisciplinaTurma)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = aula.Data;

                cmd.Parameters.Add("@assunto", SqlDbType.VarChar);
                cmd.Parameters["@assunto"].Value = aula.Assunto;

                cmd.Parameters.Add("@codigoDisciplinaTurma", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplinaTurma"].Value = aula.DisciplinaTurma.CodigoDisciplinaTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
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
                this.AbrirConexao();
                string sql = "SELECT a.cod_aula,a.data,a.assunto,a.cod_disciplina_turma,d.cod_disciplina,d.nome_disciplina,t.cod_turma,t.descricao_turma,t.turno,t.ano FROM aula AS a INNER JOIN Disciplina_Turma AS dt ON dt.cod_disciplina_turma=a.cod_disciplina_turma INNER JOIN Turma as t ON t.cod_turma=dt.cod_turma INNER JOIN Disciplina as d ON d.cod_disciplina=dt.cod_disciplina WHERE cod_aula = cod_aula";

                if (filtro.Data.Length > 0)
                {
                    sql += " and data = @data";
                }
                if (filtro.DisciplinaTurma.Turma.CodigoTurma > 0)
                {
                    sql += " and dt.cod_turma = @codigoTurma";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Data.Length > 0)
                {
                    cmd.Parameters.Add("@data", SqlDbType.VarChar);
                    cmd.Parameters["@data"].Value = filtro.Data;
                }
                if (filtro.DisciplinaTurma.Turma.CodigoTurma > 0)
                {
                    cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                    cmd.Parameters["@codigoTurma"].Value = filtro.DisciplinaTurma.Turma.CodigoTurma;
                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aula aula = new Aula();
                    Disciplina d =new Disciplina();
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Turma t = new Turma();
                    aula.CodigoAula = DbReader.GetInt32(DbReader.GetOrdinal("cod_aula"));
                    aula.Data = DbReader.GetDateTime(DbReader.GetOrdinal("data")).ToString();
                    aula.Assunto = DbReader.GetString(DbReader.GetOrdinal("assunto"));
                    t.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    t.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));
                    t.DescricaoTurma= DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    t.Turno = DbReader.GetString(DbReader.GetOrdinal("turno"));
                    d.CodigoDisciplina = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina"));
                    d.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));
                    dt.CodigoDisciplinaTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina_turma"));
                    dt.Disciplina = d;
                    dt.Turma = t;
                    aula.DisciplinaTurma = dt;
                    retorno.Add(aula);
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

        public bool VerificaDuplicidade(Aula aula)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT data FROM aula where data = @data";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = aula.Data;

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
