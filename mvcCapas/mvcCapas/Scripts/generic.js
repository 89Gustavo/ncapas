
function pintar(objConfiguratcion){


    fetch(objConfiguratcion.url)

        .then(res => res.json())
        .then(res => {
            var contenido = "<table class='table'>";
            contenido += "<tr>"

            for (var j = 0; j < objConfiguratcion.cabeceras.length; j++) {

                contenido += "<th>"+objConfiguratcion.cabeceras[j]+"</th>"
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
            document.getElementById(objConfiguratcion.id).innerHTML = contenido;
          //  alert(res)
        })
}