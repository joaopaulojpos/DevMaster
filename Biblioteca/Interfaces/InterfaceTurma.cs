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
        void Inserir(Turma turma);
        void Alterar(Turma turma);
        void Excluir(Turma turma);
        bool VerificaDuplicidade(Turma turma);
        List<Turma> Listar(Turma filtro);

    }
}
