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
    public class PersonaController : ControllerBase
    {

        private readonly ILogger<PersonaController> _logger;
        private readonly ICommand _command;
        public PersonaController(ILogger<PersonaController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idPersona}")]
        public async Task Eliminar(int idPersona)
        {
            _logger.LogInformation("Elimiando persona");
            await _command.Sql("DELETE FROM Persona WHERE IdPersona =@idPersona").
                Param("idPersona", idPersona)
                .OnError(x => _logger.LogError(x, "Error Eliminando Persona"))
                .Exec();
        }
        [HttpGet("{idPersona}")]
        public async Task Obtener(int idPersona)
        {
            _logger.LogInformation("Obteniendo un(a) persona");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdPersona , Nombre , Apellidos,Telefono, Direccion,Correo FROM Persona WHERE IdPersona=@idPersona FOR JSON PATH")
                .Param("idPersona", idPersona)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  persona");
            await _command.Sql("SELECT IdPersona , Nombre , Apellidos,Telefono, Direccion,Correo FROM Persona FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarPersona([FromBody] Persona persona)
        {
            await _command.Sql("INSERT INTO Persona( Nombre , Apellidos,Telefono, Direccion,Correo) Values(@nombre, @apellidos,@telefono, @direccion,@correo)")
                .Param("nombre", persona.Nombre)
                .Param("apellidos", persona.Apellidos)
                .Param("telefono", persona.Telefono)
                .Param("direccion", persona.Direccion)
                .Param("correo",persona.Correo)
                .OnError(x => _logger.LogError(x, "Error Insertando Persona"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarPersona([FromBody] Persona persona)
        {
            await _command.Sql("UPDATE Persona SET" +
                                        " Nombre = @nombre," +
                                        " Apellidos = @apellidos," +
                                        " Telefono = @telefono," +
                                        " Direccion= @direccion," +
                                        " Correo = @correo"+
                                " WHERE IdPersona = @idPersona")
                .Param("nombre", persona.Nombre)
                .Param("apellidos", persona.Apellidos)
                .Param("telefono", persona.Telefono)
                .Param("direccion", persona.Direccion)
                .Param("correo", persona.Correo)
                .Param("idPersona", persona.IdPersona)
                .OnError(x => _logger.LogError(x, "Error Actualizando Persona"))
                .Exec();
        }
    }
}