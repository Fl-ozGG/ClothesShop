creo shop -> creo suplier -> añade producto a shop -> creo usuario -> compro producto




Sistema de Gestión de Tienda de Ropa (inventario, ventas, clientes, proveedores)

Registrar un nuevo producto en inventario con toda su información (nombre, categoría, precio, stock, proveedor).

Actualizar la información de un producto existente (precio, descripción, stock).

Registrar un cliente nuevo con datos completos y válidos.

Registrar un proveedor y asociar productos a ese proveedor.

Registrar una venta, incluyendo uno o varios productos y el cliente asociado.

Consultar el inventario disponible de productos.

Consultar el historial de ventas por cliente, fecha o producto.

Consultar información de proveedores y productos asociados.

Calcular automáticamente el total de una venta (sumando cantidades × precio de venta).

Gestionar la persistencia de toda la información en la base de datos.


Reglas de negocio:

No se puede registrar una venta si el producto no tiene stock suficiente.

Al realizar una venta, el sistema debe disminuir automáticamente el inventario del producto.

No se puede registrar un cliente sin datos obligatorios (nombre, identificación, medio de contacto).

Los proveedores solo pueden registrar productos asociados a su identificación.

No se puede eliminar un producto si existen ventas asociadas a él.