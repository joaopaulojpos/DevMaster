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
        void Inserir(Professor professor);
        void Alterar(Professor professor);
        void Excluir(Professor professor);
        bool VerificaDuplicidade(Professor professor);
        List<Professor> Listar(Professor filtro);

    }
}
