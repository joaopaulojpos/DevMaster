using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    public interface InterfaceAluno
    {
        void inserir(Aluno aluno);
        void alterar(Aluno aluno);
        void excluir(Aluno aluno);
        bool verificaDuplicidade(Aluno aluno);
        List<Aluno> listar(Aluno filtro);

    }
}
