using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTower.Interfaces
{
    interface ISelecaoRepository
    {
        List<Selecao> Listar();
    }
}
