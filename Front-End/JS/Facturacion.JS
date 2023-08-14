const urlParams = new URLSearchParams(window.location.search);
const ingresoID = urlParams.get('IDIngreso');
const dias = urlParams.get('dias');
const fehcaalta = urlParams.get('fehcaalta');
const contenedor = document.getElementById('detalles');
const iD_Habitacion = urlParams.get('habitacion');
var altaFecha = new Date(fehcaalta);
var fechaFormateada = formatearFecha(altaFecha);

document.addEventListener("DOMContentLoaded", function() {
  fetch("https://localhost:7286/obtener-habitacion?id=" + iD_Habitacion)
  .then(response => response.json())
  .then(apiResponse => {
    apiResponse.forEach(habitacion => {
     const precio = habitacion.precio
    contenedor.innerHTML = `<h2>Dias internado: ${dias}</h2> <br> <h2>Precio de la habitacion: ${precio}</h2> <br> <h2>Total a pagar: ${dias}*${precio} = ${dias*precio}</h2> <br> `
    });
  })
  .catch(error => {
    console.error('Error al obtener datos de la API:', error);
  });
});

$("#cancelar").on("click", function() {
if (confirmAction()){
  window.location.href = "Ingresos.html";
}

});
  
$("#facturar").on("click", function() {
  var apiUrl = "https://localhost:7286/agregar-alta?Fecha_de_salida=" + fechaFormateada + "&ID_Ingreso=" + ingresoID;
      
      $.ajax({
        type: "POST",
        url: apiUrl,
        success: function(response) {
          alert("Alta registrada correctamente");
            window.location.href = "Altas.html";
        },
        error: function(error) {
          alert("Error al agendar la alta: " + error.statusText);
        }
      });
  
  });

// Función para mostrar un cuadro de diálogo de confirmación
function confirmAction() {
  var confirmation = confirm("¿Estás seguro de querer cancelar la facturacion?");
  if (confirmation) {
    // El usuario hizo clic en "Aceptar"
      return true;
    // Aquí puedes realizar la acción que desees
  } else {
    // El usuario hizo clic en "Cancelar" o cerró el cuadro de diálogo
    return false;

    // Aquí puedes manejar la acción de cancelación si es necesario
  }
}

function formatearFecha(fecha) {
  var año = fecha.getFullYear();
  var mes = (fecha.getMonth() + 1).toString().padStart(2, '0');
  var dia = fecha.getDate().toString().padStart(2, '0');
  var horas = fecha.getHours().toString().padStart(2, '0');
  var minutos = fecha.getMinutes().toString().padStart(2, '0');
  var segundos = fecha.getSeconds().toString().padStart(2, '0');
  return `${año}-${mes}-${dia}T${horas}:${minutos}:${segundos}`;
}

// Obtener la fecha formateada

