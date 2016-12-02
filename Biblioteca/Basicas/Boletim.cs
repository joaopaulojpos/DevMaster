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
    public class Boletim
    {
        private Avaliacao avaliacao;
        
        [DataMember(IsRequired = true)]
        public Avaliacao Avaliacao
        {
            get
            {
                return avaliacao;
            }

            set
            {
                avaliacao = value;
            }
        }
    }
}
