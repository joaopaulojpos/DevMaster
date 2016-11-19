using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class TipoUsuario
    {
        private int codTipoUsuario;
        private string descricaoTipoUsuario;

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
