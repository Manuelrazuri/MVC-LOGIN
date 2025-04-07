create database Lima_Autos;
use Lima_Autos;

create table auto (
	codigo integer not null auto_increment comment 'Almacena el código del registro en la tabla',
	marca varchar(50) not null comment 'Almacena la marca del auto',
	modelo varchar(50) comment 'Almacena el modelo del auto',
	cantidadVentanas integer not null comment 'Almacena la cantidad de ventasa con las que cuenta un auto',
	cantidadLlantas integer not null comment 'Almacena la cantidad de llantas con las que cuenta un auto',
	primary key (codigo)
);

create table Usuario(
IdUsuario integer not null auto_increment,
Correo varchar(100),
Clave Varchar (200),
primary key (IdUsuario)
);
select *
from Usuario;

select *
from auto;

insert into auto (marca, modelo, cantidadVentanas, 	cantidadLlantas)
values ('FERRARI', 'G5', 3, 4);

insert into auto (marca, modelo, cantidadVentanas, 	cantidadLlantas)
values ('HONDA', 'CIVIC', 4, 4);

insert into auto (marca, modelo, cantidadVentanas, 	cantidadLlantas)
values ('HYUNDAI', 'i30 CW', 4, 4);

Select codigo, marca, modelo, cantidadVentanas, cantidadLlantas From auto where codigo Like 3;
Select codigo, marca, modelo, cantidadVentanas, cantidadLlantas From auto where marca;