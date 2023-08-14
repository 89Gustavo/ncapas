window.onload = function () {
    listarTipoHabtiacion();
}
function listarTipoHabtiacion() {

    pintar({
        url: "TipoHabitacion/Lista",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId:"id"
    }, {
        busqueda: true,
        url: "TipoHabitacion/filtrarTipoHabicionNombre",
        nombrParametro: "nombreHabitacion",
        id: "txtCama",
        type: "text",
        button: false,
        placeholder: "Ingrese cama",
        idBoton: "btnCama"
    })
}

function GuardarDatos() {
   var frmTipoH = document.getElementById("frmTipoHabitacion");
    var frm = new FormData(frmTipoH);
    fetchPostText("TipoHabitacion/guardarDatos", frm, function (res) {
        if (res == "1") {
            LimpiarCampos();
            listarTipoHabtiacion();
   
        }
    })
}

function LimpiarCampos() {
    limpiarDatosInput("frmTipoHabitacion", ["id"]);
    Correcto("correcto");
}

function Editar(id) {
    recuperarGenerico("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, "frmTipoHabitacion");
}

function Eliminar(id) {
    confirmacion("Desea eliminar el tipo habitacion?", "Confirmacion elimnar", function (res) {
        fetchGetText("TipoHabitacion/eliminarTipoHabitacion/?id=" + id, function (rpt) {
            if (rpt == "1") {
                Correcto("Se elimino correctamente");
                listarTipoHabtiacion();
            }
        })
    });
}