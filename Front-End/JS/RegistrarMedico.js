
$("#agendarButton").on("click", function() {
      var nombre = $("#nombre").val();
      var apellido = $("#apellido").val();
      var ex = $("#ex").val();
      var especialidad = $("#especialidad").val();

      var apiUrl = "https://localhost:7286/agregar-medico?Nombre_Medico=" + nombre + "&Apellido_Medico=" +apellido  + "&Exequatur=" + ex + "&Especialidad=" + especialidad;
      
      $.ajax({
        type: "POST",
        url: apiUrl,
        success: function(response) {
          alert("Cita agendada correctamente");
        },
        error: function(error) {
          alert("Error al agendar la medico: " + error.statusText);
        }
      });
    });  