// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const medicoID = urlParams.get('medicoID');
const pacienteID = urlParams.get('pacienteID');

$(document).ready(function() {
    $("#datepicker").datepicker();
    $("#medicoId").val(medicoID);
    $("#pacienteId").val(pacienteID);
  });

$("#agendarButton").on("click", function() {
      var fechaCita = $("#start").val() + "T" + $("#appt").val() + ":00";
      var pacienteId = $("#pacienteId").val();
      var medicoId = $("#medicoId").val();
      

      var apiUrl = "https://localhost:7286/agregar-cita?Fecha_Cita=" + encodeURIComponent(fechaCita) + "&ID_Medico=" + medicoId + "&ID_Paciente=" + pacienteId;
      
      $.ajax({
        type: "POST",
        url: apiUrl,
        success: function(response) {
          alert("Cita agendada correctamente");
        },
        error: function(error) {
          alert("Error al agendar la cita: " + error.statusText);
        }
      });
    });  