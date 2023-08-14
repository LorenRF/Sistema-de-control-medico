$(document).ready(function() {
    $("#datepicker").datepicker();
  });

$("#agendarButton").on("click", function() {
      var cedula = $("#cedula").val();
      var nombre = $("#nombre").val();
      var apellido = $("#apellido").val();
      var asegurado = $("#asegurado").val();

      var apiUrl = "https://localhost:7286/agregar-paciente?Cedula=" + cedula + "&Nombre_Paciente=" + nombre + "&Apellido_Paciente=" + apellido + "&Asegurado=" +asegurado;
      
      $.ajax({
        type: "POST",
        url: apiUrl,
        success: function(response) {
          alert("Paciente Registrado correctamente");
        },
        error: function(error) {
          alert("Error al agendar la paciente: " + error.statusText);
        }
      });
    });  

          // Obtén el elemento select
      var selectEspecialidad = document.getElementById("asegurado");

      // Agrega un evento de cambio (change) al elemento select
      selectEspecialidad.addEventListener("change", function() {
        // Obtén el valor seleccionado
        var valorSeleccionado = selectEspecialidad.value;

        // Ejecuta el código que deseas realizar con el valor seleccionado
        console.log("Valor seleccionado:", valorSeleccionado);
      });
