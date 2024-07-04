create database DBDiagnostico

use DBDiagnostico

create table Genero(
IdGenero int primary key identity,
Nombre varchar(50),
FechaCreacion datetime default getdate()
)

create table Persona(
IdPersona int primary key identity,
Nombre varchar(100),
Apellido varchar (100),
FechaNacimiento datetime,
FechaCreacion datetime default getdate(),
GeneroId int references Genero(IdGenero)
)

insert into Genero(Nombre) values
('Masculino'),
('Femenino')


INSERT INTO Persona (Nombre, Apellido, FechaNacimiento, GeneroId) 
VALUES ('Luis', 'Torres', CONVERT(datetime, '1999-12-18 00:00:00', 120), 1);

INSERT INTO Persona (Nombre, Apellido, FechaNacimiento, GeneroId) 
VALUES ('Luisa', 'Martínez', CONVERT(datetime, '1999-12-18 00:00:00', 120), 2);

INSERT INTO Persona (Nombre, Apellido, FechaNacimiento, GeneroId) 
VALUES ('Antonio', 'Salazar', CONVERT(datetime, '1978-12-15 00:00:00', 120), 1);

INSERT INTO Persona (Nombre, Apellido, FechaNacimiento, GeneroId) 
VALUES ('Daniela', 'Altamirano', CONVERT(datetime, '1989-04-16 00:00:00', 120), 2);

