using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Erros
{
    public class RepositorioException: Exception
    {
        public RepositorioException() : base()
        {

        }
        public RepositorioException(String msg) : base(msg)
        {

        }
    }
}
