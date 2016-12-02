using Biblioteca.Basicas;
using Biblioteca.Interfaces;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.DAO
{
    class DAOFalta: ConexaoBanco,InterfaceFalta
    {
        #region Implementação da Interface
        public void Alterar(Falta falta)
        {

            try
            {
                this.AbrirConexao();
                string sql = "update falta set data=@data,motivo=@motivo,abono=@abono,matricula=@matricula,cod_aula=@codigoAula where cod_falta = @codigoFalta";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoFalta", SqlDbType.Int);
                cmd.Parameters["@codigoFalta"].Value = falta.CodigoFalta;

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = falta.Data;

                cmd.Parameters.Add("@motivo", SqlDbType.VarChar);
                cmd.Parameters["@motivo"].Value = falta.Motivo;

                cmd.Parameters.Add("@abono", SqlDbType.Bit);
                cmd.Parameters["@abono"].Value = falta.Abono;

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = falta.Aluno.Matricula;

                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = falta.Aula.CodigoAula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Falta falta)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from falta where cod_falta = @codigoFalta";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoFalta", SqlDbType.Int);
                cmd.Parameters["@codigoFalta"].Value = falta.CodigoFalta;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Falta falta)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into falta (data,motivo,abono,matricula,cod_aula) values(@data,@motivo,@abono,@matricula,@codigoAula)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = falta.Data;

                cmd.Parameters.Add("@motivo", SqlDbType.VarChar);
                cmd.Parameters["@motivo"].Value = falta.Motivo;

                cmd.Parameters.Add("@abono", SqlDbType.Bit);
                cmd.Parameters["@abono"].Value = falta.Abono;

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = falta.Aluno.Matricula;

                cmd.Parameters.Add("@codigoAula", SqlDbType.Int);
                cmd.Parameters["@codigoAula"].Value = falta.Aula.CodigoAula;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Falta> Listar(Falta filtro)
        {
            List<Falta> retorno = new List<Falta>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT f.cod_falta,f.data,f.motivo,f.abono,f.matricula,a.nome_aluno,f.cod_aula,aula.assunto,d.cod_disciplina,d.nome_disciplina,t.cod_turma,t.descricao_turma,dt.cod_disciplina_turma FROM falta as f INNER JOIN aluno as a ON f.matricula=a.matricula INNER JOIN aula ON aula.cod_aula=f.cod_aula INNER JOIN Disciplina_Turma as dt ON dt.cod_disciplina_turma=aula.cod_disciplina_turma INNER JOIN turma as t ON t.cod_turma=dt.cod_turma INNER JOIN Disciplina as d ON d.cod_disciplina=dt.cod_disciplina where cod_falta = cod_falta";

                if (filtro.Data.ToShortDateString().Length > 0)
                {
                    sql += " and data = @data";
                }
                if (filtro.Aluno.Nome != null && filtro.Aluno.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome_aluno like '%" + filtro.Aluno.Nome.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Data.ToShortDateString().Length > 0)
                {
                    cmd.Parameters.Add("@data", SqlDbType.Int);
                    cmd.Parameters["@data"].Value = filtro.Data;
                }
                if (filtro.Aluno.Nome != null && filtro.Aluno.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = filtro.Aluno.Nome;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Falta falta = new Falta();
                    Aluno aluno = new Aluno();
                    Aula aula = new Aula();
                    Disciplina d = new Disciplina();
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Turma t = new Turma();
                    falta.CodigoFalta = DbReader.GetInt32(DbReader.GetOrdinal("f.cod_falta"));
                    falta.Data = DbReader.GetDateTime(DbReader.GetOrdinal("f.data"));
                    falta.Motivo = DbReader.GetString(DbReader.GetOrdinal("f.motivo"));
                    falta.Abono = DbReader.GetBoolean(DbReader.GetOrdinal("f.abono"));
                    aluno.Matricula = DbReader.GetString(DbReader.GetOrdinal("f.matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("a.nome"));
                    falta.Aluno = aluno;
                    d.CodigoDisciplina = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina"));
                    d.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));
                    t.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turmma"));
                    aula.CodigoAula = DbReader.GetInt32(DbReader.GetOrdinal("cod_aula"));
                    dt.CodigoDisciplinaTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina_turma"));
                    aula.Assunto = DbReader.GetString(DbReader.GetOrdinal("aula.assunto"));
                    dt.Disciplina = d;
                    dt.Turma = t;
                    aula.DisciplinaTurma = dt;
                    falta.Aula = aula;
                    retorno.Add(falta);
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

        public bool VerificaDuplicidade(Falta falta)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT data FROM falta where data = @data AND matricula = @matricula" ;
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@data", SqlDbType.VarChar);
                cmd.Parameters["@data"].Value = falta.Data;

                cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                cmd.Parameters["@matricula"].Value = falta.Aluno.Matricula;

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
