window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "Cama/listarCama",
        id: "divTabla",
        cabeceras: ["Id cama", "Nombre", "Descripcion"],
        propiedades: ["idCama", "nombre", "descripcion"]
    }, {
        busqueda: true,
        url: "Cama/filtrarCama",
        nombrParametro: "nombreCama",
        id: "txtCama",
        type:"text",
        placeholder: "Ingrese cama",
        idBoton:"btnCama"
    })


}