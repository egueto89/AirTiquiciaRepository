USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/*
Crea tabla de Usuario 

*/
CREATE TABLE dbo.Usuario
(
IdUsuario  	INT NOT NULL IDENTITY(1,1),
IdPersona 	INT NOT NULL,
Usuario 	VARCHAR(100) NOT NULL,
Contrasena 	VARCHAR(100) NOT NULL,
IdRol 		INT NOT NULL
)
ALTER TABLE dbo.Usuario ADD CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED
(
   IdUsuario ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])

GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])