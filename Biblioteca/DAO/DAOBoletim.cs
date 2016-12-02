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
    public class DAOBoletim : ConexaoBanco,InterfaceBoletim
    {
        public List<Boletim> listar(Boletim filtro)
        {
            List<Boletim> retorno = new List<Boletim>();
            try
            {
                this.AbrirConexao();
                string sql = "select al.matricula,al.nome_aluno,t.cod_turma,t.descricao_turma,av.cod_avaliacao,av.descricao_avaliacao,av.nota,dt.cod_disciplina_turma,d.cod_disciplina,d.nome_disciplina from Aluno as al JOIN Turma as t ON t.cod_turma = al.cod_turma JOIN Avaliacao as av ON av.matricula = al.matricula JOIN Disciplina_Turma as dt ON dt.cod_turma = t.cod_turma JOIN Disciplina as d ON d.cod_disciplina = dt.cod_disciplina WHERE av.matricula=av.matricula";

                if (filtro.Avaliacao.Aluno.Matricula.Length > 0)
                {
                    sql += " and matricula like '%" + filtro.Avaliacao.Aluno.Matricula.Trim() + "%'";
                }
                if (filtro.Avaliacao.Aluno.Nome != null && filtro.Avaliacao.Aluno.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome_aluno like '%" + filtro.Avaliacao.Aluno.Nome.Trim() + "%'";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                if (filtro.Avaliacao.Aluno.Matricula.Length > 0)
                {
                    cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                    cmd.Parameters["@Matricula"].Value = filtro.Avaliacao.Aluno.Matricula;
                }
                if (filtro.Avaliacao.Aluno.Nome != null && filtro.Avaliacao.Aluno.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                    cmd.Parameters["@Nome"].Value = filtro.Avaliacao.Aluno.Nome;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Boletim boletim = new Boletim();
                    Aluno a = new Aluno();
                    Turma t = new Turma();
                    Disciplina d = new Disciplina();
                    Disciplina_Turma dt = new Disciplina_Turma();
                    Avaliacao av = new Avaliacao();
                    d.CodigoDisciplina = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina"));
                    d.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));
                    a.Matricula= DbReader.GetString(DbReader.GetOrdinal("matricula"));
                    a.Nome= DbReader.GetString(DbReader.GetOrdinal("nome_aluno"));
                    t.CodigoTurma= DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    av.Nota =(Double) DbReader.GetDecimal(DbReader.GetOrdinal("nota"));
                    t.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    av.CodigoAvaliacao= DbReader.GetInt32(DbReader.GetOrdinal("cod_avaliacao"));
                    av.Descricao= DbReader.GetString(DbReader.GetOrdinal("descricao_avaliacao"));
                    dt.CodigoDisciplinaTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina_turma"));
                    a.Turma = t;
                    dt.Turma = t;
                    dt.Disciplina = d;
                    av.Aluno = a;
                    av.Disciplina_turma = dt;
                    boletim.Avaliacao = av;    
                    retorno.Add(boletim);
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
    }
}
