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
    public class Disciplina
    {
        private int codigoDisciplina;
        private string nomeDisciplina;

        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
