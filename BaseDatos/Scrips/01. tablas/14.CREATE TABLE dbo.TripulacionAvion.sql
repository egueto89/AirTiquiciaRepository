USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TripulacionAvion]') AND type in (N'U'))
DROP TABLE [dbo].[TripulacionAvion]
GO
/*
Crea tabla de TripulacionAvion 

*/
CREATE TABLE dbo.TripulacionAvion
(
IdTripulacionAvion  INT NOT NULL IDENTITY(1,1),
IdPersona INT NOT NULL,
IdPersonaTripulacion INT NOT NULL,
)
ALTER TABLE dbo.TripulacionAvion ADD CONSTRAINT [PK_TripulacionAvion] PRIMARY KEY CLUSTERED
(
   IdTripulacionAvion ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TripulacionAvion]  WITH CHECK ADD  CONSTRAINT [FK_TripulacionAvion_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])

GO

ALTER TABLE [dbo].[TripulacionAvion]  WITH CHECK ADD  CONSTRAINT [FK_TripuAvion_PerTri_IdPersonaTripulacion] FOREIGN KEY([IdPersonaTripulacion])
REFERENCES [dbo].[PersonaTripulacion] ([IdPersonaTripulacion])