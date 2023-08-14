$(document).ready(function () {
  // Only needed for the filename of export files.
  // Normally set in the title tag of your page.
  document.title = "Simple DataTable";

  // Create search inputs in footer
  $("#example tfoot th").each(function () {
      var title = $(this).text();
      if (title === "estatus") {
        $(this).html('<select><option value="Activo">Activo</option><option value="Inactivo">Inactivo</option><option value="">All</option></select>');
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
    fetch('https://localhost:7286/obtener-altas')
.then(response => response.json())
.then(apiResponse => {
  apiResponse.forEach(alta => {
    if (alta.estatus === "Activo") {
      const fechaIngreso = new Date(alta.ingresado);
      const fechaFormato = `${fechaIngreso.getFullYear()}/${(fechaIngreso.getMonth() + 1).toString().padStart(2, '0')}/${fechaIngreso.getDate().toString().padStart(2, '0')}`;
      const horaFormato = `${fechaIngreso.getHours().toString().padStart(2, '0')}:${fechaIngreso.getMinutes().toString().padStart(2, '0')}`;
      const fechahAlta = new Date(alta.ingresado);
      const fechaAlta = `${fechahAlta.getFullYear()}/${(fechahAlta.getMonth() + 1).toString().padStart(2, '0')}/${fechahAlta.getDate().toString().padStart(2, '0')}`;
      const horaAlta = `${fechahAlta.getHours().toString().padStart(2, '0')}:${fechahAlta.getMinutes().toString().padStart(2, '0')}`;

      table.row.add([
        alta.iD_Alta,
        fechaFormato,
        horaFormato,
        fechaAlta,
        horaAlta,
        alta.paciente,
        alta.iD_Paciente,
        alta.habitacion,
        alta.iD_Habitacion,
        alta.pago
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
  var altaID = selectedRows.find('td:eq(0)').text();
  var fechaAlta = selectedRows.find('td:eq(1)').text();
  var horaAlta = selectedRows.find('td:eq(2)').text();
  var pago = selectedRows.find('td:eq(9)').text();

  
    // Formatea la fecha en el formato "yyyy-MM-dd"
    var formattedDate = new Date(fechaAlta).toISOString().split('T')[0];


  // Crea la URL con los parámetros
  const editUrl = `ActualizarAlta.html?altaID=${altaID}&fechaAlta=${formattedDate}&horaAlta=${horaAlta}&pago=${pago}`;

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
          var apiUrl = `https://localhost:7286/eliminar-alta?ID_Alta=${id}`;

          fetch(apiUrl, {
              method: 'DELETE'
          })
          .then(response => {
              if (response.ok) {
                  // Eliminar fila de la tabla
                  table.row(selectedRows.filter(':contains(' + id + ')')).remove().draw(false);
              } else {
                  alert('Error al eliminar la alta con ID ' + id);
              }
          })
          .catch(error => {
              console.error('Error en la solicitud para eliminar la alta con ID ' + id + ':', error);
          });
      });
  }
});

});

const btnAdd = document.getElementById('btnAdd');

btnAdd.addEventListener('click', function() {
  window.location.href = '../HTML/Ingresos.html';
});