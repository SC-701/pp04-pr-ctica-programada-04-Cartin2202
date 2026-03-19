using Abstracciones.Modelos;
using Abstracciones.Modelos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IModeloFlujo
    {
        Task<IEnumerable<Modelo>> Obtener(Guid IdMarca);
    }
}
