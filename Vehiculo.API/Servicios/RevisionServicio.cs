using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using Abstracciones.Modelos.Servicios.Revision;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Servicios
{
    public class RevisionServicio : IRevisionServicio
    {

        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpclient;


        public RevisionServicio(IConfiguracion configuracion, IHttpClientFactory httpclient, ILogger<RevisionServicio> logger)
        {
            _configuracion = configuracion;
            _httpclient = httpclient;

        }

        public async Task<Revision> Obtener(string placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRevision", "ObtenerRevision");
            var servicioRegistro = _httpclient.CreateClient("ServicioRevision");
            var respuesta = await servicioRegistro.GetAsync(string.Format(endPoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
