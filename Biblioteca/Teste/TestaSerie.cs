using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Basicas;
using Biblioteca.DAO;
using Biblioteca.Util;

namespace Biblioteca.Teste
{
    public partial class TestaSerie : Form
    {
        public TestaSerie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            Ensino serie = new Ensino();
            serie.DescricaoEnsino = descricao;
            DAOEnsino.Instancia.Inserir(serie);
            
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            int codigo = Convert.ToInt32(textBoxCodigo.Text);
            Ensino serie = new Ensino();
            serie.CodigoEnsino = codigo;
            DAOEnsino.Instancia.Excluir(serie);

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBoxCodigo);
            string descricao = textBoxDescricao.Text;
            Ensino serie = new Ensino();
            serie.CodigoEnsino = codigo;
            serie.DescricaoEnsino = descricao;
            DAOEnsino.Instancia.Alterar(serie);

        }

        private void btnListar_Click(object sender, EventArgs e)
        {

        }
    }
}
