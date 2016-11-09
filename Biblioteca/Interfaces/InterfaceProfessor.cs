using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    public interface InterfaceProfessor
    {
        void inserir(Professor professor);
        void alterar(Professor professor);
        void excluir(Professor professor);
        bool verificaDuplicidade(Professor professor);
        List<Professor> listar(Professor filtro);

    }
}
