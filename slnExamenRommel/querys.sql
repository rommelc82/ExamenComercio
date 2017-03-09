--drop database rommelexamen
use master
go
Create database rommelexamen
go
use rommelexamen
go
create table banco
(
id int identity (1, 1),
nombre nvarchar(100),
direccion nvarchar(100),
fecharegistro datetime,
CONSTRAINT PK_BANCO PRIMARY KEY(id)
);
create table sucursal
(
id int identity (1,1),
idbanco int,
nombre nvarchar(100),
direccion nvarchar(100),
fecharegistro datetime,
CONSTRAINT PK_SUCURSAL PRIMARY KEY(id),
CONSTRAINT FK_SUCURSAL_BANCO FOREIGN KEY(idbanco) REFERENCES banco(id)
);
create table ordenpago
(
id int identity (1,1),
idsucursal int,
monto numeric(6,2),
moneda varchar(5),
estado int,
fecharegistro datetime,
CONSTRAINT PK_ORDENPAGO PRIMARY KEY(id),
CONSTRAINT FK_ORDENPAGO_SUCURSAL FOREIGN KEY(idsucursal) REFERENCES SUCURSAL(id)
);

create table parametro
(
id int,
descripcion varchar(50),
valor varchar(50),
CONSTRAINT PK_PARAMETRO PRIMARY KEY(id)
);
create table detalleparametro
(
id int,
idparametro int ,
descripcion varchar(50),
valor varchar(10),
CONSTRAINT PK_DETALLEPARAMETRO PRIMARY KEY(id),
CONSTRAINT FK_DETALLEPARAMETRO_PARAMETRO FOREIGN KEY(idparametro) REFERENCES PARAMETRO(id)
);
--select * from detalleparametro

insert into parametro (id,descripcion,valor)
values(1,'ESTADO DE LA ORDEN DE PAGO','');
insert into detalleparametro (id,idparametro,descripcion,valor)
values(1,1,'PAGADA','');
insert into detalleparametro (id,idparametro,descripcion,valor)
values(2,1,'DECLINADA','');
insert into detalleparametro (id,idparametro,descripcion,valor)
values(3,1,'FALLIDA','');
insert into detalleparametro (id,idparametro,descripcion,valor)
values(4,1,'ANULADA','');
insert into banco (nombre,direccion,fecharegistro)
values ('Banco de Crédito del Perú', 'Las Palmas 132 San Isidro', GETDATE())
go
--mantenbimiento banco
create proc sp_sel_banco
as
begin
select id,nombre,direccion from banco;
end
go
create proc sp_sel_bancoxid
@id int
as
begin
select id,nombre,direccion from banco where id=@id;
end
go
create proc sp_upd_banco
(
@id int,
@nombre nvarchar(100),
@direccion nvarchar(100)
)
as
begin
update banco set nombre = @nombre, direccion = @direccion where id=@id;
end;
go
create proc sp_ins_banco
(
@nombre nvarchar(100),
@direccion nvarchar(100)
)
as
begin
insert into banco (nombre, direccion, fecharegistro)
values (@nombre,@direccion, GETDATE());
SELECT @@IDENTITY ;
end;
go
create proc sp_del_banco
(
@id int
)
as
begin
delete banco where id = @id;
end
go
--mantenimiento sucursal
create proc sp_sel_sucursal
@idbanco int
as
begin
select su.id,su.nombre,su.idbanco, ba.nombre 'banco',su.direccion from sucursal su inner join banco ba on su.idbanco = ba.id
where su.idbanco = (select case @idbanco   
      when 0 then su.idbanco  
      else @idbanco end); 
end;
go
create proc sp_sel_sucursalxid
@id int
as
begin
select su.id,su.nombre, ba.nombre 'banco',su.direccion from sucursal su inner join banco ba on su.idbanco = ba.id
 where su.id=@id;
end;
go
create proc sp_upd_sucursal
(
@id int,
@nombre nvarchar(100),
@direccion nvarchar(100)
)
as
begin
update sucursal set nombre = @nombre, direccion = @direccion where id=@id;
end;
go
create proc sp_ins_sucursal
(
@idbanco int,
@nombre nvarchar(100),
@direccion nvarchar(100)
)
as
begin
insert into sucursal (idbanco, nombre, direccion, fecharegistro)
values (@idbanco,@nombre,@direccion, GETDATE());
SELECT @@IDENTITY ;
end;
go
create proc sp_del_sucursal
(
@id int
)
as
begin
delete sucursal where id = @id;
end;
go
--Mantenimiento orden de pagos
create proc sp_sel_estadosop
as
begin
select id, descripcion
from detalleparametro where idparametro = 1;
end;
go
create proc sp_sel_ordenpago
as
begin
select op.id,ba.nombre 'banco', su.nombre 'sucursal', op.monto, op.moneda , dp.descripcion 'des_estado'
from ordenpago op inner join sucursal su on op.idsucursal = su.id inner join detalleparametro dp
on op.estado = dp.id and dp.idparametro = 1 inner join banco ba on ba.id= su.idbanco;
end;
go
create proc sp_sel_ordenpagoxid
@id int
as
begin
select op.id,ba.nombre 'banco',op.idsucursal, su.nombre 'sucursal', op.monto, op.moneda ,op.estado, dp.descripcion 'des_estado'
from ordenpago op inner join sucursal su on op.idsucursal = su.id inner join detalleparametro dp
on op.estado = dp.id and dp.idparametro = 1 inner join banco ba on su.idbanco = ba.id
 where op.id=@id;
end;
go
create proc sp_upd_ordenpago
(
@id int,
@monto decimal(5,2),
@moneda nvarchar(100),
@estado int
)
as
begin
update ordenpago set monto = @monto, moneda = @moneda , estado = @estado where id=@id;
end;
go
create proc sp_ins_ordenpago
(
@idsucursal int,
@monto decimal(5,2),
@moneda nvarchar(10),
@estado int
)
as
begin
insert into ordenpago (idsucursal, monto, moneda,estado ,fecharegistro)
values (@idsucursal,@monto,@moneda,@estado, GETDATE());
SELECT @@IDENTITY ;
end;
go
create proc sp_del_ordenpago
(
@id int
)
as
begin
delete ordenpago where id = @id;
end;
go
--querys para los servicios
create proc sp_sel_ordenpagoxsucursalxmoneda
@sucursal nvarchar(100),
@moneda varchar(10)
as
begin
select op.id,ba.nombre 'banco', su.nombre 'sucursal', op.monto, op.moneda , dp.descripcion 'des_estado'
from ordenpago op inner join sucursal su on op.idsucursal = su.id inner join detalleparametro dp
on op.estado = dp.id and dp.idparametro = 1 inner join banco ba on ba.id= su.idbanco
where su.nombre = (select case @sucursal when '' then su.nombre else @sucursal end) 
and op.moneda = (select case @moneda when '' then op.moneda else @moneda end)
end;
