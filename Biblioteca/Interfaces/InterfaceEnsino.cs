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
        void Inserir(Ensino serie);
        void Alterar(Ensino serie);
        void Excluir(Ensino serie);
        bool VerificaDuplicidade(Ensino serie);
        List<Ensino> Listar(Ensino filtro);
    }
}
