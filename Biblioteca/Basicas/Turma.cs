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
        private string turno;
        private int ano;
        private string dataInicio;
        private Ensino ensino;
        private List<Disciplina_Turma> disciplinas;

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

        public string Turno
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
                return ensino;
            }

            set
            {
                ensino = value;
            }
        }

        public List<Disciplina_Turma> Disciplinas
        {
            get
            {
                return disciplinas;
            }

            set
            {
                disciplinas = value;
            }
        }
    }
}
