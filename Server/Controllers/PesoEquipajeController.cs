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
    public class PesoEquipajeController : ControllerBase
    {

        private readonly ILogger<PesoEquipajeController> _logger;
        private readonly ICommand _command;
        public PesoEquipajeController(ILogger<PesoEquipajeController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idPesoEquipaje}")]
        public async Task Eliminar(int idPesoEquipaje)
        {
            _logger.LogInformation("Elimiando pesoEquipaje");
            await _command.Sql("DELETE FROM PesoEquipaje WHERE IdPesoEquipaje =@idPesoEquipaje").
                Param("idPesoEquipaje", idPesoEquipaje)
                .OnError(x => _logger.LogError(x, "Error Eliminando PesoEquipaje"))
                .Exec();
        }
        [HttpGet("{idPesoEquipaje}")]
        public async Task Obtener(int idPesoEquipaje)
        {
            _logger.LogInformation("Obteniendo un(a) pesoEquipaje");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT IdPesoEquipaje , Peso ,Precio FROM PesoEquipaje WHERE IdPesoEquipaje=@idPesoEquipaje FOR JSON PATH")
                .Param("idPesoEquipaje", idPesoEquipaje)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo  pesoEquipaje");
            await _command.Sql("SELECT IdPesoEquipaje , Peso ,Precio FROM PesoEquipaje FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task InsertarPesoEquipaje([FromBody] PesoEquipaje pesoEquipaje)
        {
            await _command.Sql("INSERT INTO PesoEquipaje( Peso ,Precio) Values(@peso, @precio)")
                .Param("peso", pesoEquipaje.Peso)
                .Param("precio", pesoEquipaje.Precio)
                .OnError(x => _logger.LogError(x, "Error Insertando PesoEquipaje"))
                .Exec();
        }

        [HttpPut]
        public async Task ActualizarPesoEquipaje([FromBody] PesoEquipaje pesoEquipaje)
        {
            await _command.Sql("UPDATE PesoEquipaje SET " +
                                        "Peso =@peso," +
                                        "Precio=@precio"+
                                " WHERE IdPesoEquipaje=@idPesoEquipaje")
               .Param("peso", pesoEquipaje.Peso)
                .Param("precio", pesoEquipaje.Precio)
                .Param("idPesoEquipaje", pesoEquipaje.IdPesoEquipaje)
                .OnError(x => _logger.LogError(x, "Error Actualizando PesoEquipaje"))
                .Exec();
        }
    }
}