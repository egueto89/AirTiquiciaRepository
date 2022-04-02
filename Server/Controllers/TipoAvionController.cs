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
    public class TipoAvionController : ControllerBase
    {

        private readonly ILogger<TipoAvionController> _logger;
        private readonly ICommand _command;
        public TipoAvionController(ILogger<TipoAvionController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idTipoAvion}")]
        public async Task Eliminar(int idTipoAvion)
        {
            _logger.LogInformation("Elimiando tipoAvion");
            await _command.Sql("DELETE FROM TipoAvion WHERE IdTipoAvion =@idTipoAvion").
                Param("idTipoAvion", idTipoAvion)
                .OnError(x => _logger.LogError(x, "Error Eliminando TipoAvion"))
                .Exec();
        }
        [HttpGet("{idTipoAvion}")]
        public async Task Obtener(int idTipoAvion)
        {
            _logger.LogInformation("Obteniendo un(a) tipoAvion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdTipoAvion , Descripcion, Fila,Asiento FROM TipoAvion WHERE IdTipoAvion=@idTipoAvion FOR JSON PATH")
                .Param("idTipoAvion", idTipoAvion)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  tipoAvion");
            await _command.Sql("SELECT IdTipoAvion , Descripcion, Fila,Asiento FROM TipoAvion FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarTipoAvion([FromBody] TipoAvion tipoAvion)
        {
            await _command.Sql("INSERT INTO TipoAvion( Descripcion, Fila,Asiento) Values(@descripcion, @fila,@asiento)")
                .Param("descripcion", tipoAvion.Descripcion)
                .Param("fila", tipoAvion.Fila)
                .Param("asiento", tipoAvion.Asiento)
                .OnError(x => _logger.LogError(x, "Error Insertando TipoAvion"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarTipoAvion([FromBody] TipoAvion tipoAvion)
        {
            await _command.Sql("UPDATE TipoAvion SET " +
                                        "Descripcion =@descripcion," +
                                        "Fila = @fila," +
                                        "Asiento =@asiento" +
                                " WHERE IdTipoAvion=@idTipoAvion")
                .Param("descripcion", tipoAvion.Descripcion)
                .Param("fila", tipoAvion.Fila)
                .Param("asiento", tipoAvion.Asiento)
                .Param("idTipoAvion", tipoAvion.IdTipoAvion)
                .OnError(x => _logger.LogError(x, "Error Actualizando TipoAvion"))
                .Exec();
        }
    }
}