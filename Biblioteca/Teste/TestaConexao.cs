using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Util;

namespace Biblioteca.Teste
{
    public partial class TestaConexao : Form
    {
        public TestaConexao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConexaoBanco conexao = new ConexaoBanco();
                conexao.abrirConexao();
                label1.Text = "Conectou!";
                conexao.fecharConexao();
            }
            catch (Exception e)
            {
                label1.Text = e;
            }
        }
    }
}
