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
    public class TipoVueloController : ControllerBase
    {

        private readonly ILogger<TipoVueloController> _logger;
        private readonly ICommand _command;
        public TipoVueloController(ILogger<TipoVueloController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTipoVuelo}")]
        public async Task Eliminar(int idTipoVuelo)
        {
            _logger.LogInformation("Elimiando un tipoVuelo");
            await _command.Sql("DELETE FROM TipoVuelo WHERE IdTipoVuelo =@idTipoVuelo").
                Param("idTipoVuelo", idTipoVuelo)
                .OnError(x => _logger.LogError(x, "Error Eliminando TipoVuelo"))
                .Exec();
        }
        [HttpGet("{idTipoVuelo}")]
        public async Task Obtener(int idTipoVuelo)
        {
            _logger.LogInformation("Obteniendo un tipoVuelo");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT * FROM TipoVuelo WHERE IdTipoVuelo=@idTipoVuelo FOR JSON PATH")
                .Param("idTipoVuelo", idTipoVuelo)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los tipoVuelo");
            await _command.Sql("SELECT * FROM TipoVuelo FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTipoVuelo([FromBody] TipoVuelo tipoVuelo)
        {
            await _command.Sql("INSERT INTO TipoVuelo(Descripcion) Values(@descripcion)")
                .Param("descripcion", tipoVuelo.Descripcion)
                .OnError(x => _logger.LogError(x, "Error Insertando TipoVuelo"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTipoVuelo([FromBody] TipoVuelo tipoVuelo)
        {
            await _command.Sql("UPDATE TipoVuelo SET Descripcion =@descripcion WHERE IdTipoVuelo=@idTipoVuelo")
                .Param("descripcion", tipoVuelo.Descripcion)
                .Param("idTipoVuelo", tipoVuelo.IdTipoVuelo)
                .OnError(x => _logger.LogError(x, "Error Actualizando TipoVuelo"))
                .Exec();
        }
    }
}
