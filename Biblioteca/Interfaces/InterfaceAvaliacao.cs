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
        void inserir(Avaliacao avaliacao);
        void alterar(Avaliacao avaliacao);
        void excluir(Avaliacao avaliacao);
        bool verificaDuplicidade(Avaliacao avaliacao);
        List<Avaliacao> listar(Avaliacao filtro);
    }
}
