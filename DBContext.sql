Create Database	PracticaWeb	
USE PracticaWeb 

--*********************************************************************

Create Table USUARIO(
	idUsuario int primary key identity(1,1),
	Correo varchar(50),
	Clave varchar(100)
)

--*********************************************************************

INSERT INTO USUARIO (Correo, Clave) values ('correodemo@gmail.com','a57b00c5d624241206dd201c13c27eb50e6b89d03cb5b0a6ee29990626ca81bf')

CREATE PROCEDURE Sp_GetUsuario

@Email varchar(50),
@Password varchar (100)
as

Select * from USUARIO where Correo = @Email and Clave = @Password

--*********************************************************************

Create Table AUTOS(
	idAuto int primary key identity(1,1),
	NoPlaca int,
)
--*********************************************************************

create Table Bitacora_Autos(
	idServicio int primary key identity(1,1),
	idAuto int, 
	FechaEntrada Datetime,
	FechaSalida Datetime,
	isEntrada int,
	isSalida int,
	Total int
)
--*********************************************************************

CREATE PROCEDURE Sp_AddAuto

@NoPlaca varchar (100)
as
if((select  COUNT(*) from AUTOS where NoPlaca = @NoPlaca) = 0)
BEGIN
	INSERT INTO AUTOS (NoPlaca) values(@NoPlaca)
END
ELSE
BEGIN
	SELECT 0 [Valor]
END
--*********************************************************************

CREATE PROCEDURE Sp_BusquedaAutos

as

Select *from AUTOS
--*********************************************************************
CREATE PROCEDURE Sp_IngresoAutos
@idAuto int
as

insert into Bitacora_Autos(idAuto,FechaEntrada,isEntrada) values(@idAuto, GETDATE(), 1)




--SELECT Minutos  = (DATEDIFF(SECOND, FechaE, Fechas) / 60  ) % 60
--FROM (VALUES( '2023-08-08 19:20:19.350', '2023-08-08 19:22:59.350'))x(FechaE, FechaS)


--select *from AUTOS

--if((select  COUNT(*) from AUTOS where NoPlaca = '23434') = 0)
--BEGIN
--	SELECT 1 [Valor]
--END
--ELSE
--BEGIN
--	SELECT 0 [Valor]
--END

declare @no varchar = '1231'
Select *from AUTOS where NoPlaca like '%'+@no+'%'


select A.idAuto, A.NoPlaca from AUTOS A
inner join Bitacora_Autos BA  on BA.idAUto <> A.idAuto 


select A.idAuto, A.NoPlaca from Bitacora_Autos BA
inner join AUTOS A  on BA.idAUto = A.idAuto 


select * from Bitacora_Autos
select * from Autos