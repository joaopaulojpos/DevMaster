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
        //void Inserir(TipoUsuario ensino);
        //void Alterar(TipoUsuario ensino);
        //void Excluir(TipoUsuario ensino);
        //bool VerificaDuplicidade(TipoUsuario ensino);
        List<TipoUsuario> Listar(TipoUsuario filtro);
    }
}
