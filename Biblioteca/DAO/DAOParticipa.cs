using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Biblioteca.Basicas;
using Biblioteca.Interfaces;
using Biblioteca.Util;

namespace Biblioteca.DAO
{
    public class DAOParticipa : ConexaoBanco
    {
        public List<Aluno> ListarAlunos(Turma turma)
        {
            List<Aluno> listaAlunos = new List<Aluno>();
            try
            {
                this.AbrirConexao();

                //Selecionei todos campos de todas tabelas ligadas pra nao ter problema, com excessão dos repetidos tipo Turma.cod_ensino e Ensino.cod_ensino, ai deixei só um
                string sql = "SELECT A.nome_aluno, A.matricula, A.data_nasc, A.telefone, A.sexo, A.cod_turma, P.cod_disciplina_turma, T.ano, T.data_inicio, T.descricao_turma, T.turno, T.cod_ensino, E.descricao_ensino " +
                             "FROM Aluno A " +
                             "INNER JOIN Participa P " +
                             "ON A.matricula = P.matricula " +
                             "INNER JOIN Turma T " +
                             "ON A.cod_turma = T.cod_turma " +
                             "INNER JOIN Ensino E " +
                             "ON T.cod_ensino = E.cod_ensino " +
                             "WHERE A.cod_turma = @CodigoTurma";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoTurma", SqlDbType.VarChar);
                cmd.Parameters["@CodigoTurma"].Value = turma.CodigoTurma;


                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    aluno.Matricula = DbReader.GetString(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome_aluno"));
                    aluno.DataNasc = DbReader.GetDateTime(DbReader.GetOrdinal("data_nasc"));
                    aluno.Sexo = DbReader.GetString(DbReader.GetOrdinal("sexo"));
                    aluno.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));

                    Turma turma1 = new Turma();
                    turma1.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    turma1.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));
                    turma1.Turno = DbReader.GetString(DbReader.GetOrdinal("turno"));
                    turma1.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));
                    turma1.DataInicio = DbReader.GetDateTime(DbReader.GetOrdinal("data_inicio"));

                    Ensino ensino = new Ensino();
                    ensino.CodigoEnsino = DbReader.GetInt32(DbReader.GetOrdinal("cod_ensino"));
                    ensino.DescricaoEnsino = DbReader.GetString(DbReader.GetOrdinal("descricao_ensino"));

                    turma1.Ensino = ensino;
                    aluno.Turma = turma1;

                    listaAlunos.Add(aluno);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível ver a lista dos alunos da turma. Erro:\n" + ex.Message);
            }

            return listaAlunos;
        }
    }
}
