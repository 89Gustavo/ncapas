window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "Marca/ListarMarca",
        id: "tablaMarca",
        cabeceras: ["Id cama", "Nombre", "Descripcion"],
        propiedades: ["idMarca", "nombre", "descripcion"]
    }, {
        
        busqueda: true,
        url: "Marca/FiltrarMarca",
        nombrParametro: "marca",
        id: "txtMarca",
        type: "text",
        button: false,
        placeholder: "Ingrese la marca",
        idBoton: "btnMarca"
    })


}