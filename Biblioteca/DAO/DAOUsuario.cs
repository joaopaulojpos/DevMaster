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
    public class DAOUsuario : ConexaoBanco, InterfaceUsuario
    {
        public void Alterar(Usuario usuario)
        {
            try
            {
                this.AbrirConexao();
                string sql = "UPDATE usuario " +
                             "SET usuario_login = @LoginUsuario, senha = @Senha, nome = @Nome, telefone = @Telefone, cod_tipo_usuario = @TipoUsuario " +
                             "WHERE cod_usuario = @CodUsuario";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@CodUsuario", SqlDbType.Int);
                cmd.Parameters["@CodUsuario"].Value = usuario.CodUsuario;

                cmd.Parameters.Add("@LoginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@LoginUsuario"].Value = usuario.LoginUsuario;

                cmd.Parameters.Add("@Senha", SqlDbType.VarChar);
                cmd.Parameters["@Senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                cmd.Parameters["@Nome"].Value = usuario.Nome;

                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar);
                cmd.Parameters["@Telefone"].Value = usuario.Nome;

                cmd.Parameters.Add("@TipoUsuario", SqlDbType.Int);
                cmd.Parameters["@TipoUsuario"].Value = usuario.TipoUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Alterar o Usuário.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Usuario usuario)
        {
            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Usuario " +
                             "WHERE cod_usuario = @CodUsuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@CodUsuario", SqlDbType.Int);
                cmd.Parameters["@CodUsuario"].Value = usuario.CodUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Excluir o Usuário. Detalhes:\n" + ex.Message);
            }
        }

        public void Inserir(Usuario usuario)
        {
            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Usuario " + 
                             "(usuario_login,senha, nome, telefone, cod_tipo_usuario) " +
                             "VALUES " +
                             "(@LoginUsuario,@Senha,@Nome, @Telefone, @TipoUsuario)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@LoginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@LoginUsuario"].Value = usuario.LoginUsuario;

                cmd.Parameters.Add("@Senha", SqlDbType.VarChar);
                cmd.Parameters["@Senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar);
                cmd.Parameters["@Nome"].Value = usuario.Senha;

                cmd.Parameters.Add("@TipoUsuario", SqlDbType.Int);
                cmd.Parameters["@TipoUsuario"].Value = usuario.TipoUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Inserir o Usuário.\nErro: " + ex.Message);
            }
        }

        public List<Usuario> Listar(Usuario filtro)
        {
            List<Usuario> retorno = new List<Usuario>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT U.cod_usuario, U.usuario_login, U.senha, U.nome, U.telefone, TU.desc_tipo_usuario, TU.cod_tipo_usuario " +
                             "FROM Usuario U " +
                             "INNER JOIN Tipo_usuario TU " +
                             "ON U.cod_tipo_usuario = TU.cod_tipo_usuario " +
                             "WHERE cod_usuario = cod_usuario";

                if (filtro.CodUsuario > 0)
                {
                    sql += " and U.cod_usuario = @CodUsuario";
                }

                if (filtro.Nome.Length > 0)
                {
                    sql += " and U.nome like '%@NomeUsuario%'";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodUsuario > 0)
                {
                    cmd.Parameters.Add("@CodUsuario", SqlDbType.Int);
                    cmd.Parameters["@CodUsuario"].Value = filtro.CodUsuario;
                }

                if (filtro.Nome.Length > 0)
                {
                    cmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar);
                    cmd.Parameters["@NomeUsuario"].Value = filtro.Nome;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.CodUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_usuario"));
                    usuario.LoginUsuario = DbReader.GetString(DbReader.GetOrdinal("usuario_login"));
                    usuario.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    usuario.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    usuario.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));

                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.DescricaoTipoUsuario = DbReader.GetString(DbReader.GetOrdinal("desc_tipo_usuario"));
                    tipoUsuario.CodTipoUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_tipo_usuario"));

                    usuario.TipoUsuario = tipoUsuario;

                    retorno.Add(usuario);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Não foi possível Listar os Usuários. Erro:\n" + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Usuario usuario)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_usuario " +
                             "FROM usuario " + 
                             "WHERE usuario_login = @LoginUsuario " +
                             "AND senha = @Senha";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@Senha", SqlDbType.Int);
                cmd.Parameters["@Senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@LoginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@LoginUsuario"].Value = usuario.LoginUsuario;

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
                throw new Exception("Não foi possível Verificar Duplicidade dos Usuários.\nErro: " + ex.Message);
            }
            return retorno;
        }
    }
}
