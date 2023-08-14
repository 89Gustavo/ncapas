window.onload = function () {
    listarTipoHabtiacion();
    formulario();
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

function formulario() {

    pintarFormulario({
        idFormulario: "formularioUsuario",
        form: true,
        objtosForm : [
            {
                id: "nombreUsuario",
                Etiqueta: "Nombre Usuarios",
                typo: "texto",
                placeholder: "Ingrese el nombre del usuario"

            }, {
                id: "descripcionUsuario",
                Etiqueta: "Descripcion Usuario",
                typo: "texto",
                placeholder: "Ingrese la descripcion del Usuario"
            }
        ],
        botonesForm: [
            {
                idBtn: "idGuardarUsuario",
                nombreBtn: "Guardar",
                colorBtn:"btn btn-success",
                funcionBtn: "Guardar"
            },
            {
                idBtn: "idLimpiarformulario",
                nombreBtn: "Limpiar",
                colorBtn: "btn btn-warning",
                funcionBtn: "Limpiar"
            }
            ,
            {
                idBtn: "idLimpiarformulario",
                nombreBtn: "Volver",
                colorBtn: "btn btn-danger",
                funcionBtn: "Volver"
            }
            ]
    })

}