    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Usuario
    {
        private int codUsuario;
        private string loginUsuario;
        private string senha;
        private TipoUsuario tipoUsuario;

        public int CodUsuario
        {
            get
            {
                return codUsuario;
            }

            set
            {
                codUsuario = value;
            }
        }

        public string LoginUsuario
        {
            get
            {
                return loginUsuario;
            }

            set
            {
                loginUsuario = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public TipoUsuario TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }

            set
            {
                tipoUsuario = value;
            }
        }
    }
}
