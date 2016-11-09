using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Aula
    {
        private int codigoAula;
        private string data;
        private string assunto;
        private Disciplina disciplina;

        public int CodigoAula
        {
            get
            {
                return codigoAula;
            }

            set
            {
                codigoAula = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public string Assunto
        {
            get
            {
                return assunto;
            }

            set
            {
                assunto = value;
            }
        }

        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }

            set
            {
                disciplina = value;
            }
        }
    }
}
