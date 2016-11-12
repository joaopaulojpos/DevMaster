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
        public void alterar(Usuario usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "update usuario set cod_usuario = @codUsuario ,usuario_login=@loginUsuario,senha=@senha,cod_tipo_usuario=@tipoUsuario where cod_usuario = @codUsuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                cmd.Parameters["@codUsuario"].Value = usuario.CodUsuario;

                cmd.Parameters.Add("@loginUsuario", SqlDbType.VarChar);
                cmd.Parameters["@loginUsuario"].Value = usuario.LoginUsuario;

                cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                cmd.Parameters["@senha"].Value = usuario.Senha;

                cmd.Parameters.Add("@tipoUsuario", SqlDbType.Int);
                cmd.Parameters["@tipoUsuario"].Value = usuario.TipoUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void excluir(Usuario usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "delete from usuario where cod_usuario = @codUsuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                cmd.Parameters["@codUsuario"].Value = usuario.CodUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public void inserir(Usuario usuario)
        {
            try
            {
                this.abrirConexao();
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
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Usuario> listar(Usuario filtro)
        {
            List<Usuario> retorno = new List<Usuario>();
            try
            {
                this.abrirConexao();
                string sql = "SELECT cod_usuario,loginUsuario,senha,cod_tipo_usuario FROM usuario where cod_usuario = cod_usuario";
                if (filtro.CodUsuario > 0)
                {
                    sql += " and codUsuario = @codUsuario";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodUsuario > 0)
                {
                    cmd.Parameters.Add("@codUsuario", SqlDbType.Int);
                    cmd.Parameters["@codUsuario"].Value = filtro.CodUsuario;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.CodUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_usuario"));
                    usuario.LoginUsuario = DbReader.GetString(DbReader.GetOrdinal("usuario_login"));
                    usuario.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    usuario.TipoUsuario.CodTipoUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_tipo_usuario"));

                    retorno.Add(usuario);
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

        public bool verificaDuplicidade(Usuario usuario)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
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
