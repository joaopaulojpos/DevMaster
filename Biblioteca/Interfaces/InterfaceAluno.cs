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
        void Inserir(Aluno aluno);
        void Alterar(Aluno aluno);
        void Excluir(Aluno aluno);
        bool VerificaDuplicidade(Aluno aluno);
        List<Aluno> Listar(Aluno filtro);

    }
}
