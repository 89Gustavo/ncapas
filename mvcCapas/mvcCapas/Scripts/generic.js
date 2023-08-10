
var objConfiguratcionGlobal;
var objBusquedaGlobal;
function pintar(objConfiguratcion, objBusqueda){

    var raiz = document.getElementById("hdfOculto").value;
    var urlAbolute = window.location.protocol + "//" +
        window.location.host + raiz + objConfiguratcion.url;

    fetch(urlAbolute)

        .then(res => res.json())
        .then(res => {
            var contenido = "";
            if (objBusqueda != undefined && objBusqueda.busqueda == true) {
                if (objBusqueda.id == undefined)
                    objBusqueda.id = "txtBusqueda"
                if (objBusqueda.placeholder == undefined)
                    objBusqueda.placeholder = "Ingrese un valor"
                if (objBusqueda.idBoton == undefined)
                    objBusqueda.idBoton = "btnBuscar"
                if (objBusqueda.type == undefined)
                    objBusqueda.type = "text"

                if (objConfiguratcion.id == undefined)
                    objConfiguratcion.id = "divTabla"

                objConfiguratcionGlobal = objConfiguratcion;
                objBusquedaGlobal = objBusqueda;

                contenido += `<div class="input-group mb-3">`
                contenido += `<input type="${objBusqueda.type}" class="form-control" id="${objBusqueda.id}"placeholder="${objBusqueda.placeholder}" >`

                contenido +=`<button class="btn btn-primary" type="button"onclick="Buscar()" id="${objBusqueda.idBoton}">BUSCAR</button>
                        </div >`
            }
            contenido += "<div id='divCotenido'>"
            contenido += generarTabla(objConfiguratcion, res);
            contenido += "</div>"
            
            document.getElementById(objConfiguratcion.id).innerHTML = contenido;
        
        })
}

function get(id) {
    return document.getElementById(id).value;
}

function generarTabla(objConfiguratcion, res) {
    var contenido = "";
    contenido += "<table class='table'>";
    contenido += "<tr>"

    for (var j = 0; j < objConfiguratcion.cabeceras.length; j++) {

        contenido += "<th>" + objConfiguratcion.cabeceras[j] + "</th>"
    }
    var fila;
    var propiedadActual;
    for (var i = 0; i < res.length; i++) {
        fila = res[i]

        contenido += "<tr>"
        for (var j = 0; j < objConfiguratcion.propiedades.length; j++) {
            propiedadActual = objConfiguratcion.propiedades[j];
            contenido += "<td>" + fila[propiedadActual] + "</td>"
        }

        contenido += "</tr>"
    }

    contenido += "</table>"

    return contenido;
}

function Buscar() {
    var objConf = objConfiguratcionGlobal;
    var objBusc = objBusquedaGlobal;


    var valor = get(objBusc.id);
    fetch(`${objBusc.url}/?${objBusc.nombrParametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            var rpt = generarTabla(objConf, res);
            document.getElementById("divCotenido").innerHTML = rpt;
        })

}