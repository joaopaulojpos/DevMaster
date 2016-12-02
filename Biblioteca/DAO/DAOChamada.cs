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
    public class DAOChamada : ConexaoBanco
    {
        #region Listar Alunos da Turma

        public List<Aluno> ListarAlunosDaTurma(Turma turma)
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

        #endregion

        #region Listar Faltas

        /* Incompleto
        public List<Aluno> ListarFalta(Aula aula)
        {
            try
            {
                List<Aluno> listaFalta = new List<Aluno>();
                this.AbrirConexao();

                string sql = "SELECT F.cod_falta, F.abono, F.data, A.matricula, A.nome_aluno, A.data_nasc, A.sexo, A.telefone, AU.cod_aula, AU.assunto, AU.data, " +
                             "DT.cod_disciplina_turma, D.cod_disciplina, T.cod_turma, T.ano, T.data_inicio, T.descricao_turma, T.turno, E.cod_ensino, E.descricao_ensino " +
                             "FROM Falta F " +
                             "INNER JOIN Aluno A " +
                             "ON F.matricula = A.matricula " +
                             "INNER JOIN Aula AU " +
                             "ON F.cod_aula = AU.cod_aula " +
                             "INNER JOIN Disciplina_Turma DT " +
                             "ON AU.cod_disciplina_turma = DT.cod_disciplina_turma " +
                             "INNER JOIN Disciplina D " +
                             "ON DT.cod_disciplina = D.cod_disciplina " +
                             "INNER JOIN Turma T " +
                             "ON DT.cod_turma = T.cod_turma " +
                             "INNER JOIN Ensino E " +
                             "INNER JOIN Usuario U " +
                             "ON DT.cod_usuario = U.cod_usuario" +
                             "ON T.cod_ensino = E.cod_ensino " +
                             "WHERE AU.cod_aula = @CodigoAula";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodigoAula", SqlDbType.Int);
                cmd.Parameters["@CodigoAula"].Value = aula.CodigoAula;

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Ensino ensino = new Ensino();
                    ensino.DescricaoEnsino = DbReader.GetString(DbReader.GetOrdinal("descricao_ensino"));
                    ensino.CodigoEnsino = DbReader.GetInt32(DbReader.GetOrdinal("cod_ensino"));

                    Turma turma = new Turma();
                    turma.Ensino = ensino;
                    turma.Ano = DbReader.GetInt32(DbReader.GetOrdinal("ano"));
                    turma.CodigoTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_turma"));
                    turma.DataInicio = DbReader.GetDateTime(DbReader.GetOrdinal("data_inicio"));
                    turma.DescricaoTurma = DbReader.GetString(DbReader.GetOrdinal("descricao_turma"));

                    Disciplina disciplina = new Disciplina();
                    disciplina.CodigoDisciplina = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina"));
                    disciplina.NomeDisciplina = DbReader.GetString(DbReader.GetOrdinal("nome_disciplina"));

                    Usuario usuario = new Usuario();
                    usuario.CodUsuario = DbReader.get
              
                    Disciplina_Turma disciplinaTurma = new Disciplina_Turma();
                    disciplinaTurma.CodigoDisciplinaTurma = DbReader.GetInt32(DbReader.GetOrdinal("cod_disciplina_turma"));
                    disciplinaTurma.Disciplina = disciplina;
                    disciplinaTurma.Turma = turma;


                    Aluno aluno = new Aluno();


                    listaFalta.Add(aluno);
                }

                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Listar Faltas. Erro:\n" + ex.Message);
            }
        }
        */
        #endregion
    }
}
