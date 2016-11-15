using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;

namespace Biblioteca.Interfaces
{
    public interface InterfaceAvaliacao
    {
        void Inserir(Avaliacao avaliacao);
        void Alterar(Avaliacao avaliacao);
        void Excluir(Avaliacao avaliacao);
        bool VerificaDuplicidade(Avaliacao avaliacao);
        List<Avaliacao> Listar(Avaliacao filtro);
    }
}
