using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca.Erros;

namespace Biblioteca.Util
{
    public class ConexaoBanco
    {
        #region variáveis
        //tipo responsável para se trabalhar com o sqlserver
        public SqlConnection sqlConn;
        //máquina no qual estará o banco de dados
        private const string local = "RHUAN\\SQLEXPRESS";
        //nome do banco de dados no qual desejamos nos comunicar
        private const string banco_de_dados = "DevMaster";
        //usuário que tenha os privilégios para utilizar o banco de dados
        private const string usuario = "rhuan";
        //senha do usuario
        private const string senha = "1234";
        #endregion

        //string de conexão obtida para o sql sever
        string connectionStringSqlServer = @"Data Source=" + local + ";Initial Catalog=" + banco_de_dados + ";UId=" + usuario + ";Password=" + senha + ";";

        public void abrirConexao()
        {
            //iniciando uma conexão com o sql server, utilizando os parâmetros da string de conexão
            this.sqlConn = new SqlConnection(connectionStringSqlServer);
            try {
                this.sqlConn.Open();
            }
            catch (SqlException ex)
            {
                throw new ConexaoException(ex.Message);
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
                throw new ConexaoException();
            }
        }
    }
}
