$(document).ready(function () {
  // Only needed for the filename of export files.
  // Normally set in the title tag of your page.
  document.title = "Simple DataTable";

  // Create search inputs in footer
  $("#example tfoot th").each(function () {
      var title = $(this).text();
      if (title === "Asegurado") {
        $(this).html('<select><option value="">All</option><option value="true">true</option><option value="false">false</option></select>');
      } else {
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
      }
    });
    

  // DataTable initialization
  var table = $("#example").DataTable({
    initComplete: function (settings, json) {
      var footer = $("#example tfoot tr");
      $("#example thead").append(footer);
    }
  });

  // Fetch data from the API and populate the DataTable
    fetch('https://localhost:7286/api/Paciente/obtener-pacientes')
.then(response => response.json())
.then(apiResponse => {
  apiResponse.forEach(paciente => {
    if (paciente.estatus === "Activo") {
 table.row.add([
        paciente.iD_Paciente,
        paciente.cedula,
        paciente.paciente,
        paciente.asegurado,

      ]).draw();
    }
  });
})
.catch(error => {
  console.error('Error al obtener datos de la API:', error);
});
    $("#example thead").on("keyup change", "input, select", function () {
if ($(this).is("select")) {
  const columnIndex = $(this).parent().index();
  const filterValue = $(this).val();
  
  
    table.column(columnIndex).search(filterValue).draw();
  
} else {
  table.column($(this).parent().index()).search(this.value).draw();
}
});

////selection


table.on('click', 'tbody tr', function (e) {
e.currentTarget.classList.toggle('selected'); 
var selectedRows = $("#example tbody tr.selected");

var editButton = $('.edit-button');
var deleteButton = $('.delete-button');
var altaButton = $('.extra');

if (selectedRows.length > 0) {
  editButton.prop('disabled', false);
  editButton.removeClass('disabled');
  deleteButton.prop('disabled', false);
  deleteButton.removeClass('disabled');
  altaButton.prop('disabled', false);
  altaButton.removeClass('disabled');

  if (selectedRows.length > 1) {
      editButton.prop('disabled', true);
      editButton.addClass('disabled');
      altaButton.prop('disabled', true);
      altaButton.addClass('disabled');
  }
} else {
  editButton.prop('disabled', true);
  editButton.addClass('disabled');
  deleteButton.prop('disabled', true);
  deleteButton.addClass('disabled');
  altaButton.prop('disabled', true);
  altaButton.addClass('disabled');
}
});
// Manejar clic en el botón de editar
$('.edit-button').click(function () {
var selectedRows = $("#example tbody tr.selected");

if (selectedRows.length == 0) {
  alert('Selecciona al menos una fila antes de editar.');
} else if (selectedRows.length > 1) {
  alert('Selecciona solo una fila para editar.');
} else {
  // Obtén los valores de las celdas de la fila seleccionada
  var pacienteID = selectedRows.find('td:eq(0)').text();
  var fechaPaciente = selectedRows.find('td:eq(1)').text();
  var horaPaciente = selectedRows.find('td:eq(2)').text();
  var idmedico = selectedRows.find('td:eq(3)').text();



  // Crea la URL con los parámetros
  const editUrl = `ActualizarPaciente.html?pacienteID=${pacienteID}&fechaPaciente=${formattedDate}&horaPaciente=${horaPaciente}&idmedico=${idmedico}&idpaciente=${idpaciente}`;

  // Redirige a la página del formulario de edición
  window.location.href = editUrl;
}
});

 // Manejar clic en el botón de dae de alta
 $('.extra').click(function () {
  var selectedRows = $("#example tbody tr.selected");
  
  if (selectedRows.length == 0) {
    alert('Debe seleccionar a que intermamiento le dara la alta');
  } else if (selectedRows.length > 1) {
    alert('Selecciona solo un internamiento.');
  } else {
    // Obtén los valores de las celdas de la fila seleccionada
    var pacienteID = selectedRows.find('td:eq(0)').text();
   // Crea la URL con los parámetros
    const editUrl = `ActualizarPaciente.html?pacienteID=${pacienteID}`;
  
    // Redirige a la página del formulario de edición
    window.location.href = editUrl;
  }
  });
  

 // Manejar clic en el botón de eliminar
 $('.delete-button').click(function () {
  var selectedRows = $("#example tbody tr.selected");
  
  if (selectedRows.length === 0) {
      alert('Selecciona al menos una fila antes de eliminar.');
  } else {
      var selectedIds = selectedRows.map(function () {
          return $(this).find('td:first-child').text();
      }).get();

      // Realizar solicitudes HTTP DELETE por cada ID
      selectedIds.forEach(function (id) {
          var apiUrl = `https://localhost:7286/eliminar-paciente?ID_Paciente=${id}`;

          fetch(apiUrl, {
              method: 'DELETE'
          })
          .then(response => {
              if (response.ok) {
                  // Eliminar fila de la tabla
                  table.row(selectedRows.filter(':contains(' + id + ')')).remove().draw(false);
              } else {
                  alert('Error al eliminar la paciente con ID ' + id);
              }
          })
          .catch(error => {
              console.error('Error en la solicitud para eliminar la paciente con ID ' + id + ':', error);
          });
      });
  }
});

});

const btnAdd = document.getElementById('btnAdd');

btnAdd.addEventListener('click', function() {
  window.location.href = '../HTML/RegistrarPaciente.html';
});