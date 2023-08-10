
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
                if (objBusqueda.button == undefined)
                    objBusqueda.id = true

                if (objConfiguratcion.id == undefined)
                    objConfiguratcion.id = "divTabla"

                objConfiguratcionGlobal = objConfiguratcion;
                objBusquedaGlobal = objBusqueda;

                contenido += `<div class="input-group mb-3">`
                contenido += `<input type="${objBusqueda.type}" 
                                class="form-control"
                                id="${objBusqueda.id}"
                               ${objBusqueda.button == true ? "" : "onkeyup = 'Buscar()'"}
                               
                                placeholder="${objBusqueda.placeholder}" >`
                if (objBusqueda.button == true) { 
                    contenido += `<button class="btn btn-primary" type="button"onclick="Buscar()" id="${objBusqueda.idBoton}">BUSCAR</button>`
                }
                contenido += `</div >`
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

function fetchGet(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbolute = window.location.protocol + "//" +window.location.host + raiz + url;

    fetch(urlAbolute).then(res => res.json())
        .then(res => {

            callback(res)
           
        }).catch(err => {
            console.log(e)

        })
}

function Buscar() {
    var objConf = objConfiguratcionGlobal;
    var objBusc = objBusquedaGlobal;
    var valor = get(objBusc.id);
    fetchGet(`${objBusc.url}/?${objBusc.nombrParametro}=` + valor, function (res) { 
        var rpt = generarTabla(objConf, res);
        document.getElementById("divCotenido").innerHTML = rpt;
    })
    
    /*fetch(`${objBusc.url}/?${objBusc.nombrParametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            var rpt = generarTabla(objConf, res);
            document.getElementById("divCotenido").innerHTML = rpt;
        })
        */
}