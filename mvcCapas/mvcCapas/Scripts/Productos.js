window.onload = function () {

    listarProducto();
}


function listarProducto() {

    pintar({
        url: "Productos/listarProductos",
        id: "divTabla",
        cabeceras: ["Id", "Producto","Marca", "Precio", "Stock","Denominacion"],
        propiedades: ["idProducto", "nombreProducto", "nombreMarca", "precioVente", "stock","denominacion"]
    }, {
        busqueda: true,
        url: "Productos/FiltrarProductos",
        nombrParametro: "nombreProducto",
        id: "txtProducto",
        type: "text",
        button: false,
        placeholder: "Ingrese el nombre del producto",
        idBoton: "btnProducto"
    })
}

