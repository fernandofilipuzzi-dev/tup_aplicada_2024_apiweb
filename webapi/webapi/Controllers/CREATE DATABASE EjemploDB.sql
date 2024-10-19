CREATE DATABASE EjemploDB


GO




USE EjemploDB


CREATE TABLE Personas
(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Nombre NVARCHAR(52) NOT NULL,
  Fecha_Nacimiento DATE NOT NULL
)


GO


USE EjemploDB


--Iniciando
INSERT INTO Personas (Nombre, Fecha_Nacimiento)
VALUES
('Luisa', '5/23/2001'),
('Norberto', '1/26/2000'),
('Graciela', '12/1/1998')
