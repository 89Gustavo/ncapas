window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "Marca/ListarMarca",
        id: "tablaMarca",
        cabeceras: ["Id cama", "Nombre", "Descripcion"],
        propiedades: ["idMarca", "nombre", "descripcion"]
    })


}