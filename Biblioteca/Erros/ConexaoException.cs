using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Erros
{
    public class ConexaoException: Exception
    {
        public ConexaoException() : base()
        {

        }

        public ConexaoException(String msg) : base(msg)
        {

        }
    }
}
