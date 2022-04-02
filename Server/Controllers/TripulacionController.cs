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
    public class TripulacionController : ControllerBase
    {

        private readonly ILogger<TripulacionController> _logger;
        private readonly ICommand _command;
        public TripulacionController(ILogger<TripulacionController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTripulacion}")]
        public async Task Eliminar(int idTripulacion)
        {
            _logger.LogInformation("Elimiando tripulación");
            await _command.Sql("DELETE FROM Tripulacion WHERE IdTripulacion =@idTripulacion").
                Param("idTripulacion", idTripulacion)
                .OnError(x => _logger.LogError(x, "Error Eliminando Tripulacion"))
                .Exec();
        }
        [HttpGet("{idTripulacion}")]
        public async Task Obtener(int idTripulacion)
        {
            _logger.LogInformation("Obteniendo un(a) tripulación");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT * FROM Tripulacion WHERE IdTripulacion=@idTripulacion FOR JSON PATH")
                .Param("idTripulacion", idTripulacion)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  tripulación");
            await _command.Sql("SELECT * FROM Tripulacion FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTripulacion([FromBody] Tripulacion tripulacion)
        {
            await _command.Sql("INSERT INTO Tripulacion(Descripcion) Values(@descripcion)")
                .Param("descripcion", tripulacion.Descripcion)
                .OnError(x => _logger.LogError(x, "Error Insertando Tripulacion"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTripulacion([FromBody] Tripulacion tripulacion)
        {
            await _command.Sql("UPDATE Tripulacion SET Descripcion =@descripcion WHERE IdTripulacion=@idTripulacion")
                .Param("descripcion", tripulacion.Descripcion)
                .Param("idTripulacion", tripulacion.IdTripulacion)
                .OnError(x => _logger.LogError(x, "Error Actualizando Tripulacion"))
                .Exec();
        }
    }
}
