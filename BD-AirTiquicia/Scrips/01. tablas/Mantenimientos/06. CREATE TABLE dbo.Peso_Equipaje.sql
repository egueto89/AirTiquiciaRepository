USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PesoEquipaje]') AND type in (N'U'))
DROP TABLE [dbo].[PesoEquipaje]
GO
/*
Crea tabla de Peso_Equipaje 

*/
CREATE TABLE dbo.PesoEquipaje
(
IdPesoEquipaje  INT NOT NULL IDENTITY(1,1),
Peso TINYINT NOT NULL,
Precio DECIMAL NOT NULL
)
ALTER TABLE dbo.PesoEquipaje ADD CONSTRAINT [PK_Peso_Equipaje] PRIMARY KEY CLUSTERED
(
   IdPesoEquipaje ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO