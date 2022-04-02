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
    public class RolController : ControllerBase
    {

        private readonly ILogger<RolController> _logger;
        private readonly ICommand _command;
        public RolController(ILogger<RolController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idRol}")]
        public async Task Eliminar(int idRol)
        {
            _logger.LogInformation("Elimiando un rol");
            await _command.Sql("DELETE FROM Rol WHERE IdRol =@idRol").
                Param("idRol", idRol)
                .OnError(x => _logger.LogError(x, "Error Eliminando Rol"))
                .Exec();
        }
        [HttpGet("{idRol}")]
        public async Task Obtener(int idRol)
        {
            _logger.LogInformation("Obteniendo un rol");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT * FROM Rol WHERE IdRol=@idRol FOR JSON PATH")
                .Param("idRol", idRol)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los rol");
            await _command.Sql("SELECT * FROM Rol FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarRol([FromBody] Rol rol)
        {
            await _command.Sql("INSERT INTO Rol(Nombre) Values(@rol)")
                .Param("rol", rol.Nombre)
                .OnError(x => _logger.LogError(x, "Error Insertando Rol"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarRol([FromBody] Rol rol)
        {
            await _command.Sql("UPDATE Rol SET Nombre =@rol WHERE IdRol=@idRol")
                .Param("rol", rol.Nombre)
                .Param("idRol", rol.IdRol)
                .OnError(x => _logger.LogError(x, "Error Actualizando Rol"))
                .Exec();
        }
    }
}
