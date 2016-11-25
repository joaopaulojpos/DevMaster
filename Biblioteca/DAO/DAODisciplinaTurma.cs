using Biblioteca.Basicas;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca.DAO
{
    public class DAODisciplinaTurma:ConexaoBanco
    {

        public void Inserir(Disciplina_Turma disciplinaTurma)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into disciplina_turma (cod_disciplina,cod_turma,cod_usuario) values(@codigoDisciplina,@codigoTurma,@codigoUsuario);";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigoDisciplina", SqlDbType.Int);
                cmd.Parameters["@codigoDisciplina"].Value = disciplinaTurma.Disciplina.CodigoDisciplina;

                cmd.Parameters.Add("@codigoTurma", SqlDbType.Int);
                cmd.Parameters["@codigoTurma"].Value = disciplinaTurma.Turma.CodigoTurma;

                cmd.Parameters.Add("@codigoUsuario", SqlDbType.Int);
                cmd.Parameters["@codigoUsuario"].Value = disciplinaTurma.Usuario.CodUsuario;
                
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Disciplina_Turma> Listar(Disciplina_Turma filtro)
        {
            List<Disciplina_Turma> retorno = new List<Disciplina_Turma>();
            try
            {
                this.AbrirConexao();
                string sql = "select d.nome_disciplina,t.descricao_turma,t.ano,t.turno,t.ano from Disciplina_Turma as dt INNER JOIN Turma as t ON dt.cod_turma=t.cod_turma INNER JOIN Disciplina as d ON d.cod_disciplina=dt.cod_disciplina INNER JOIN Usuario as u ON u.cod_usuario=dt.cod_disciplina_turma WHERE cod_disciplina_turma = cod_disciplina_turma";
                if (filtro.Disciplina.NomeDisciplina != null && filtro.Disciplina.NomeDisciplina.Trim().Equals("")==false)
                {
                    sql += " and d.nome_disciplina = @nomeDisciplina";
                }
                if (filtro.Turma.DescricaoTurma != null && filtro.Turma.DescricaoTurma.Trim().Equals("") == false)
                {
                    sql += " and t.descricao_turma like '%" + filtro.Turma.DescricaoTurma.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.Disciplina.NomeDisciplina != null && filtro.Disciplina.NomeDisciplina.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nomeDisciplina", SqlDbType.VarChar);
                    cmd.Parameters["@nomeDisciplina"].Value = filtro.Disciplina.NomeDisciplina;
                }
                if (filtro.Turma.DescricaoTurma != null && filtro.Turma.DescricaoTurma.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricaoTurma", SqlDbType.VarChar);
                    cmd.Parameters["@descricaoTurma"].Value = filtro.Turma.DescricaoTurma;
                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Disciplina d = new Disciplina();
                    Turma t = new Turma();
                    d.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));
                    dt.Disciplina = d;
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    t.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));
                    t.Turno = DbReader.GetString(DbReader.GetOrdinal("turno"));
                    dt.Turma = t;
                    retorno.Add(dt);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e selecionar: \n" + ex.Message);
            }
            return retorno;
        }
    }
}