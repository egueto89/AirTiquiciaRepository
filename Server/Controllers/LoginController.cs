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
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly ICommand _command;
        public LoginController(ILogger<LoginController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpPost()]
        public async Task Obtener([FromBody] LoginApp login)
        {
            _logger.LogInformation("Obteniendo login");
            Response.ContentType = "application/json";
            await _command.Sql(" SELECT u.Usuario  ,null as Contrasena,CONCAT(p.Nombre, ' ', p.Apellidos) as NombrePersona" +
                " FROM Usuario u INNER JOIN Persona p ON u.IdPersona = p.IdPersona WHERE u.Usuario =@usuario  and u.Contrasena=@contra FOR JSON PATH")
                .Param("usuario", login.Usuario)
                .Param("contra", login.Contrasena)
                .Stream(Response.Body, defaultOutput: "[]");
           


 


        }
    }
}