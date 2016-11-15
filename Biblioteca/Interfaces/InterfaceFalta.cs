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
        void inserir(Falta falta);
        void alterar(Falta falta);
        void excluir(Falta falta);
        bool verificaDuplicidade(Falta falta);
        List<Falta> listar(Falta filtro);
    }
}
