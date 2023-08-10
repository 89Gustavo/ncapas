window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "TipoUsuario/ListaUsuarios",
        id: "divTablaTipoUsuario",
        cabeceras: ["codigo", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    }, {
        busqueda: true,
        url: "TipoUsuario/FiltrarUsuarios",
        nombrParametro: "tipoUsuario",
        id: "txtTipoUsuario",
        type: "text",
        button: false,
        placeholder: "Ingrese nombre el tipo usuario",
        idBoton: "btnTipoUsuario"
    })


}