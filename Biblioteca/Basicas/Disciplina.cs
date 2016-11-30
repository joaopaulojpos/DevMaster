using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Disciplina
    {
        private int codigoDisciplina;
        private string nomeDisciplina;

        public int CodigoDisciplina
        {
            get
            {
                return codigoDisciplina;
            }

            set
            {
                codigoDisciplina = value;
            }
        }

        public string NomeDisciplina
        {
            get
            {
                return nomeDisciplina;
            }

            set
            {
                nomeDisciplina = value;
            }
        }
        public string ToString()
        {
            return "codigo: "+codigoDisciplina+" nome: "+nomeDisciplina;
        }
    }
}
