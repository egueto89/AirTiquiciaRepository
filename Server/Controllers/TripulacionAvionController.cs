using AirTiquiciaAPP.Shared;
using Belgrade.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripulacionAvionController : ControllerBase
    {

        private readonly ILogger<TripulacionAvionController> _logger;
        private readonly ICommand _command;
        public TripulacionAvionController(ILogger<TripulacionAvionController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTripulacionAvion}")]
        public async Task Eliminar(int idTripulacionAvion)
        {
            _logger.LogInformation("Elimiando un tripulacionAvion");
            await _command.Sql("DELETE FROM TripulacionAvion WHERE IdTripulacionAvion =@idTripulacionAvion").
                Param("idTripulacionAvion", idTripulacionAvion)
                .OnError(x => _logger.LogError(x, "Error Eliminando TripulacionAvion"))
                .Exec();
        }
        [HttpGet("{idTripulacionAvion}")]
        public async Task Obtener(int idTripulacionAvion)
        {
            _logger.LogInformation("Obteniendo un tripulacionAvion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdTripulacionAvion, IdPersona ,IdPersonaTripulacion  FROM TripulacionAvion WHERE IdTripulacionAvion=@idTripulacionAvion FOR JSON PATH")
                .Param("idTripulacionAvion", idTripulacionAvion)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los tripulacionAvion");
            await _command.Sql("SELECT IdTripulacionAvion, IdPersona ,IdPersonaTripulacion FROM TripulacionAvion FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTripulacionAvion([FromBody] TripulacionAvion tripulacionAvion)
        {
            await _command.Sql("INSERT INTO TripulacionAvion(IdPersona ,IdPersonaTripulacion) Values(@idpersona,@idpersonaTripulacion)")
                .Param("idpersona", tripulacionAvion.IdPersona)
                .Param("idpersonaTripulacion", tripulacionAvion.IdPersonaTripulacion)
                .OnError(x => _logger.LogError(x, "Error Insertando TripulacionAvion"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTripulacionAvion([FromBody] TripulacionAvion tripulacionAvion)
        {
            await _command.Sql("UPDATE TripulacionAvion SET IdPersona =@idpersona," +
                               "IdPersonaTripulacion=@idpersonaTripulacion WHERE IdTripulacionAvion=@idTripulacionAvion")
              .Param("idpersona", tripulacionAvion.IdPersona)
                .Param("idpersonaTripulacion", tripulacionAvion.IdPersonaTripulacion)
                .Param("idTripulacionAvion", tripulacionAvion.IdTripulacionAvion)
                .OnError(x => _logger.LogError(x, "Error Actualizando TripulacionAvion"))
                .Exec();
        }
    }
}
