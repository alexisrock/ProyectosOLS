create database  proyectosCliente


create table Cliente(
id int primary key identity,
Cedula nvarchar(250),
nombres nvarchar(250),
apellidos nvarchar(250),
direcion  nvarchar(250),
telefono nvarchar(250)
)

create table EstadoProyecto(
id int primary key identity,
descripcion nvarchar(250)
)


create table LenguajesProgramacion(
id int primary key identity,
descripcion nvarchar(250)
)

create table Nivellenguaje(
id int primary key identity,
descripcion nvarchar(250)
)
create table Proyecto(
id int primary key identity,
nombre nvarchar(250),
idcliente int,
idestado int,
fechainicio date,
fechafin date,
precio money,
cantidadhoras decimal,
foreign key (idcliente)
references Cliente(id),
foreign key (idestado)
references EstadoProyecto(id),
)

create table DetalleProyecoLenguaje(
id int primary key identity,
idproyecto int,
idlenguaje int,
idnivel int,
foreign key (idproyecto)
references Proyecto(id),
foreign key (idlenguaje)
references LenguajesProgramacion(id),
foreign key (idnivel)
references Nivellenguaje(id)
)


insert [dbo].[Nivellenguaje] values('Alto'),('Medio'), ('Bajo')
insert [dbo].[EstadoProyecto] values ('En Negociacion'),('En Proceso'), ('Terminado'), ('Anulado')
insert [dbo].[LenguajesProgramacion] values ('C#'),('Php'),('Python'),('Java'),('Javascript'),('Vb'),('Delphi'),('Go'),('Ruby')


create PROCEDURE sp_proyectosClientes
as
begin
Select 
Concat(c.nombres,' ',c.apellidos) as NombreCliente,
 c.telefono, 
 p.nombre,
 p.fechainicio, 
 p.fechafin,
 p.precio, 
 p.cantidadhoras,
 e.descripcion
 from Cliente as c
 inner join Proyecto as p on p.idcliente = c.id
 inner join EstadoProyecto as e on e.id = p.idestado
end 

exec sp_proyectosClientes

insert Cliente values('1010180198', 'Alexis', 'Bueno Castro','Calle 52 no 13 - 60', '3004578963'),
('35334501', 'Bertha', 'Castro','Cra 12 no 78 -85', '3008962200'),('39560971', 'Clara ines', 'villalba','cra 89 no 78 - 96', '3048967485'),
('1078965200','Bayron','Ortiz','diagonal 89 - no 52 - 96','3007412530'),('79852963','jaime','celis','tra 3 no  45 - 96','3002247895'),
('1078789999','Ingrid','Bueno','calle 78 - 25- 19','3002201036'),('789996444','Fabian','Rivera','Calle 78 no 19 - 59','3012567896'),
('100787878','jenny','gonzales','cra 22 no 44 -96','3007892522'),('1000022474','martha','suarez','diagonal 10 no 52 - 19','3025637851'),
('899245454','sergio','ortiz','cra 22 no 30 - 20','3507874495')


insert Proyecto values ('',1,1,'2021/01/03','2021/10/16', 15000000, 150)

insert Proyecto values ('Cmd nuevo proyecto',1,2,'2021/01/08','2021/10/16', 25000000, 350),
('escuela ERP',2,1,'2021/02/03','2021/11/19', 25000000, 350),('escuela ERP',2,2,'2021/01/03','2021/11/15', 25000000, 350),
('ofina ERP',3,1,'2021/02/03','2021/11/26', 25000000, 350),('banco ERP',3,2,'2021/02/16','2021/11/26', 25000000, 350),
('portafolio',4,1,'2021/02/03','2021/11/18', 25000000, 350),('inventario ERP',4,2,'2021/01/04','2021/11/09', 25000000, 350),
('jardin ',5,1,'2021/03/03','2021/11/16', 25000000, 350),('cmd remates',5,2,'2021/04/03','2021/11/05', 25000000, 350),
('pagos bancario',6,1,'2021/01/03','2021/11/30', 25000000, 350),('hamburgesas',6,2,'2021/01/03','2021/11/14', 25000000, 350),
('giros',7,1,'2021/02/03','2021/11/16', 25000000, 350),('correspondencia',7,2,'2021/02/23','2021/11/28', 25000000, 350),
('cloud ERP',8,1,'2021/01/03','2021/11/24', 25000000, 350),('payu',8,2,'2021/02/15','2021/11/02', 25000000, 350),
('RTS',9,1,'2021/02/08','2021/11/03', 25000000, 350),('tu coche',9,2,'2021/02/16','2021/11/06', 25000000, 350),
('U.B.M',10,1,'2021/02/10','2021/11/12', 25000000, 350),('concecionario',10,2,'2021/02/12','2021/11/19', 25000000, 350)

insert [dbo].[DetalleProyecoLenguaje] values(1,1,2),
(1,4,2),(2,1,2),(2,4,2),(3,1,2),(3,4,2),(5,1,2),(5,4,2),
(6,1,2),(6,4,2),(7,1,2),(7,4,2),(8,1,2),(8,4,2),(9,1,2),
(9,4,2),(10,1,2),(10,4,2),(11,1,2),(11,4,2),(12,1,2),(12,4,2),
(13,1,2),(13,4,2),(14,1,2),(14,4,2),(15,1,2),(15,4,2),(16,1,2),
(16,4,2),(17,1,2),(17,4,2),(18,1,2),(18,4,2),(19,1,2),(19,4,2),
(20,1,2),(20,4,2)


insert [dbo].[DetalleProyecoLenguaje] values(4,1,2),
(4,4,2)







