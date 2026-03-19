using Abstracciones.Modelos;
using Abstracciones.Modelos.Marca;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcaDA
    {
        Task<IEnumerable<Marca>> Obtener();
    }
}

