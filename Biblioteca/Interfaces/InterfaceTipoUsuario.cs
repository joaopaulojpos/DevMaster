using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Basicas;

namespace Biblioteca.Interfaces
{
    interface InterfaceTipoUsuario
    {
        void inserir(TipoUsuario tipoUsuario);
        void alterar(TipoUsuario tipoUsuario);
        void excluir(TipoUsuario tipoUsuario);
        bool verificaDuplicidade(TipoUsuario tipoUsuario);
        List<TipoUsuario> listar(TipoUsuario filtro);
    }
}
