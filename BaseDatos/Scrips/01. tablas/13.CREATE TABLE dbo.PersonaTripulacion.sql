USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonaTripulacion]') AND type in (N'U'))
DROP TABLE [dbo].[PersonaTripulacion]
GO
/*
Crea tabla de PersonaTripulacion 

*/
CREATE TABLE dbo.PersonaTripulacion
(
IdPersonaTripulacion  INT NOT NULL IDENTITY(1,1),
IdPersona INT NOT NULL,
IdTripulacion INT NOT NULL,
)
ALTER TABLE dbo.PersonaTripulacion ADD CONSTRAINT [PK_PersonaTripulacion] PRIMARY KEY CLUSTERED
(
   IdPersonaTripulacion ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PersonaTripulacion]  WITH CHECK ADD  CONSTRAINT [FK_PersonaTripulacion_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])

GO

ALTER TABLE [dbo].[PersonaTripulacion]  WITH CHECK ADD  CONSTRAINT [FK_PersonaTripulacion_PesoEquipaje_IdPesoEquipaje] FOREIGN KEY([IdTripulacion])
REFERENCES [dbo].[Tripulacion] ([IdTripulacion])