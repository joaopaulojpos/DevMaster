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
        void Inserir(TipoUsuario tipoUsuario);
        void Alterar(TipoUsuario tipoUsuario);
        void Excluir(TipoUsuario tipoUsuario);
        bool VerificaDuplicidade(TipoUsuario tipoUsuario);
        List<TipoUsuario> Listar(TipoUsuario filtro);
    }
}
