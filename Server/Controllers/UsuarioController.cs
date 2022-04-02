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
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly ICommand _command;
        public UsuarioController(ILogger<UsuarioController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idUsuario}")]
        public async Task Eliminar(int idUsuario)
        {
            _logger.LogInformation("Elimiando usuario");
            await _command.Sql("DELETE FROM Usuario WHERE IdUsuario =@idUsuario").
                Param("idUsuario", idUsuario)
                .OnError(x => _logger.LogError(x, "Error Eliminando Usuario"))
                .Exec();
        }
        [HttpGet("{idUsuario}")]
        public async Task Obtener(int idUsuario)
        {
            _logger.LogInformation("Obteniendo un(a) usuario");
            Response.ContentType = "application/json";
            await _command.Sql(" SELECT u.IdUsuario , u.IdPersona, u.Usuario as UsuarioSistema ,u.Contrasena,CONCAT(p.Nombre, ' ', p.Apellidos) as NombrePersona, r.Nombre as DescripcionRol, u.IdRol" +
                " FROM Usuario u INNER JOIN Persona p ON u.IdPersona = p.IdPersona INNER JOIN Rol r ON u.IdRol = r.IdRol WHERE u.IdUsuario =@idUsuario  FOR JSON PATH")
                .Param("idUsuario", idUsuario)
                .Stream(Response.Body, defaultOutput: "[]");
           


 


        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  usuario");
            await _command.Sql(" SELECT u.IdUsuario , u.IdPersona, u.Usuario as UsuarioSistema ,u.Contrasena,CONCAT(p.Nombre, ' ', p.Apellidos) as NombrePersona, r.Nombre as DescripcionRol" +
                " FROM Usuario u INNER JOIN Persona p ON u.IdPersona = p.IdPersona INNER JOIN Rol r ON u.IdRol = r.IdRol FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarUsuario([FromBody] Usuario usuario)
        {
            await _command.Sql("INSERT INTO Usuario( IdPersona , Usuario ,Contrasena , IdRol) Values(@idPersona, @usuario,@contrasena, @idRol)")
                .Param("idPersona", usuario.IdPersona)
                .Param("usuario", usuario.UsuarioSistema)
                .Param("contrasena", usuario.Contrasena)
                .Param("idRol", usuario.IdRol)
                .OnError(x => _logger.LogError(x, "Error Insertando Usuario"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarUsuario([FromBody] Usuario usuario)
        {
            await _command.Sql("UPDATE Usuario SET " +
                                        "IdPersona = @idPersona," +
                                        "Usuario = @usuario," +
                                        "Contrasena = @contrasena," +
                                        "IdRol = @idRol" +
                                " WHERE IdUsuario = @idUsuario")
                  .Param("idPersona", usuario.IdPersona)
                .Param("usuario", usuario.UsuarioSistema)
                .Param("contrasena", usuario.Contrasena)
                .Param("idRol", usuario.IdRol)
                .Param("idUsuario", usuario.IdUsuario)
                .OnError(x => _logger.LogError(x, "Error Actualizando Usuario"))
                .Exec();
        }
    }
}