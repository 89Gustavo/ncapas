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
        type: "text",
        button: false,
        placeholder: "Ingrese cama",
        idBoton:"btnCama"
    }, {
        type: "fildset",
        formulario: [
            [
                {
                    class: "mb-3 col-md-6",
                    type: "text",
                    label: "Id Cama",
                    name: "id",
                    value: "0",
                    redonly: true
                   
                },
                {
                    class: "mb-3 col-md-6",
                    type: "text",
                    label: "Nombre cama",
                    name: "cama",
                    value: "",
                    redonly: false

                }
            ],
            [

                { class: "mb-3 col-md-12", type: "text", label: "Descripcion Cama", name:"Descripcion", value: "", redonly: false }
            ]
        ]
    })


}