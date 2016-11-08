using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Serie
    {
        private int codSerie;
        private string descricaoSerie;

        public int CodSerie
        {
            get
            {
                return codSerie;
            }

            set
            {
                codSerie = value;
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
