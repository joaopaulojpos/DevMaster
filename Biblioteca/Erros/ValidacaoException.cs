using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Erros
{
    public class ValidacaoException: Exception
    {
        public ValidacaoException():base()
        {
            
        }
        public ValidacaoException(String msg) : base(msg)
        {

        }
    }
}
