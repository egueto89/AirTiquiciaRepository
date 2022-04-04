USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pasajero]') AND type in (N'U'))
DROP TABLE [dbo].[Pasajero]
GO
/*
Crea tabla de Pasajero 

*/
CREATE TABLE dbo.Pasajero
(
IdPasajero  INT NOT NULL IDENTITY(1,1),
IdPersona INT NOT NULL,
CantidadEquipaje TINYINT NOT NULL
)
ALTER TABLE dbo.Pasajero ADD CONSTRAINT [PK_Pasajero] PRIMARY KEY CLUSTERED
(
   IdPasajero ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_Pasajero_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
