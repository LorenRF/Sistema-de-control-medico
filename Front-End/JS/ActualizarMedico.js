// Obtén los parámetros de la URL
const urlParams = new URLSearchParams(window.location.search);
const medicoID = urlParams.get('medicoID');
const nombreMedico = urlParams.get('nombreMedico');
const apellidoMedico = urlParams.get('apellidoMedico');
const exmedico = urlParams.get('exmedico');
const especial = urlParams.get('especial');

$(document).ready(function() {
  $("#datepicker").datepicker();
});


$('#MedicoID').val(medicoID);
$('#nombre').val(nombreMedico);
$('#apellido').val(apellidoMedico);
$('#especialidad').val(especial);
$('#ex').val(exmedico);


$("#Actualizar").on("click", function() {
  var IDmedico = $("#MedicoID").val();
  var nombre = $("#nombre").val();
  var apellido = $("#apellido").val();
  var especialidad = $("#especialidad").val();
  var ex = $("#ex").val();

  var apiUrl = `https://localhost:7286/editar-medico?ID_Medico=${IDmedico}&Nombre_Medico=${nombre}&Apellido_Medico=${apellido}&Exequatur=${ex}&Especialidad=${especialidad}`;
  
  $.ajax({
    type: "PUT",  // Cambiado a PUT para realizar una actualización
    url: apiUrl,
    success: function(response) {
      if (response && Object.keys(response).length > 0) {
        alert("Medico actualizado correctamente");
        window.location.href = "Medicos.html";
      } else {
        alert("Error al actualizar la medico: Respuesta vacía o no válida");
      }
    },
    error: function(error) {
      alert("Error al actualizar la medico: " + error.statusText);
    }
  });
});
