using AirTiquiciaAPP.Shared;
using AirTiquiciaAPP.Shared.DTOs;
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
    public class PasajeroController : ControllerBase
    {

        private readonly ILogger<PasajeroController> _logger;
        private readonly ICommand _command;
        public PasajeroController(ILogger<PasajeroController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idPasajero}")]
        public async Task Eliminar(int idPasajero)
        {
            _logger.LogInformation("Elimiando pasajero");
            await _command.Sql("DELETE FROM Pasajero WHERE IdPasajero =@idPasajero").
                Param("idPasajero", idPasajero)
                .OnError(x => _logger.LogError(x, "Error Eliminando Pasajero"))
                .Exec();
        }
        [HttpGet("{idPasajero}")]
        public async Task Obtener(int idPasajero)
        {
            _logger.LogInformation("Obteniendo un(a) pasajero");
            Response.ContentType = "application/json";
            await _command.Sql(@"SELECT IdPasajero , pe.IdPersona  ,CantidadEquipaje , CONCAT(pe.Nombre,' ',pe.Apellidos) as NombrePersona  
                                FROM Pasajero pa INNER JOIN  Persona pe ON pa.IdPersona = pe.IdPersona 
                                  INNER JOIN TipoPersona tp ON tp.IdPersona = pe.IdPersona and tp.tipoPer =2
                                WHERE IdPasajero=@idPasajero FOR JSON PATH")
                .Param("idPasajero", idPasajero)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  pasajero");
            await _command.Sql(@" SELECT IdPasajero , pe.IdPersona  ,CantidadEquipaje , CONCAT(pe.Nombre,' ',pe.Apellidos) as NombrePersona  
                                 FROM Pasajero pa INNER JOIN  Persona pe ON pa.IdPersona = pe.IdPersona 
                                   INNER JOIN TipoPersona tp ON tp.IdPersona = pe.IdPersona and tp.tipoPer =2   FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarPasajero([FromBody] Pasajero pasajero)
        {
            await _command.Sql("INSERT INTO Pasajero(IdPersona ,CantidadEquipaje) Values(@idpersona, @cantidad)")
                .Param("idpersona", pasajero.IdPersona)
                .Param("cantidad", pasajero.CantidadEquipaje)
                .OnError(x => _logger.LogError(x, "Error Insertando Pasajero"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarPasajero([FromBody] Pasajero pasajero)
        {
            await _command.Sql("UPDATE Pasajero SET " +
                                        "IdPersona =@idpersona," +
                                        "CantidadEquipaje=@cantidad" +
                                " WHERE IdPasajero=@idPasajero")
                .Param("idpersona", pasajero.IdPersona)
                .Param("cantidad", pasajero.CantidadEquipaje)
                .Param("idPasajero", pasajero.IdPasajero)
                .OnError(x => _logger.LogError(x, "Error Actualizando Pasajero"))
                .Exec();
        }

        [HttpGet("persona")]
        public async Task ObtieneEmpleados()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  persona");
            await _command.Sql(@"SELECT pe.IdPersona , pe.Nombre , pe.Apellidos,pe.Telefono, pe.Direccion,pe.Correo FROM Persona pe 
                                INNER JOIN TipoPersona tp ON pe.IdPersona = tp.IdPersona
                                WHERE TP.TipoPer=2 FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }


        [HttpPost("InsertaPasajeroVuelo")]
        public async Task InsertaPasajeroVuelo([FromBody] PasajeroVueloDTO pasajero)
        {
            Exception exception = new Exception();
                await _command.Proc("InsertarDatosVuelo")
                .Param("Nombre", pasajero.Nombre)
                .Param("Apellidos", pasajero.Apellidos)
                .Param("Telefono", pasajero.Telefono)
                .Param("Direccion", pasajero.Direccion)
                .Param("Correo", pasajero.Correo)
                .Param("Identificacion", pasajero.Identificacion)
                .Param("CantidadEquipaje", pasajero.cantidadEquipaje)
                .Param("TipoPasajero", pasajero.TipoPasajero)
                .Param("NumeroVuelo", pasajero.numeroVuelo)
                .Param("IdPesoEquipaje", pasajero.IdPesoEquipaje)
                 
                .OnError(x => {

                    _logger.LogError(x, "Error Insertando Pasajero");
                    exception = x;
                    
                    })
                .Exec();

            

        }
    }
}