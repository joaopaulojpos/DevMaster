using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    public interface InterfaceDisciplina
    {
        void inserir(Disciplina disciplina);
        void alterar(Disciplina disciplina);
        void excluir(Disciplina disciplina);
        bool verificaDuplicidade(Disciplina disciplina);
        List<Disciplina> listar(Disciplina filtro);

    }
}
