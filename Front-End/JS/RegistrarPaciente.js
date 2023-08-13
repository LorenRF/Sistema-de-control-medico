$(document).ready(function() {
    $("#datepicker").datepicker();
  });

$("#agendarButton").on("click", function() {
      var fechaIngreso = $("#start").val() + "T" + $("#appt").val() + ":00";
      var pacienteId = $("#pacienteId").val();
      var habitacionId = $("#medicoId").val();

      var apiUrl = "https://localhost:7286/agregar-ingreso?Fecha_de_ingreso=" + encodeURIComponent(fechaIngreso) + "&ID_Habitacion=" + habitacionId + "&ID_Paciente=" + pacienteId;
      
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