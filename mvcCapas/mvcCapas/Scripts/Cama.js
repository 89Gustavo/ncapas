window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "Cama/listarCama",
        id: "tablaCama",
        cabeceras: ["Id cama", "Nombre", "Descripcion"],
        propiedades: ["idCama", "nombre", "descripcion"]
    })


}