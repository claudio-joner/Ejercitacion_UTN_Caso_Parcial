CREATE DATABASE [PREPARCIAL]
GO

USE [PREPARCIAL]
GO

CREATE TABLE Materiales(
id_material int IDENTITY(1,1),
nom_material varchar(40),
stock_material int
CONSTRAINT pk_materiales PRIMARY KEY(id_material))
 
 CREATE TABLE OrdenesRetiro(
id_orden int IDENTITY(1,1),
fecha_orden datetime,
responsable varchar(50),
fecha_baja datetime
CONSTRAINT pk_ordenes PRIMARY KEY(id_orden))

CREATE TABLE DetallesOrden(
id_detalle int,
id_orden int,
material int,
cantidad int
CONSTRAINT fk_materiales FOREIGN KEY(material)
	REFERENCES Materiales(id_material),
CONSTRAINT fk_orden_detalle FOREIGN KEY (id_orden)
	REFERENCES OrdenesRetiro(id_orden))


 GO 
INSERT INTO Materiales(nom_material,stock_material) VALUES('Plastico',1000)
INSERT INTO Materiales(nom_material,stock_material) VALUES('Cuero',1000)
INSERT INTO Materiales(nom_material,stock_material) VALUES('Algodon',1000)
INSERT INTO Materiales(nom_material,stock_material) VALUES('Hierro',1000)
INSERT INTO Materiales(nom_material,stock_material) VALUES('Carton',1000)
GO
CREATE PROCEDURE SP_PROXIMA_ORDEN
@next int OUTPUT
AS
BEGIN
    SET @next = (SELECT max(id_orden)+1 FROM OrdenesRetiro);
END
GO
CREATE PROCEDURE SP_CONSULTAR_MATERIALES
AS
BEGIN
SELECT * FROM Materiales
END
GO
CREATE PROCEDURE SP_INSERTAR_ORDEN
@fecha_orden datetime,
@responsable varchar(50),
@prox_orden int output
AS
BEGIN
INSERT INTO OrdenesRetiro(fecha_orden,responsable) VALUES (@fecha_orden,@responsable)
SET @prox_orden = SCOPE_IDENTITY();
END
GO
CREATE PROCEDURE SP_INSERTAR_DETALLE
@id_detalle int,
@id_orden int,
@material int,
@cantidad int
AS
BEGIN
INSERT INTO DetallesOrden(id_detalle,id_orden,material,cantidad)
VALUES(@id_detalle,@id_orden,@material,@cantidad)
UPDATE Materiales
SET stock_material = stock_material-@cantidad
WHERE id_material=@material
END
GO
CREATE PROCEDURE SP_CONSULTAR_ORDENES_MENOR
@responsable varchar(30),
@fecha_orden datetime
AS
BEGIN
SELECT id_orden, responsable, fecha_orden
FROM OrdenesRetiro 
WHERE (responsable LIKE '%'+@responsable+'%')
AND fecha_orden>@fecha_orden
AND fecha_baja IS NULL
END
GO
CREATE PROCEDURE SP_CONSULTAR_ORDENES_MAYOR
@responsable varchar(30),
@fecha_orden datetime
AS
BEGIN
SELECT id_orden, responsable, fecha_orden
FROM OrdenesRetiro 
WHERE (responsable LIKE '%'+@responsable+'%')
AND fecha_orden<@fecha_orden
AND fecha_baja IS NULL
END
GO
CREATE PROCEDURE SP_CONSULTAR_ORDEN
@id_orden int
AS
BEGIN
SELECT id_orden, responsable, fecha_orden
FROM OrdenesRetiro
WHERE id_orden=@id_orden
END
GO
CREATE PROCEDURE SP_CONSULTAR_DETALLES_ORDEN
@id_orden int
AS 
BEGIN
SELECT id_detalle, material, nom_material, cantidad
	FROM DetallesOrden d JOIN Materiales m
		ON d.material=m.id_material
WHERE id_orden=@id_orden
END
GO
CREATE PROCEDURE SP_CONSULTAR_CANT_STOCK
AS
BEGIN
SELECT nom_material,stock_material
FROM Materiales
END
GO
CREATE PROCEDURE SP_ACTUALIZAR_ORDEN
@id_orden int,
@fecha_orden datetime,
@responsable varchar(50)
AS
BEGIN
UPDATE OrdenesRetiro
SET responsable=@responsable,
fecha_orden=@fecha_orden
WHERE id_orden=@id_orden
END
GO
CREATE PROCEDURE SP_BORRAR_CARGAS
@id_orden int = null
AS
BEGIN
DELETE DetallesOrden
WHERE id_orden=@id_orden
END
GO
CREATE PROCEDURE SP_BORRAR_ORDEN
@id_orden int = null
AS
BEGIN
UPDATE OrdenesRetiro
SET fecha_baja = getdate()
WHERE id_orden=@id_orden
END

--PRUEBAS A LA BASE DE DATOS
SELECT * FROM OrdenesRetiro
SELECT * FROM DetallesOrden
