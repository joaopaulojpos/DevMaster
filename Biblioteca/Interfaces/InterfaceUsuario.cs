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
        void Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        bool VerificaDuplicidade(Usuario usuario);
        List<Usuario> Listar(Usuario filtro);

    }
}
