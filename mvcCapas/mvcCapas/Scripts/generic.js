
var objConfiguratcionGlobal;
var objBusquedaGlobal;
function pintar(objConfiguratcion, objBusqueda,objFormulario){

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

                if (objConfiguratcion.editar == undefined)
                    objConfiguratcion.editar = false
                if (objConfiguratcion.eliminar == undefined)
                    objConfiguratcion.eliminar = false

                if (objConfiguratcion.propiedadId == undefined)
                    objConfiguratcion.propiedadId = "id"

                if (objConfiguratcion.id == undefined)
                    objConfiguratcion.id = "divTabla"

                objConfiguratcionGlobal = objConfiguratcion;
                objBusquedaGlobal = objBusqueda;
               
                if (objFormulario == undefined) {
                    contenido += "";
                } else { 
                contenido += construirFormulario(objFormulario);
                }

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
function set(id,valor) {
    return document.getElementById(id).value;
}


function setName(id, valor) {
    return document.getElementsByName(id)[0].value=valor;
}
function Error(texto="Ocurrio un error!") {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: texto,

    })
}

function Correcto(texto= "Se realiso correctamente") {
    Swal.fire({
        icon: 'success',
        title:"Success",
        text: texto,
        showConfirmButton: true,
        timer: 1500
    })
    /*   'Good job!',
        'You clicked the button!',
        'success'*/
}

function confirmacion(texto="Desea guardar los cambios",title="confirmacion", callback) {
  return  Swal.fire({
        title: title,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'

    }).then((result) => {
        if (result.isConfirmed) {
            callback();
          
        }
    })
}

function limpiarDatosInput(idformulario,execpciones=[]) {
    var elementos = document.querySelectorAll("#" + idformulario+" [name]")
    for (var i = 0; i < elementos.length; i++) {
        if(!execpciones.includes(elementos[i].name))
        elementos[i].value = ""
    }
}

function generarTabla(objConfiguratcion, res) {
    var contenido = "";
    contenido += "<table class='table'>";
    contenido += "<tr>"
  
    for (var j = 0; j < objConfiguratcion.cabeceras.length; j++) {

        contenido += "<th>" + objConfiguratcion.cabeceras[j] + "</th>"
    }
    if (objConfiguratcion.editar == true || objConfiguratcion.eliminar == true) {
        contenido += "<th>Operaciones</th>"
    }
    contenido += "</tr>"
    var fila;
    var propiedadActual;
    for (var i = 0; i < res.length; i++) {
        fila = res[i]

        contenido += "<tr>"
        for (var j = 0; j < objConfiguratcion.propiedades.length; j++) {
            propiedadActual = objConfiguratcion.propiedades[j];
            contenido += "<td>" + fila[propiedadActual] + "</td>"
        }

        if (objConfiguratcion.editar == true || objConfiguratcion.eliminar == true) {
            contenido += "<td>";
            if (objConfiguratcion.editar == true) {
                contenido += `<i class="btn btn-warning me-1" onclick="Editar(${fila[objConfiguratcion.propiedadId]})">
                                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil" viewBox="0 0 16 16">
                                    <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z"/>
                                 </svg></i>`
            }
            if (objConfiguratcion.eliminar == true) {
                contenido += `<i class="btn btn-danger" onclick="Eliminar(${fila[objConfiguratcion.propiedadId]})">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
                                    <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
                                </svg></i>`
            }

            contenido += "</td>";
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
            console.log(e + res)

        })
}

function fetchGetText(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbolute = window.location.protocol + "//" + window.location.host + raiz + url;

    fetch(urlAbolute).then(res => res.text())
        .then(res => {

            callback(res)

        }).catch(err => {
            console.log(e + res)

        })
}

function fetchPostText(url,frm, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbolute = window.location.protocol + "//" + window.location.host + raiz + url;

    fetch(url, {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            callback(res)
        }).catch(err => {

            console.log(err);
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
}

function recuperarGenerico(url, idformulario, execpciones = []) {
    var elementos = document.querySelectorAll("#" + idformulario + " [name]")
    var nombreName 
    fetchGet(url, function (res) {
       
        for (var i = 0; i < elementos.length; i++) {
            nombreName = elementos[i].name
            if(!execpciones.includes(elementos[i].name))
                setName(nombreName, res[nombreName])
        }

    });
}

function construirFormulario(objFormulario) {
    var contenido = "";
    var type = objFormulario.type;
    contenido = "";
   /* if (type == undefined) {
        contenido += "";
    }*/
 var elementos = objFormulario.formulario;
   
     contenido = `<div>`
    var arrayElemento;
    var numeroArrayelemnto;
    for (var i = 0; i < elementos.length; i++) {
        arrayElemento = elementos[i];
        numeroArrayelemnto = arrayElemento.length;
        contenido += "<div class='row'>";
        for (var j = 0; j < numeroArrayelemnto; j++) {
            var hijosArray = arrayElemento[j]
            var typeElemento = hijosArray.type;
            contenido += `<div class="${hijosArray.class}">`
            contenido += `<label>${hijosArray.label}</label>`
            if (typeElemento == "text") {
                contenido += `<input type="text" class="form-control"  name="${hijosArray.name}" value="${hijosArray.value}" 
                ${hijosArray.redonly == true ?"readonly":""}>`
            }
            contenido += `</div>`
        }

    }
    
    contenido += `</div>`


        return contenido;
}