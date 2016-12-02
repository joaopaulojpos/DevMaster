using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Falta
    {
        private int codigoFalta;
        private string motivo;
        private bool abono;
        private DateTime data;
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

        public DateTime Data
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

        public Aula Aula
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

        public int CodigoFalta
        {
            get
            {
                return codigoFalta;
            }

            set
            {
                codigoFalta = value;
            }
        }
    }
}
