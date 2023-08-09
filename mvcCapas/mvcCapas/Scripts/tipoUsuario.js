window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "TipoUsuario/ListaUsuarios",
        id: "divTablaTipoUsuario",
        cabeceras: ["codigo", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    })


}