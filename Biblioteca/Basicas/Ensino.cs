using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Ensino
    {
        private int codigoEnsino;
        private string descricaoEnsino;

        public int CodigoEnsino
        {
            get
            {
                return codigoEnsino;
            }

            set
            {
                codigoEnsino = value;
            }
        }

        public string DescricaoEnsino
        {
            get
            {
                return descricaoEnsino;
            }

            set
            {
                descricaoEnsino = value;
            }
        }
    }
}
