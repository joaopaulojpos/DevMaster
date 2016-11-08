using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    class Usuario
    {
        private int codUsuario;
        private string loginUsuario;
        private string senha;

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
    }
}
