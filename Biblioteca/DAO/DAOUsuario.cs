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
                string sql = "update usuario set usuario_login=@loginUsuario,senha=@senha,cod_tipo_usuario=@tipoUsuario,nome=@nome where cod_usuario = @codUsuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                cmd.Parameters["@codUsuario"].Value = usuario.CodUsuario;

                cmd.Parameters.Add("@loginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@loginUsuario"].Value = usuario.LoginUsuario;

                cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                cmd.Parameters["@senha"].Value = usuario.Senha;
                
                cmd.Parameters.Add("@tipoUsuario", SqlDbType.Int);
                cmd.Parameters["@tipoUsuario"].Value = usuario.TipoUsuario;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = usuario.Nome;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Excluir(Usuario usuario)
        {
            try
            {
                this.AbrirConexao();
                string sql = "delete from usuario where cod_usuario = @codUsuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                cmd.Parameters["@codUsuario"].Value = usuario.CodUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public void Inserir(Usuario usuario)
        {
            try
            {
                this.AbrirConexao();
                string sql = "insert into usuario (usuario_login,senha,cod_tipo_usuario) values(@loginUsuario,@senha,@tipoUsuario)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@loginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@loginUsuario"].Value = usuario.LoginUsuario;

                cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                cmd.Parameters["@senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@tipoUsuario", SqlDbType.Int);
                cmd.Parameters["@tipoUsuario"].Value = usuario.TipoUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Contate o suporte.\nErro: " + ex.Message);
            }
        }

        public List<Usuario> Listar(Usuario filtro)
        {
            List<Usuario> retorno = new List<Usuario>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT U.cod_usuario, U.usuario_login, U.senha, U.nome, U.telefone, TU.desc_tipo_usuario " +
                             "FROM Usuario U " +
                             "INNER JOIN Tipo_usuario TU " +
                             "ON U.cod_tipo_usuario = TU.cod_tipo_usuario " +
                             "WHERE cod_usuario = cod_usuario";

                if (filtro.CodUsuario > 0)
                {
                    sql += " and U.cod_usuario = @codUsuario";
                }

                if (filtro.Nome.Length > 0)
                {
                    sql += " and U.nome like '% @nomeUsuario %'";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodUsuario > 0)
                {
                    cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                    cmd.Parameters["@codUsuario"].Value = filtro.CodUsuario;
                }

                if (filtro.Nome.Length > 0)
                {
                    cmd.Parameters.Add("@nomeUsuario", SqlDbType.VarChar);
                    cmd.Parameters["@nomeUsuario"].Value = filtro.Nome;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Usuario usuario = new Usuario();
                    TipoUsuario tipoUsuario = new TipoUsuario();

                    usuario.CodUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_usuario"));
                    usuario.LoginUsuario = DbReader.GetString(DbReader.GetOrdinal("usuario_login"));
                    usuario.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    usuario.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    usuario.Telefone = DbReader.GetString(DbReader.GetOrdinal("telefone"));
                    tipoUsuario.DescricaoTipoUsuario = DbReader.GetString(DbReader.GetOrdinal("desc_tipo_usuario"));
                    usuario.TipoUsuario = tipoUsuario;
                    retorno.Add(usuario);
                }
                DbReader.Close();
                cmd.Dispose();
                this.FecharConexao();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro: \n" + ex.Message);
            }
            return retorno;
        }

        public bool VerificaDuplicidade(Usuario usuario)
        {
            bool retorno = false;
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_usuario FROM usuario where usuario_login = @loginUsuario and senha = @senha";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.Add("@senha", SqlDbType.Int);
                cmd.Parameters["@senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@loginUsuario", SqlDbType.Int);
                cmd.Parameters["@loginUsuario"].Value = usuario.LoginUsuario;

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
    }
}
