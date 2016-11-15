
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;

namespace Biblioteca.Interfaces
{
    public interface InterfaceAula
    {
        void inserir(Aula aula);
        void alterar(Aula aula);
        void excluir(Aula aula);
        bool verificaDuplicidade(Aula aula);
        List<Aula> listar(Aula filtro);
    }
}
