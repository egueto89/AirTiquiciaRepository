USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquipajePasajero]') AND type in (N'U'))
DROP TABLE [dbo].[EquipajePasajero]
GO
/*
Crea tabla de EquipajePasajero 

*/
CREATE TABLE dbo.EquipajePasajero
(
IdEquipajePasajero  INT NOT NULL IDENTITY(1,1),
IdPersona INT NOT NULL,
IdPesoEquipaje INT NOT NULL,
)
ALTER TABLE dbo.EquipajePasajero ADD CONSTRAINT [PK_EquipajePasajero] PRIMARY KEY CLUSTERED
(
   IdEquipajePasajero ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EquipajePasajero]  WITH CHECK ADD  CONSTRAINT [FK_EquipajePasajero_Persona_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])

GO

ALTER TABLE [dbo].[EquipajePasajero]  WITH CHECK ADD  CONSTRAINT [FK_EquipajePasajero_PesoEquipaje_IdPesoEquipaje] FOREIGN KEY([IdPesoEquipaje])
REFERENCES [dbo].[PesoEquipaje] ([IdPesoEquipaje])