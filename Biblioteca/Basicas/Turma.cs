using Biblioteca.Interfaces;
using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    [Serializable]
    [DataContract()]
    public class Turma
    {
        private int codigoTurma;
        private string descricaoTurma;
        private string turno;
        private int ano;
        private DateTime dataInicio;
        private Ensino ensino;
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
        public DateTime DataInicio
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
        [DataMember(IsRequired = true)]
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
    }
}
