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
    public class EquipajePasajeroController : ControllerBase
    {

        private readonly ILogger<PasajeroController> _logger;
        private readonly ICommand _command;
        public EquipajePasajeroController(ILogger<PasajeroController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idEquipajePasajero}")]
        public async Task Eliminar(int idEquipajePasajero)
        {
            _logger.LogInformation("Elimiando equipajePasajero");
            await _command.Sql("DELETE FROM EquipajePasajero WHERE IdEquipajePasajero =@idEquipajePasajero").
                Param("idEquipajePasajero", idEquipajePasajero)
                .OnError(x => _logger.LogError(x, "Error Eliminando EquipajePasajero"))
                .Exec();
        }
        [HttpGet("{idEquipajePasajero}")]
        public async Task Obtener(int idEquipajePasajero)
        {
            _logger.LogInformation("Obteniendo un(a) equipajePasajero");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdEquipajePasajero , IdPersona, IdPesoEquipaje   FROM EquipajePasajero WHERE IdEquipajePasajero=@idEquipajePasajero FOR JSON PATH")
                .Param("idEquipajePasajero", idEquipajePasajero)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  equipajePasajero");
            await _command.Sql("SELECT IdPasajero , IdPersona,Tipo FROM EquipajePasajero FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarPasajero([FromBody]EquipajePasajero equipajePasajero)
        {
            await _command.Sql("INSERT INTO EquipajePasajero(IdPersona, IdPesoEquipaje) Values(@idpersona, @idPesoEquipaje)")
                .Param("idpersona", equipajePasajero.IdPersona)
                .Param("idPesoEquipaje", equipajePasajero.IdPesoEquipaje)
                .OnError(x => _logger.LogError(x, "Error Insertando EquipajePasajero"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarPasajero([FromBody]EquipajePasajero equipajePasajero)
        {
            await _command.Sql("UPDATE EquipajePasajero SET " +
                                        "IdPersona =@idpersona," +
                                        "IdPesoEquipaje=@idPesoEquipaje" +
                                "WHERE IdPasajero=@idPasajero")
                .Param("idpersona", equipajePasajero.IdPersona)
                .Param("idPesoEquipaje", equipajePasajero.IdPesoEquipaje)
                .Param("idEquipajePasajero", equipajePasajero.IdEquipajePasajero)
                .OnError(x => _logger.LogError(x, "Error Actualizando EquipajePasajero"))
                .Exec();
        }
    }
}