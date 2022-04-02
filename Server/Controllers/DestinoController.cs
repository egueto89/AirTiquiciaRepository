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
    public class DestinoController : ControllerBase
    {

        private readonly ILogger<DestinoController> _logger;
        private readonly ICommand _command;
        public DestinoController(ILogger<DestinoController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idDestino}")]
        public async Task Eliminar(int idDestino)
        {
            _logger.LogInformation("Elimiando un destino");
            await _command.Sql("DELETE FROM Destino WHERE IdDestino =@idDestino").
                Param("idDestino", idDestino)
                .OnError(x => _logger.LogError(x, "Error Eliminando Destino"))
                .Exec();
        }
        [HttpGet("{idDestino}")]
        public async Task Obtener(int idDestino)
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo un destino");  
            await _command.Sql("SELECT * FROM Destino WHERE IdDestino=@idDestino FOR JSON PATH")
                .Param("idDestino", idDestino)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los destino");
            await _command.Sql("SELECT * FROM Destino FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarDestino([FromBody] Destino destino)
        {
            await _command.Sql("INSERT INTO Destino(Nombre) Values(@destino)")
                .Param("destino", destino.Nombre)
                .OnError(x => _logger.LogError(x, "Error Insertando Destino"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarDestino([FromBody] Destino destino)
        {
            await _command.Sql("UPDATE Destino SET Nombre =@destino WHERE IdDestino=@idDestino")
                .Param("destino", destino.Nombre)
                .Param("idDestino", destino.IdDestino)
                .OnError(x => _logger.LogError(x, "Error Actualizando Destino"))
                .Exec();
        }
    }
}
