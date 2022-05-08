using Belgrade.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuscarVueloController : ControllerBase
    {

        private readonly ILogger<BuscarVueloController> _logger;
        private readonly ICommand _command;
        public BuscarVueloController(ILogger<BuscarVueloController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }


        [HttpGet("buscarVuelosDisponibles/{idDestino}/{idDestinoLlegada}/{fechaSalida}")]
        public async Task BuscarVuelosDisponibles(int idDestino, int idDestinoLlegada, string fechaSalida)
        {
            _logger.LogInformation("Obteniendo un avion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT " +
                                    "v.IdVuelo," +
                                    "v.IdTipoVuelo," +
                                    "v.IdAvion," +
                                    "v.IdDestino," +
                                    "v.IdDestinoLlegada," +
                                    "v.NumeroVuelo," +
                                    "v.FechaSalida, " +
                                    "v.FechaLLegada, " +
                                    "v.HoraSalida, " +
                                    "v.MinutosSalida, " +
                                    "v.DuracionHoraVuelo, " +
                                    "v.DuracionMinutosVuelo, " +
                                    "v.HoraLLegada, " +
                                    "v.MinutosLLegada," +
                                    "tv.Descripcion AS TipoVueloDescripcion," +
                                    "av.Descripcion AS AvionDescripcion," +
                                    "de.Nombre AS DestinoDescripcion," +
                                    "des.Nombre AS DestinoLlegada , v.Precio" +
              " FROM Vuelo v INNER JOIN TipoVuelo tv ON v.IdTipoVuelo = tv.IdTipoVuelo " +
              " INNER JOIN Avion av ON v.IdAvion = av.IdAvion " +
              " INNER JOIN Destino de ON v.IdDestino = de.IdDestino " +
              "INNER JOIN Destino des ON v.IdDestinoLlegada =des.IdDestino  " +
                " WHERE de.IdDestino=@idDestino  AND  des.IdDestino=@idDestinoLlegada  AND CONVERT(DATE,FechaSalida) between @fechaSalida AND @fechaSalida  FOR JSON PATH")
                .Param("idDestino", idDestino)
                .Param("idDestinoLlegada", idDestinoLlegada)
                .Param("fechaSalida", fechaSalida)
                
                .Stream(Response.Body, defaultOutput: "[]");
        }
 
    }
}
