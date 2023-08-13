// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const ingresoID = urlParams.get('ingresoID');
const fechaIngreso = urlParams.get('fechaIngreso');
const horaIngreso = urlParams.get('horaIngreso');
const idmedico = urlParams.get('idmedico');
const idpaciente = urlParams.get('idpaciente');

$(document).ready(function() {
  $("#datepicker").datepicker();
});


$('#IngresoID').val(ingresoID);
$('#start').val(fechaIngreso);
$('#appt').val(horaIngreso);
$('#pacienteId').val(idpaciente);
$('#medicoId').val(idmedico);


$("#Actualizar").on("click", function() {
  var IDingreso = $("#IngresoID").val();
  var fechaIngreso = $("#start").val() + "T" + $("#appt").val() + ":00";
  var pacienteId = $("#pacienteId").val();
  var medicoId = $("#medicoId").val();

  var apiUrl = `https://localhost:7286/editar-ingreso?ID_Ingreso=${IDingreso}&Fecha_de_ingreso=${encodeURIComponent(fechaIngreso)}&ID_Habitacion=${medicoId}&ID_Paciente=${pacienteId}`;
  
  $.ajax({
    type: "PUT",  // Cambiado a PUT para realizar una actualización
    url: apiUrl,
    success: function(response) {
      if (response && Object.keys(response).length > 0) {
        alert("Ingreso actualizado correctamente");
        window.location.href = "Ingresos.html";
      } else {
        alert("Error al actualizar la ingreso: Respuesta vacía o no válida");
      }
    },
    error: function(error) {
      alert("Error al actualizar la ingreso: " + error.statusText);
    }
  });
});
