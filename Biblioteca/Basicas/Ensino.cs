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
    public class Ensino
    {
        private int codigoEnsino;
        private string descricaoEnsino;
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
