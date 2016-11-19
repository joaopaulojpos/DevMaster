using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Falta
    {
        private string motivo;
        private bool abono;
        private string data;
        private Aula aula;
        private Aluno aluno;

        public string Motivo
        {
            get
            {
                return motivo;
            }

            set
            {
                motivo = value;
            }
        }

        public bool Abono
        {
            get
            {
                return abono;
            }

            set
            {
                abono = value;
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

        internal Aula Aula
        {
            get
            {
                return aula;
            }

            set
            {
                aula = value;
            }
        }

        public Aluno Aluno
        {
            get
            {
                return aluno;
            }

            set
            {
                aluno = value;
            }
        }
    }
}
