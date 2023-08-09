window.onload = function () {
    listarTipoHabtiacion();
}

function listarTipoHabtiacion() {

    pintar({
        url: "TipoHabitacion/Lista",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    })

   
}

function Buscar() {
    var nombreTipoHabitacion = get("txtNombreTipoHabiacion");
    pintar({
        url: "TipoHabitacion/filtrarTipoHabicionNombre/?nombreHabitacion=" + nombreTipoHabitacion,
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    })
   // alert(nombreTipoHabitacion);
}