using Abstracciones.Modelos;
using Abstracciones.Modelos.Modelo;

namespace Abstracciones.Interfaces.DA
{
    public interface IModeloDA
    {
        Task<IEnumerable<Modelo>> Obtener(Guid IdMarca);
    }
}
