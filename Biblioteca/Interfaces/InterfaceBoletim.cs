using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    interface InterfaceBoletim
    {
        List<Boletim> listar(Boletim filtro);
    }
}
