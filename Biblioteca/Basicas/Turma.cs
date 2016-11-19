using Biblioteca.Interfaces;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Turma
    {
        private int codigoTurma;
        private string descricaoTurma;
        private char turno;
        private int ano;
        private string dataInicio;
        private Ensino serie;

        public int CodigoTurma
        {
            get
            {
                return codigoTurma;
            }

            set
            {
                codigoTurma = value;
            }
        }

        public string DescricaoTurma
        {
            get
            {
                return descricaoTurma;
            }

            set
            {
                descricaoTurma = value;
            }
        }

        public char Turno
        {
            get
            {
                return turno;
            }

            set
            {
                turno = value;
            }
        }

        public int Ano
        {
            get
            {
                return ano;
            }

            set
            {
                ano = value;
            }
        }

        public string DataInicio
        {
            get
            {
                return dataInicio;
            }

            set
            {
                dataInicio = value;
            }
        }

        public Ensino Ensino
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
            }
        }
    }
}
