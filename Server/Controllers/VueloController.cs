﻿using AirTiquiciaAPP.Shared;
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
    public class VueloController : ControllerBase
    {

        private readonly ILogger<VueloController> _logger;
        private readonly ICommand _command;
        public VueloController(ILogger<VueloController> logger, ICommand command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpDelete("{idVuelo}")]
        public async Task Eliminar(int idVuelo)
        {
            _logger.LogInformation("Elimiando un avion");
            await _command.Sql("DELETE FROM Vuelo WHERE IdVuelo =@idVuelo").
                Param("idVuelo", idVuelo)
                .OnError(x => _logger.LogError(x, "Error Eliminando Vuelo"))
                .Exec();
        }
        [HttpGet("{idVuelo}")]//IdPersonaTripulacion me falta esta union no se como va.
        public async Task Obtener(int idVuelo)
        {
            _logger.LogInformation("Obteniendo un avion");
            Response.ContentType = "application/json";
            await _command.Sql("SELECT " +
                                      "v.IdVuelo," +
                                      "v.IdTipoVuelo," +
                                      "v.IdAvion," +
                                      "v.IdDestino," +
                                      "v.IdDestinoLlegada," +
                                      "v.IdPersonaTripulacion," +
                                      "v.NumeroVuelo," +
                                      "v.FechaSalida, " +
                                      "v.FechaLLegada, " +
                                      "v.HoraSalida, " +
                                      "v.MinutosSalida, " +
                                      "v.DuracionHoraVuelo, " +
                                      "v.DuracionMinutosVuelo, " +
                                      "v.HoraLLegada, " +
                                      "v.MinutosLLegada," +
                                      "tv.Descripcion AS TipoVueloDescripcion," +
                                      "av.Descripcion AS AvionDescripcion," +
                                      "de.Nombre AS DestinoDescripcion," +
                                      "de.Nombre AS DestinoLlegada" +
                " FROM Vuelo v INNER JOIN TipoVuelo tv ON v.IdTipoVuelo = tv.IdTipoVuelo" +
                " INNER JOIN Avion av ON v.IdVuelo = av.IdVuelo" +
                " INNER JOIN Destino de ON v.IdDestino = de.IdDestino" +
                "INNER JOIN Destino des ON v.IdDestinoLlegada = de.IdDestino" +
                " WHERE IdVuelo=@idVuelo FOR JSON PATH")
                .Param("idVuelo", idVuelo)
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpGet()]
        public async Task ObtenerTodos()
        {
            Response.ContentType = "application/json";
            _logger.LogInformation("Obteniendo los avion");
            await _command.Sql("SELECT " +
                                       "IdVuelo," +
                                      "IdTipoVuelo, " +
                                      "IdAvion," +
                                      "IdDestino, " +
                                      "IdDestinoLlegada, " +
                                      "IdPersonaTripulacion, " +
                                      "NumeroVuelo, " +
                                      "FechaSalida, " +
                                      "FechaLLegada, " +
                                      "HoraSalida, " +
                                      "MinutosSalida, " +
                                      "DuracionHoraVuelo, " +
                                      "DuracionMinutosVuelo, " +
                                      "HoraLLegada, " +
                                      "MinutosLLegada" +
                " FROM Vuelo FOR JSON PATH")
                .Stream(Response.Body, defaultOutput: "[]");
        }

        [HttpPost]
        public async Task<IActionResult> InsertarVuelo([FromBody] Vuelo avion)
        {
            /*
            await _command.Sql("INSERT INTO Vuelo(" +
                                      "IdTipoVuelo, " +
                                      "IdAvion," +
                                      "IdDestino, " +
                                      "IdDestinoLlegada, " +
                                      "IdPersonaTripulacion, " +
                                      "NumeroVuelo, " +
                                      "FechaSalida, " +
                                      "FechaLLegada, " +
                                      "HoraSalida, " +
                                      "MinutosSalida, " +
                                      "DuracionHoraVuelo, " +
                                      "DuracionMinutosVuelo, " +
                                      "HoraLLegada, " +
                                      "MinutosLLegada" +
                ") Values(" +
                                      "@idTipoVuelo, " +
                                      "@idavion," +
                                      "@iddestino, " +
                                      "@iddestinoLlegada, " +
                                      "@idpersonaTripulacion, " +
                                      "@numeroVuelo, " +
                                      "@fechaSalida, " +
                                      "@fechaLLegada, " +
                                      "@horaSalida, " +
                                      "@minutosSalida, " +
                                      "@duracionHoraVuelo, " +
                                      "@duracionMinutosVuelo, " +
                                      "@horaLLegada, " +
                                      "@minutosLLegada" +
                ")")
                .Param("idTipoVuelo", avion.IdTipoVuelo)
                .Param("idavion", avion.IdAvion)
                .Param("iddestino", avion.IdDestino)
                .Param("iddestinoLlegada", avion.IdDestinoLlegada)
                .Param("idpersonaTripulacion", avion.IdPersonaTripulacion)
                .Param("numeroVuelo", avion.NumeroVuelo)
                .Param("fechaSalida", avion.FechaSalida)
                .Param("fechaLlegada", avion.FechaLlegada)
                .Param("horaSalida", avion.HoraSalida)
                .Param("minutosSalida", avion.MinutosSalida)
                .Param("duracionHoraVuelo", avion.DuracionHoraVuelo)
                .Param("duracionMinutosVuelo", avion.DuracionMinutosVuelo)
                .Param("horaLlegada", avion.HoraLlegada)
                .Param("minutosLlegada", avion.MinutosLlegada)
                .OnError(x => _logger.LogError(x, "Error Insertando Vuelo"))
                .Exec();
            */
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarVuelo([FromBody] Vuelo avion)
        {
            /*
            await _command.Sql("UPDATE Vuelo SET "+
                                 "IdTipoVuelo = @idTipoVuelo," +
                                      "IdAvion = @idavion," +
                                      "IdDestino=@iddestino," +
                                      "IdDestinoLlegada = @iddestinoLlegada," +
                                      "IdPersonaTripulacion =@idpersonaTripulacion," +
                                      "NumeroVuelo = @numeroVuelo," +
                                      "FechaSalida =@fechaSalida," +
                                      "FechaLLegada = @fechaLlegada," +
                                      "HoraSalida = @horaSalida," +
                                      "MinutosSalida = @horaSalida," +
                                      "DuracionHoraVuelo = @duracionHoraVuelo," +
                                      "DuracionMinutosVuelo = @duracionMinutosVuelo," +
                                      "HoraLLegada =@horaLlegada," +
                                      "MinutosLLegada = minutosLlegada" +
                               "WHERE IdVuelo=@idVuelo")
                 .Param("idTipoVuelo", avion.IdTipoVuelo)
                .Param("idavion", avion.IdAvion)
                .Param("iddestino", avion.IdDestino)
                .Param("iddestinoLlegada", avion.IdDestinoLlegada)
                .Param("idpersonaTripulacion", avion.IdPersonaTripulacion)
                .Param("numeroVuelo", avion.NumeroVuelo)
                .Param("fechaSalida", avion.FechaSalida)
                .Param("fechaLlegada", avion.FechaLlegada)
                .Param("horaSalida", avion.HoraSalida)
                .Param("minutosSalida", avion.MinutosSalida)
                .Param("duracionHoraVuelo", avion.DuracionHoraVuelo)
                .Param("duracionMinutosVuelo", avion.DuracionMinutosVuelo)
                .Param("horaLlegada", avion.HoraLlegada)
                .Param("minutosLlegada", avion.MinutosLlegada)
                .Param("idVuelo", avion.IdVuelo)
                .OnError(x => _logger.LogError(x, "Error Actualizando Vuelo"))
                .Exec();
            */

            return Ok();
        }
 
    }
}
