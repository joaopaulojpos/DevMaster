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
        public void alterar(Turma turma)
        {

            try
            {
                this.abrirConexao();
                string sql = "update turma set cod_turma = @codigoTurma ,descricao=@descricao,turno=@turno,ano=@ano,dataInicio=@dataInicio,codSerie=@codSerie where cod_turma = @codigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = turma.CodigoTurma;

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = turma.Descricao;

                cmd.Parameters.Add("@turno", SqlDbType.Char);
                cmd.Parameters["@turno"].Value = turma.Turno;

                cmd.Parameters.Add("@ano", SqlDbType.Int);
                cmd.Parameters["@ano"].Value = turma.Ano ;

                cmd.Parameters.Add("@dataInicio", SqlDbType.Date);
                cmd.Parameters["@dataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@codSerie", SqlDbType.Int);
                cmd.Parameters["@codSerie"].Value = turma.Serie.CodSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void excluir(Turma turma)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from turma where cod_turma = @codigoTurma";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = turma.CodigoTurma;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void inserir(Turma turma)
        {
            try
            {
                this.abrirConexao();
                string sql = "insert into turma (descricao,turno,ano,data_inicio,cod_serie) values(@descricao,@turno,@ano,@dataInicio,@codSerie)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                cmd.Parameters["@descricao"].Value = turma.CodigoTurma;

                cmd.Parameters.Add("@turno", SqlDbType.Char);
                cmd.Parameters["@turno"].Value = turma.Turno;

                cmd.Parameters.Add("@ano", SqlDbType.Int);
                cmd.Parameters["@ano"].Value = turma.Ano;

                cmd.Parameters.Add("@dataInicio", SqlDbType.VarChar);
                cmd.Parameters["@dataInicio"].Value = turma.DataInicio;

                cmd.Parameters.Add("@codSerie", SqlDbType.Int);
                cmd.Parameters["@codSerie"].Value = turma.Serie.CodSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Turma> listar(Turma filtro)
        {
            List<Turma> retorno = new List<Turma>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_turma,descricao,turno,ano,data_inicio,telefone,cod_serie FROM turma where cod_turma = cod_turma ";
                if (filtro.CodigoTurma > 0)
                {
                    sql += " and codigoTurma = @codigoTurma";
                }
                if (filtro.Descricao != null && filtro.Descricao.Trim().Equals("") == false)
                {
                    sql += " and descricao like '%" + filtro.Descricao.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodigoTurma > 0)
                {
                    cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                    cmd.Parameters["@codigoTurma"].Value = filtro.Descricao;
                }
                if (filtro.Descricao != null && filtro.Descricao.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                    cmd.Parameters["@descricao"].Value = filtro.Descricao;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Turma turma = new Turma();
                    turma.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    turma.Descricao = DbReader.GetString(DbReader.GetOrdinal("descricao"));
                    turma.DataInicio = DbReader.GetString(DbReader.GetOrdinal("data_inicio"));
                    turma.Turno = DbReader.GetChar(DbReader.GetOrdinal("turno"));
                    turma.Serie.CodSerie = DbReader.GetInt32(DbReader.GetOrdinal("cod_serie"));
                    turma.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));

                    retorno.Add(turma);
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

        public bool verificaDuplicidade(Turma turma)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_turma FROM turma where cod_turma = @codigoTurma";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = turma.CodigoTurma;

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
