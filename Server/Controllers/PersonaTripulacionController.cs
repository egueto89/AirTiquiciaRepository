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
    public class PersonaTripulacionController : ControllerBase
    {

        private readonly ILogger<PersonaTripulacionController> _logger;
        private readonly ICommand _command;
        public PersonaTripulacionController(ILogger<PersonaTripulacionController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idPersonaTripulacion}")]
        public async Task Eliminar(int idPersonaTripulacion)
        {
            _logger.LogInformation("Elimiando un personaTripulacion");
            await _command.Sql("DELETE FROM PersonaTripulacion WHERE IdPersonaTripulacion =@idPersonaTripulacion").
                Param("idPersonaTripulacion", idPersonaTripulacion)
                .OnError(x => _logger.LogError(x, "Error Eliminando PersonaTripulacion"))
                .Exec();
        }
        [HttpGet("{idPersonaTripulacion}")]
        public async Task Obtener(int idPersonaTripulacion)
        {
            _logger.LogInformation("Obteniendo un personaTripulacion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdPersonaTripulacion, IdPersona ,IdTripulacion  FROM PersonaTripulacion WHERE IdPersonaTripulacion=@idPersonaTripulacion FOR JSON PATH")
                .Param("idPersonaTripulacion", idPersonaTripulacion)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los personaTripulacion");
            await _command.Sql("SELECT IdPersonaTripulacion, IdPersona ,IdTripulacion FROM PersonaTripulacion FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarPersonaTripulacion([FromBody] PersonaTripulacion personaTripulacion)
        {
            await _command.Sql("INSERT INTO PersonaTripulacion(IdPersona ,IdTripulacion) Values(@idpersona,@idtripulacion)")
                .Param("idpersona", personaTripulacion.IdPersona)
                .Param("idtripulacion", personaTripulacion.IdTripulacion)
                .OnError(x => _logger.LogError(x, "Error Insertando PersonaTripulacion"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarPersonaTripulacion([FromBody] PersonaTripulacion personaTripulacion)
        {
            await _command.Sql("UPDATE PersonaTripulacion SET IdPersona =@idpersona," +
                               "IdTripulacion=@idtripulacion WHERE IdPersonaTripulacion=@idPersonaTripulacion")
                .Param("idpersona", personaTripulacion.IdPersona)
                .Param("idtripulacion", personaTripulacion.IdTripulacion)
                .Param("idPersonaTripulacion", personaTripulacion.IdPersonaTripulacion)
                .OnError(x => _logger.LogError(x, "Error Actualizando PersonaTripulacion"))
                .Exec();
        }
    }
}
