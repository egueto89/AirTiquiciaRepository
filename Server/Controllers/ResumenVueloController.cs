using AirTiquiciaAPP.Server.Services;
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
    public class ResumenVueloController : ControllerBase
    {

        private readonly ILogger<ResumenVueloController> _logger;
        private readonly ICommand _command;
        private readonly IEmailSenderService _emailSenderService;
        public ResumenVueloController(ILogger<ResumenVueloController> logger, ICommand command, IEmailSenderService emailSenderService)
        {
            _logger = logger;
            _command = command;
            _emailSenderService = emailSenderService;
        }

        
        [HttpGet("{identificaciones}/{numvuelo}")]
        public async Task Obtener(string identificaciones, string numvuelo)
        {
            _logger.LogInformation("Obteniendo resumen de vuelo");
            Response.ContentType = "application/json";
            await _command.Sql(@" 
                                SELECT  concat(v.HoraSalida,':',RIGHT('00' + Ltrim(Rtrim(v.MinutosSalida)),2)) As HoraSalida, 
                                CONCAT(v.HoraLLegada,':',RIGHT('00' + Ltrim(Rtrim(v.MinutosLLegada)),2) ) AS HoraLlegada,
                                de.Nombre as DestinoSalida, ds.Nombre as DestinoLlegada,
                                v.Precio,
                                ps.CantidadEquipaje,
                                pq.Precio as PrecioEquipaje, 
                                v.DuracionHoraVuelo,
                                GETDATE() as FechaCompra, 
                                v.NumeroVuelo,
                                av.Descripcion as Aviondescripcion,
                                av.Aereolina,
                                p.Nombre,
                                p.Apellidos,
                                p.Identificacion,
                                p.Correo,
                                p.Telefono
                                FROM Vuelo v
                                INNER JOIN Avion av on v.IdAvion = av.IdAvion
                                INNER JOIN PasajeroVuelo pv on  v.IdVuelo= pv.IdVuelo
                                INNER JOIN Pasajero ps on pv.IdPasajero = ps.IdPasajero
                                INNER JOIN Destino de on v.IdDestino = de.IdDestino
                                INNER JOIN Destino ds on v.IdDestinoLlegada = ds.IdDestino
                                INNER JOIN EquipajePasajero eq on ps.IdPersona = eq.IdPersona
                                INNER JOIN PesoEquipaje pq on eq.IdPesoEquipaje = pq.IdPesoEquipaje
                                INNER JOIN Persona p  on eq.IdPersona = p.IdPersona
                                WHERE  EXISTS(
                                              SELECT 1 FROM Split_Varchar_FT(@identificaciones,',') exi
                                                where exi.valor = p.Identificacion
                                            )
                                and v.NumeroVuelo = @numvuelo FOR JSON PATH")
                .Param("identificaciones", identificaciones)
                 .Param("numvuelo", numvuelo)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]

        public async Task<int> EnvioCorreo(DatosCorreo entidad)
        {
            int resgistros = 1;
            try
            {
                resgistros = await _emailSenderService.SendEmailAsync(entidad);
                _logger.LogInformation("Ejecución Realizada");

            }
            catch (Exception ex)
            {

                _logger.LogError($"Ocurrió un error en el proceso {ex.Message}");
            }

            return resgistros;
        }

    }

}

