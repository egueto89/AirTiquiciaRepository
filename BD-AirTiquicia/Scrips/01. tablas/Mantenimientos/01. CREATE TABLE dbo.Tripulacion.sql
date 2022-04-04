USE AirTiquicia
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tripulacion]') AND type in (N'U'))
DROP TABLE [dbo].[Tripulacion]
GO
/*
Crea tabla de tripulacion 

*/
CREATE TABLE dbo.Tripulacion
(
IdTripulacion INT IDENTITY(1,1) NOT NULL,
Descripcion VARCHAR(100) NOT NULL,  
)
ALTER TABLE dbo.Tripulacion ADD CONSTRAINT [PK_Tripulacion] PRIMARY KEY CLUSTERED
(
   IdTripulacion ASC 
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
