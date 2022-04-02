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
    public class TipoPersonaController : ControllerBase
    {

        private readonly ILogger<TipoPersonaController> _logger;
        private readonly ICommand _command;
        public TipoPersonaController(ILogger<TipoPersonaController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTipoPersona}")]
        public async Task Eliminar(int idTipoPersona)
        {
            _logger.LogInformation("Elimiando tipoPersona");
            await _command.Sql("DELETE FROM TipoPersona WHERE IdTipoPersona =@idTipoPersona").
                Param("idTipoPersona", idTipoPersona)
                .OnError(x => _logger.LogError(x, "Error Eliminando TipoPersona"))
                .Exec();
        }
        [HttpGet("{idTipoPersona}")]
        public async Task Obtener(int idTipoPersona)
        {
            _logger.LogInformation("Obteniendo un(a) tipoPersona");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT tp.IdTipoPersona , tp.IdPersona,tp.Tipo,CONCAT(per.Nombre, '  ', per.Apellidos) as NombrePersona FROM TipoPersona tp  INNER JOIN Persona per on tp.IdPersona = per.IdPersona WHERE IdTipoPersona=@idTipoPersona FOR JSON PATH")
                .Param("idTipoPersona", idTipoPersona)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  tipoPersona");
            await _command.Sql("SELECT tp.IdTipoPersona , tp.IdPersona,tp.Tipo,CONCAT(per.Nombre, '  ', per.Apellidos) as NombrePersona FROM TipoPersona tp  INNER JOIN Persona per on tp.IdPersona = per.IdPersona FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTipoPersona([FromBody] TipoPersona tipoPersona)
        {
            await _command.Sql("INSERT INTO TipoPersona( IdPersona, Tipo) Values(@idPersona, @tipo)")
                .Param("idPersona", tipoPersona.IdPersona)
                .Param("tipo", tipoPersona.Tipo)
                .OnError(x => _logger.LogError(x, "Error Insertando TipoPersona"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTipoPersona([FromBody] TipoPersona tipoPersona)
        {
            await _command.Sql("UPDATE TipoPersona SET " +
                                        "IdPersona =@idPersona," +
                                        "Tipo=@tipo"+
                                "WHERE IdTipoPersona=@idTipoPersona")
                .Param("nombre", tipoPersona.IdPersona)
                .Param("apellidos", tipoPersona.IdTipoPersona)
                .Param("idTipoPersona", tipoPersona.IdTipoPersona)
                .OnError(x => _logger.LogError(x, "Error Actualizando TipoPersona"))
                .Exec();
        }
    }
}