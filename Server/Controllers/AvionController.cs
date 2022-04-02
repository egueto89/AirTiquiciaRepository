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
    public class AvionController : ControllerBase
    {

        private readonly ILogger<AvionController> _logger;
        private readonly ICommand _command;
        public AvionController(ILogger<AvionController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idAvion}")]
        public async Task Eliminar(int idAvion)
        {
            _logger.LogInformation("Elimiando un avion");
            await _command.Sql("DELETE FROM Avion WHERE IdAvion =@idAvion").
                Param("idAvion", idAvion)
                .OnError(x => _logger.LogError(x, "Error Eliminando Avion"))
                .Exec();
        }
        [HttpGet("{idAvion}")]
        public async Task Obtener(int idAvion)
        {
            _logger.LogInformation("Obteniendo un avion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT a.IdAvion, a.IdTipoAvion,a.Descripcion,t.Descripcion as DescripcionTipoAvion FROM Avion a INNER JOIN TipoAvion t ON a.IdTipoAvion = t.IdTipoAvion WHERE IdAvion=@idAvion FOR JSON PATH")
                .Param("idAvion", idAvion)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los avion");
            await _command.Sql("SELECT a.IdAvion, a.IdTipoAvion,a.Descripcion,t.Descripcion as DescripcionTipoAvion FROM Avion a INNER JOIN TipoAvion t ON a.IdTipoAvion = t.IdTipoAvion FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarAvion([FromBody] Avion avion)
        {
            await _command.Sql("INSERT INTO Avion(IdTipoAvion,Descripcion) Values(@idTipoAvion,@descripcion)")
                .Param("idTipoAvion", avion.IdTipoAvion)
                .Param("descripcion", avion.Descripcion)
                .OnError(x => _logger.LogError(x, "Error Insertando Avion"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarAvion([FromBody] Avion avion)
        {
            await _command.Sql("UPDATE Avion SET Descripcion =@descripcion," +
                               "IdTipoAvion=@idTipoAvion WHERE IdAvion=@idAvion")
                .Param("idTipoAvion", avion.IdTipoAvion)
                .Param("descripcion", avion.Descripcion)
                .Param("idAvion", avion.IdAvion)
                .OnError(x => _logger.LogError(x, "Error Actualizando Avion"))
                .Exec();
        }
    }
}
