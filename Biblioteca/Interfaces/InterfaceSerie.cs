using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;

namespace Biblioteca.Interfaces
{
    interface InterfaceSerie
    {
        void inserir(Serie serie);
        void alterar(Serie serie);
        void excluir(Serie serie);
        bool verificaDuplicidade(Serie serie);
        List<Serie> listar(Serie filtro);
    }
}
