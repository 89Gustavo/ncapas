var configuracionFormulario;


var idObj;
var etiquetaObj;
var placeholderObj;
var typoObj;


var idBtn;
var nombreBtn;
var funcioBtn;
var colorBtn;
function pintarFormulario(objConfiguracionFormulario) {

    if (objConfiguracionFormulario.form == true) {

        var plantillaFormulario = "";
        plantillaFormulario += "<div id='formulario'>"
        plantillaFormulario +=
            `<fieldset class="container-fluid mb-3" style="border:1px solid; border-radius:5px; margin-right:15px">
            <legend>Datos de tipo habitacion</legend>
                <form id="frmTipoHabitacion">`

        for (var j = 0; j < objConfiguracionFormulario.objtosForm.length; j++) {

            idObj = objConfiguracionFormulario.objtosForm[j]["id"];
            etiquetaObj = objConfiguracionFormulario.objtosForm[j]["Etiqueta"];
            placeholderObj = objConfiguracionFormulario.objtosForm[j]["placeholder"];
            typoObj = objConfiguracionFormulario.objtosForm[j]["typo"];


            plantillaFormulario += `<div class=" mb-3">`
            plantillaFormulario += tipoObjeto(idObj, etiquetaObj, placeholderObj, typoObj);
            plantillaFormulario += `</div>` 
        }
        plantillaFormulario += ` <div class=" mb-3">`

        for (var x = 0; x < objConfiguracionFormulario.botonesForm.length; x++) {

            console.log(objConfiguracionFormulario.botonesForm[x]["nombreBtn"]);

            idBtn = objConfiguracionFormulario.botonesForm[x]["idBtn"];
            nombreBtn = objConfiguracionFormulario.botonesForm[x]["nombreBtn"];
            funcioBtn = objConfiguracionFormulario.botonesForm[x]["funcionBtn"];
            colorBtn = objConfiguracionFormulario.botonesForm[x]["colorBtn"];


           
            plantillaFormulario += botonForm(idBtn, nombreBtn, funcioBtn, colorBtn);
           
        }
        plantillaFormulario += ` <button type="button" class="btn btn-success" id=""  onclick="AGuardar()">fsf</button>`
        plantillaFormulario += ` </div>`
        

           
        plantillaFormulario  +=    `</form></fieldset>`
        plantillaFormulario += "</div>"

        document.getElementById(objConfiguracionFormulario.idFormulario).innerHTML = plantillaFormulario;
    }
   

}

/*----------------------------------------*/
function tipoObjeto(idObj, etiquetaObj, placeholderObj, typoObj) {



    if (idObj == undefined)
        idObj = "idObjto"
    if (etiquetaObj == undefined)
        etiquetaObj =""
    if (placeholderObj == undefined)
        placeholderObj = "Ingresar informacion"
 
    var plantillaFormulario = "";
    plantillaFormulario += `<label>${etiquetaObj}</label>`

    if (typoObj == "texto") {
        typoObj = "text"
    } else if (typoObj == "fecha") {
        typoObj = "date"
    }

    plantillaFormulario += `<input type="${typoObj}" class="form-control" name="nombre" id="${idObj}" placeholder="${placeholderObj}">`

    return plantillaFormulario;
}

function botonForm(idBtn, nombreBtn, funcioBtn, colorBtn) {


    var plantillaFormulario = "";
    plantillaFormulario += ` <button type="button" class="${colorBtn}" id="${idBtn}"  onclick="${funcioBtn}()">${nombreBtn}</button>`

    return plantillaFormulario;

}