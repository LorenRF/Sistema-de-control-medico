// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const pacienteID = urlParams.get('pacienteID');
const nombrePaciente = urlParams.get('nombrePaciente');
const apellidoPaciente = urlParams.get('apellidoPaciente');
const cedula = urlParams.get('cedula');
const asegurado = urlParams.get('asegurado');

$(document).ready(function() {
  $("#datepicker").datepicker();
});


$('#PacienteID').val(pacienteID);
$('#nombre').val(nombrePaciente);
$('#apellido').val(apellidoPaciente);
$('#asegurado').val(asegurado);
$('#cedula').val(cedula);


$("#Actualizar").on("click", function() {
  var IDpaciente = $("#PacienteID").val();
  var nombre = $("#nombre").val();
  var apellido = $("#apellido").val();
  var cedula = $("#cedula").val();
  var asegurado = $("#asegurado").val();

  var apiUrl = `https://localhost:7286/editar-paciente?ID_Paciente=${IDpaciente}&Cedula=${cedula}&Nombre_Paciente=${nombre}&Apellido_Paciente=${apellido}&Asegurado=${asegurado}`;
  
  $.ajax({
    type: "PUT",  // Cambiado a PUT para realizar una actualización
    url: apiUrl,
    success: function(response) {
      if (response && Object.keys(response).length > 0) {
        alert("Paciente actualizado correctamente");
        window.location.href = "Pacientes.html";
      } else {
        alert("Error al actualizar la paciente: Respuesta vacía o no válida");
      }
    },
    error: function(error) {
      alert("Error al actualizar la paciente: " + error.statusText);
    }
  });
});
