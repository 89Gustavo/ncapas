window.onload = function () {

    listarProducto();
}


function listarProducto() {

    pintar({
        url: "Productos/listarProductos",
        id: "divTabla",
        cabeceras: ["Id", "Producto","Marca", "Precio", "Stock","Denominacion"],
        propiedades: ["idProducto", "nombreProducto", "nombreMarca", "precioVente", "stock","denominacion"]
    })
}

function Buscar() {
    alert("me ejecute")
}