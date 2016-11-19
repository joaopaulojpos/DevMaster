using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Serie
    {
        private int codigoSerie;
        private string descricaoSerie;

        public int CodigoSerie
        {
            get
            {
                return codigoSerie;
            }

            set
            {
                codigoSerie = value;
            }
        }

        public string DescricaoSerie
        {
            get
            {
                return descricaoSerie;
            }

            set
            {
                descricaoSerie = value;
            }
        }
    }
}
