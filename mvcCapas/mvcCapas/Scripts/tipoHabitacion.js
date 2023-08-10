window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "TipoHabitacion/Lista",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
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

/*function Buscar() {
    var nombreTipoHabitacion = get("txtNombreTipoHabiacion");
    pintar({
        url: "TipoHabitacion/filtrarTipoHabicionNombre/?nombreHabitacion=" + nombreHabitacion,
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    })
   // alert(nombreTipoHabitacion);
}*/