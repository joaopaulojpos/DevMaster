using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    public interface InterfaceTurma
    {
        void inserir(Turma turma);
        void alterar(Turma turma);
        void excluir(Turma turma);
        bool verificaDuplicidade(Turma turma);
        List<Turma> listar(Turma filtro);

    }
}
