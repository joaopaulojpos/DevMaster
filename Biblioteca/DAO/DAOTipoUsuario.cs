using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Util;
using Biblioteca.Interfaces;
using Biblioteca.Basicas;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.DAO
{
    public class DAOTipoUsuario : ConexaoBanco, InterfaceTipoUsuario
    {
        #region Atributos



        #endregion

        #region Construtores



        #endregion

        #region Implementação da Interface

        #region Listar

        public List<TipoUsuario> Listar(TipoUsuario filtro)
        {
            List<TipoUsuario> retorno = new List<TipoUsuario>();
            try
            {
                this.AbrirConexao();
                string sql = "SELECT cod_tipo_usuario,desc_tipo_usuario FROM Tipo_usuario WHERE cod_tipo_usuario = cod_tipo_usuario";
                if (filtro.CodTipoUsuario > 0)
                {
                    sql += " and cod_tipo_usuario = @codigoTipoUsuario";
                }
                if (filtro.DescricaoTipoUsuario != null && filtro.DescricaoTipoUsuario.Trim().Equals("") == false)
                {
                    sql += " and desc_tipo_usuario like '%" + filtro.DescricaoTipoUsuario.Trim() + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                if (filtro.CodTipoUsuario > 0)
                {
                    cmd.Parameters.Add("@codigoTipoUsuario", SqlDbType.Int);
                    cmd.Parameters["@codigoTipoUsuario"].Value = filtro.CodTipoUsuario;
                }
                if (filtro.DescricaoTipoUsuario != null && filtro.DescricaoTipoUsuario.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricaoTipoUsuario", SqlDbType.VarChar);
                    cmd.Parameters["@descricaoTipoUsuario"].Value = filtro.DescricaoTipoUsuario;

                }
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.CodTipoUsuario = DbReader.GetInt32(DbReader.GetOrdinal("cod_tipo_usuario"));
                    tipoUsuario.DescricaoTipoUsuario = DbReader.GetString(DbReader.GetOrdinal("desc_tipo_usuario"));
                    retorno.Add(tipoUsuario);
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

        #endregion

        #endregion

    }
}
