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
        void Inserir(Serie serie);
        void Alterar(Serie serie);
        void Excluir(Serie serie);
        bool VerificaDuplicidade(Serie serie);
        List<Serie> Listar(Serie filtro);
    }
}
