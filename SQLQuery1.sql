select *
from usuarios

alter PROCEDURE [dbo].[pa_BorrarFactura]
		@nroFactura int
AS
BEGIN
	delete detalles_factura
	where nro_factura = @nroFactura

	delete from facturas
	where nro_factura = @nroFactura
END
GO