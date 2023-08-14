const urlParams = new URLSearchParams(window.location.search);
const ingresoID = urlParams.get('ingresoID');



$('#ingresoID').val(ingresoID);

$("#registrarButton").on("click", function() {
  const inputDate = new Date(document.getElementById('start').value + 'T' + document.getElementById('appt').value + ':00');
  const IDIngreso = document.getElementById('ingresoID').value;

  fetch("https://localhost:7286/obtener-ingreso?id=" + IDIngreso)
    .then(response => response.json())
    .then(apiResponse => {
      apiResponse.forEach(ingreso => {
        const habitacion = ingreso.iD_Habitacion;
        const fechaIngreso = new Date(ingreso.ingresado); // Convertir la fecha de la API a un objeto Date
        
        // Calculando la diferencia en milisegundos
        const differenceInMilliseconds = inputDate - fechaIngreso;
        
        // Convirtiendo la diferencia en días
        const differenceInDays = Math.ceil(differenceInMilliseconds / (1000 * 60 * 60 * 24));
        
        // Imprimiendo la diferencia en días en la consola
        console.log('Diferencia en días:', differenceInDays, fechaIngreso);
        
        const url = `Facturacion.html?IDIngreso=${IDIngreso}&dias=${differenceInDays}&fehcaalta=${inputDate}&habitacion=${habitacion}`;

        window.location.href = url;
      });
    })
    .catch(error => {
      console.error('Error al obtener datos de la API:', error);
    });
});


$(document).ready(function() {
    $("#datepicker").datepicker();
});
