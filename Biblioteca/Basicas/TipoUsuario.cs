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
    public class TipoUsuario
    {
        private int codTipoUsuario;
        private string descricaoTipoUsuario;

        [DataMember(IsRequired = true)]
        public int CodTipoUsuario
        {
            get
            {
                return codTipoUsuario;
            }

            set
            {
                codTipoUsuario = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string DescricaoTipoUsuario
        {
            get
            {
                return descricaoTipoUsuario;
            }

            set
            {
                descricaoTipoUsuario = value;
            }
        }
    }
}
