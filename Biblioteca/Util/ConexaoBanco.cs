using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblioteca.Util
{
    public class ConexaoBanco
    {
        #region variáveis
        public SqlConnection sqlConn;
        //private const string local = "DESKTOP-5HIVE2F";//Servidor Joao Paulo
        private const string local = "RHUAN\\SQLEXPRESS";//Servidor Rhuan
        private const string banco_de_dados = "DevMaster";
        private const string usuario = "DevMaster";
        private const string senha = "1234";
        #endregion

        string connectionStringSqlServer = @"Data Source=" + local + ";Initial Catalog=" + banco_de_dados + ";UId=" + usuario + ";Password=" + senha + ";";

        public void abrirConexao()
        {
            this.sqlConn = new SqlConnection(connectionStringSqlServer);
            try {
                this.sqlConn.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha ao conectar com o banco de dados.\nErro: "+ex.Message);
            }
        }
        public void fecharConexao()
        {
            try {
                sqlConn.Close();
                sqlConn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha ao conectar com o banco de dados.\nErro: " + ex.Message);
            }
        }
    }
}
