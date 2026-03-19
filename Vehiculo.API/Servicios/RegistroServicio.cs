using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Servicios
{
    public class RegistroServicio : IRegistroServicio
    {

        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpclient;


        public RegistroServicio(IConfiguracion configuracion, IHttpClientFactory httpclient, ILogger<RegistroServicio> logger)
        {
            _configuracion = configuracion;
            _httpclient = httpclient;

        }

        public async Task<Propietario> Obtener(string placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistro", "ObtenerPropietario");
            var servicioRegistro = _httpclient.CreateClient("ServicioRegistro");
            var respuesta = await servicioRegistro.GetAsync(string.Format(endPoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Propietario>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
