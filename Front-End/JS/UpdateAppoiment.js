// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const citaID = urlParams.get('citaID');
const fechaCita = urlParams.get('fechaCita');
const horaCita = urlParams.get('horaCita');
const idmedico = urlParams.get('idmedico');
const idpaciente = urlParams.get('idpaciente');

$(document).ready(function() {
  $("#datepicker").datepicker();
});


$('#CitaID').val(citaID);
$('#start').val(fechaCita);
$('#appt').val(horaCita);
$('#pacienteId').val(idpaciente);
$('#medicoId').val(idmedico);


$("#Actualizar").on("click", function() {
  var IDcita = $("#CitaID").val();
  var fechaCita = $("#start").val() + "T" + $("#appt").val() + ":00";
  var pacienteId = $("#pacienteId").val();
  var medicoId = $("#medicoId").val();

  var apiUrl = `https://localhost:7286/editar-cita?ID_Cita=${IDcita}&Fecha_Cita=${encodeURIComponent(fechaCita)}&ID_Medico=${medicoId}&ID_Paciente=${pacienteId}`;
  
  $.ajax({
    type: "PUT",  // Cambiado a PUT para realizar una actualización
    url: apiUrl,
    success: function(response) {
      if (response && Object.keys(response).length > 0) {
        alert("Cita actualizada correctamente");
        window.location.href = "Cistas.html";
      } else {
        alert("Error al actualizar la cita: Respuesta vacía o no válida");
      }
    },
    error: function(error) {
      alert("Error al actualizar la cita: " + error.statusText);
    }
  });
});
