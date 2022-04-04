USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vuelo]') AND type in (N'U'))
DROP TABLE [dbo].[Vuelo]
GO
/*
Crea tabla de Vuelo 

*/
CREATE TABLE dbo.Vuelo
(
IdVuelo  INT NOT NULL IDENTITY(1,1),
IdTipoVuelo INT NOT NULL,
 IdAvion INT NOT NULL,
 IdDestino INT NOT NULL,
  IdDestinoLlegada INT NOT NULL,
 IdPersonaTripulacion  INT NOT NULL,
NumeroVuelo VARCHAR(100),
FechaSalida DATETIME NOT NULL,
FechaLLegada DATETIME NOT NULL,
 HoraSalida TINYINT NOT NULL,
 MinutosSalida TINYINT NOT NULL,
DuracionHoraVuelo TINYINT NOT NULL,
DuracionMinutosVuelo TINYINT NOT NULL,
HoraLLegada TINYINT NOT NULL,
MinutosLLegada TINYINT NOT NULL
)
ALTER TABLE dbo.Vuelo ADD CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED
(
   IdVuelo ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_TipoVuelo_IdTipoVuelo] FOREIGN KEY([IdTipoVuelo])
REFERENCES [dbo].[TipoVuelo] ([IdTipoVuelo])

GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Avion_IdAvion] FOREIGN KEY([IdAvion])
REFERENCES [dbo].[Avion] ([IdAvion])

GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Destino_IdDestino] FOREIGN KEY([IdDestino])
REFERENCES [dbo].[Destino] ([IdDestino])
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Destino_IdDestinoLlegada] FOREIGN KEY([IdDestinoLlegada])
REFERENCES [dbo].[Destino] ([IdDestino])

GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_PersoTripu_IdPersonaTripulacion] FOREIGN KEY([IdPersonaTripulacion])
REFERENCES [dbo].[PersonaTripulacion] ([IdPersonaTripulacion])

GO