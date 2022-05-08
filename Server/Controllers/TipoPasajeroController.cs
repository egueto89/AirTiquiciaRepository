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
    public class TipoPasajeroController : ControllerBase
    {

        private readonly ILogger<TipoPasajeroController> _logger;
        private readonly ICommand _command;
        public TipoPasajeroController(ILogger<TipoPasajeroController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTipoPasajero}")]
        public async Task Eliminar(int idTipoPasajero)
        {
            _logger.LogInformation("Elimiando un tipoPasajero");
            await _command.Sql("DELETE FROM TipoPasajero WHERE IdTipoPasajero =@idTipoPasajero").
                Param("idTipoPasajero", idTipoPasajero)
                .OnError(x => _logger.LogError(x, "Error Eliminando TipoPasajero"))
                .Exec();
        }
        [HttpGet("{idTipoPasajero}")]
        public async Task Obtener(int idTipoPasajero)
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo un tipoPasajero");  
            await _command.Sql("SELECT * FROM TipoPasajero WHERE IdTipoPasajero=@idTipoPasajero FOR JSON PATH")
                .Param("idTipoPasajero", idTipoPasajero)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los tipoPasajero");
            await _command.Sql("SELECT * FROM TipoPasajero FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTipoPasajero([FromBody] TipoPasajero tipoPasajero)
        {
            await _command.Sql("INSERT INTO TipoPasajero(Descripcion) Values(@tipoPasajero)")
                .Param("tipoPasajero", tipoPasajero.Descripcion)
                .OnError(x => _logger.LogError(x, "Error Insertando TipoPasajero"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTipoPasajero([FromBody] TipoPasajero tipoPasajero)
        {
            await _command.Sql("UPDATE TipoPasajero SET Descripcion =@tipoPasajero WHERE IdTipoPasajero=@idTipoPasajero")
                .Param("tipoPasajero", tipoPasajero.Descripcion)
                .Param("idTipoPasajero", tipoPasajero.IdTipoPasajero)
                .OnError(x => _logger.LogError(x, "Error Actualizando TipoPasajero"))
                .Exec();
        }
    }
}
