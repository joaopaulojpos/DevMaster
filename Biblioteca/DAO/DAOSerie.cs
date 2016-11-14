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
    class DAOSerie : ConexaoBanco, InterfaceSerie
    {
        public void alterar(Serie serie)
        {
            throw new NotImplementedException();
        }

        public void excluir(Serie serie)
        {
            throw new NotImplementedException();
        }

        public void inserir(Serie serie)
        {
            try
            {
                this.abrirConexao();
                string sql = 
                    "INSERT INTO Serie"
                  + "(cod_serie, descricao_serie)"
                  + "VALUES"
                  + "(@cod_serie, @descricao_serie); ";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@cod_serie", SqlDbType.Int);
                cmd.Parameters["@cod_serie"].Value = serie.CodSerie;

                cmd.Parameters.Add("@descricao_serie", SqlDbType.VarChar);
                cmd.Parameters["@descricao_serie"].Value = serie.DescricaoSerie;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<Serie> listar(Serie filtro)
        {
            throw new NotImplementedException();
        }

        public bool verificaDuplicidade(Serie serie)
        {
            throw new NotImplementedException();
        }
    }
}
