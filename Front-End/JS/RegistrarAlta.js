var habitacion;
var precio;
var fechaingresado;
const urlParams = new URLSearchParams(window.location.search);
const ingresoID = urlParams.get('ingresoID');

$('#ingresoID').val(ingresoID);

$("#registrarButton").on("click", function() {
  var fechaAlta = $("#start").val() + "T" + $("#appt").val() + ":00";
  var ingresoID = $("#ingresoID").val();

  var apiUrl = "https://localhost:7286/agregar-alta?Fecha_de_salida=" + encodeURIComponent(fechaAlta) + "&ID_Ingreso=" + ingresoID;
  
  $.ajax({
    type: "POST",
    url: apiUrl,
    success: function(response) {
      alert("Cita agendada correctamente");
      window.location.href = "Facturacion.html";
    },
    error: function(error) {
      alert("Error al agendar la cita: " + error.statusText);
    }
  });
});  

$(document).ready(function() {
    $("#datepicker").datepicker();
});
