
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
        void Inserir(Aula aula);
        void Alterar(Aula aula);
        void Excluir(Aula aula);
        bool VerificaDuplicidade(Aula aula);
        List<Aula> Listar(Aula filtro);
    }
}
