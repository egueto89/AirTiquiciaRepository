USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoPersona]') AND type in (N'U'))
DROP TABLE [dbo].[TipoPersona]
GO
/*
Crea tabla de TipoPersona 

*/
CREATE TABLE dbo.TipoPersona
(
IdTipoPersona  INT NOT NULL IDENTITY(1,1),
IdPersona INT NOT NULL,
TipoPer TINYINT  NOT NULL --Empleado, Tripulante
)
ALTER TABLE dbo.TipoPersona ADD CONSTRAINT [PK_TipoPersona] PRIMARY KEY CLUSTERED
(
   IdTipoPersona ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TipoPersona]  WITH CHECK ADD  CONSTRAINT [FK_TipoPersona_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
