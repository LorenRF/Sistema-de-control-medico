// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const altaid = urlParams.get('altaID');
const fechaAlta = urlParams.get('fechaAlta');
const horaAlta = urlParams.get('horaAlta');
const pago = urlParams.get('pago');
const idpaciente = urlParams.get('idpaciente');

$(document).ready(function() {
  $("#datepicker").datepicker();
});


$('#AltaID').val(altaid);
$('#start').val(fechaAlta);
$('#appt').val(horaAlta);
$('#pago').val(pago);


$("#Actualizar").on("click", function() {
  var IDalta = $("#AltaID").val();
  var fechaAlta = $("#start").val() + "T" + $("#appt").val() + ":00";
  var pago = $("#pago").val();

  var apiUrl = `https://localhost:7286/editar-alta?ID_Alta=${IDalta}&Fecha_de_alta=${encodeURIComponent(fechaAlta)}&pago=${pago}`;
  
  $.ajax({
    type: "PUT",  
    url: apiUrl,
    success: function(response) {
      if (response && Object.keys(response).length > 0) {
        alert("Alta actualizada correctamente");
        window.location.href = "Altas.html";
      } else {
        alert("Error al actualizar la alta: Respuesta vacía o no válida");
      }
    },
    error: function(error) {
      alert("Error al actualizar la alta: " + error.statusText);
    }
  });
});
