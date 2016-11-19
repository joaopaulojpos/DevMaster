using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;

namespace Biblioteca.Interfaces
{
    interface InterfaceEnsino
    {
        void Inserir(Ensino ensino);
        void Alterar(Ensino ensino);
        void Excluir(Ensino ensino);
        bool VerificaDuplicidade(Ensino ensino);
        List<Ensino> Listar(Ensino filtro);
    }
}
