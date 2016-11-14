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
            string codigo = textBoxCodigo.Text;
            string descricao = textBoxDescricao.Text;
            Serie serie = new Serie();
            serie.CodSerie = Convert.ToInt32(codigo);
            serie.DescricaoSerie = descricao;
            DAOSerie daoSerie = new DAOSerie();
            daoSerie.inserir(serie);
            
        }
    }
}
