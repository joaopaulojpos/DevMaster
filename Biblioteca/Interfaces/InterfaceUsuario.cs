using Biblioteca.Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    public interface InterfaceUsuario
    {
        void inserir(Usuario usuario);
        void alterar(Usuario usuario);
        void excluir(Usuario usuario);
        bool verificaDuplicidade(Usuario usuario);
        List<Usuario> listar(Usuario filtro);

    }
}
