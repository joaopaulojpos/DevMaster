using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas; 

namespace Biblioteca.Interfaces
{
    public interface InterfaceFalta
    {
        void Inserir(Falta falta);
        void Alterar(Falta falta);
        void Excluir(Falta falta);
        List<Falta> Listar(Falta filtro);
    }
}
