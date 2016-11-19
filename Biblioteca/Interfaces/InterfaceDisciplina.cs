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
        void Inserir(Disciplina disciplina);
        void Alterar(Disciplina disciplina);
        void Excluir(Disciplina disciplina);
        bool VerificaDuplicidade(Disciplina disciplina);
        List<Disciplina> Listar(Disciplina filtro);

    }
}
