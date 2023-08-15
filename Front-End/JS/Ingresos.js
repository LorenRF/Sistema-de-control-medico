$(document).ready(function () {
  let columnIndex
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
    fetch('https://localhost:7286/obtener-ingreso')
.then(response => response.json())
.then(apiResponse => {
  apiResponse.forEach(ingreso => {
    if (ingreso.estatus === "Activo") {
      const fechaIngreso = new Date(ingreso.ingresado);
      const fechaFormato = `${fechaIngreso.getFullYear()}/${(fechaIngreso.getMonth() + 1).toString().padStart(2, '0')}/${fechaIngreso.getDate().toString().padStart(2, '0')}`;
      const horaFormato = `${fechaIngreso.getHours().toString().padStart(2, '0')}:${fechaIngreso.getMinutes().toString().padStart(2, '0')}`;

      table.row.add([
        ingreso.iD_Ingreso,
        fechaFormato,
        horaFormato,
        ingreso.numero,
        ingreso.iD_Habitacion,
        ingreso.tipo,
        ingreso.iD_Paciente,
        ingreso.paciente
      ]).draw();
    }
  });
})
.catch(error => {
  console.error('Error al obtener datos de la API:', error);
});
    $("#example thead").on("keyup change", "input, select", function () {
if ($(this).is("select")) {
   columnIndex = $(this).parent().index();
  const filterValue = $(this).val();
  
  
    table.column(columnIndex).search(filterValue).draw();
  
} else {
  table.column($(this).parent().index()).search(this.value).draw();
  columnIndex = $(this).parent().index();

}
});


// Asociar evento 'search.dt' a la tabla para habilitar/deshabilitar el select de funciones
table.on('search.dt', function() {
  var filtrosAplicados = table.columns().search().reduce(function (acc, val) {
    return val ? acc + 1 : acc;
  }, 0);

  $("#funcion").prop("disabled", filtrosAplicados === 0);
  if (filtrosAplicados === 0) {
    $("#fresultado").hide();
  } else {
    $("#fresultado").show();
  }
  // Obtener la columna visible con filtro
  console.log(columnIndex)
  // Obtener la función seleccionada
  const selectedFunction = $("#funcion").val();
  
  if (selectedFunction && columnIndex >= 0) {
    const result = calcularResultado(selectedFunction, columnIndex);
    mostrarResultado(result);
  } else {
    mostrarResultado('');
  }
});

// Manejar el evento de cambio en el select de funciones
$("#funcion").on("change", function() {
  const selectedFunction = $(this).val();
  
  if (selectedFunction && columnIndex >= 0) {
    const result = calcularResultado(selectedFunction, columnIndex);
    mostrarResultado(result);
  } else {
    mostrarResultado('');
  }
});

// Función para calcular el resultado según la función seleccionada
function calcularResultado(selectedFunction, columnIndex) {
  const numericData = obtenerNumericData(columnIndex);
  const info = table.page.info();
  const rowsDisplayed = info.end - info.start; // Número de filas visibles


  if (numericData.length === 0 && selectedFunction != 'count' ) {
    return 'No hay datos compatibles en esta columna';
  }

  if ([0, 3, 4, 6].includes(columnIndex)){
    switch (selectedFunction) {

        case 'count':
          return rowsDisplayed; // Cantidad de filas visibles
        case 'max':
        return calcularMaximo(numericData);
      case 'min':
        return calcularMinimo(numericData);
      default:
        return 'No hay datos compatibles en esta columna';
    }
  }

  switch (selectedFunction) {
    case 'sum':
      return calcularSuma(numericData);
      case 'count':
        return rowsDisplayed; // Cantidad de filas visibles
    case 'average':
      return numericData.reduce((acc, value) => acc + value, 0) / numericData.length;
    case 'max':
      return calcularMaximo(numericData);
    case 'min':
      return calcularMinimo(numericData);
    default:
      return '';
  }
}

// Función para calcular el máximo de los datos numéricos
function calcularMaximo(numericData) {
  const maximo = Math.max.apply(null, numericData);
  return  maximo;
}

// Función para calcular el mínimo de los datos numéricos
function calcularMinimo(numericData) {
  const minimo = Math.min.apply(null, numericData);
  return minimo;
}

// Función para calcular la suma de los datos numéricos
function calcularSuma(numericData) {
  const suma = numericData.reduce((acc, value) => acc + value, 0);
  return suma;
}

// Función para obtener los datos numéricos después del filtrado
function obtenerNumericData(columnIndex) {
  const data = table.column(columnIndex, { search: 'applied' }).data();

  const numericData = data.map((value, index) => {
    if (!isNaN(value) && String(value).indexOf("/") === -1 && String(value).indexOf(":") === -1) {
      return parseFloat(value);
    }
    return NaN;
  }).filter(value => !isNaN(value));

  return numericData;
}




// Función para mostrar el resultado en el elemento <p>
function mostrarResultado(result) {
  $("#fresultado").text(result);
}


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
  var ingresoID = selectedRows.find('td:eq(0)').text();
  var fechaIngreso = selectedRows.find('td:eq(1)').text();
  var horaIngreso = selectedRows.find('td:eq(2)').text();
  var idmedico = selectedRows.find('td:eq(4)').text();
  var idpaciente = selectedRows.find('td:eq(6)').text();

  
    // Formatea la fecha en el formato "yyyy-MM-dd"
    var formattedDate = new Date(fechaIngreso).toISOString().split('T')[0];


  // Crea la URL con los parámetros
  const editUrl = `ActualizarIngreso.html?ingresoID=${ingresoID}&fechaIngreso=${formattedDate}&horaIngreso=${horaIngreso}&idmedico=${idmedico}&idpaciente=${idpaciente}`;

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
    var ingresoID = selectedRows.find('td:eq(0)').text();
   // Crea la URL con los parámetros
    const editUrl = `RegistrarAlta.html?ingresoID=${ingresoID}`;
  
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
          var apiUrl = `https://localhost:7286/eliminar-ingreso?ID_Ingreso=${id}`;

          fetch(apiUrl, {
              method: 'DELETE'
          })
          .then(response => {
              if (response.ok) {
                  // Eliminar fila de la tabla
                  table.row(selectedRows.filter(':contains(' + id + ')')).remove().draw(false);
              } else {
                  alert('Error al eliminar la ingreso con ID ' + id);
              }
          })
          .catch(error => {
              console.error('Error en la solicitud para eliminar la ingreso con ID ' + id + ':', error);
          });
      });
  }
});

});

const btnAdd = document.getElementById('btnAdd');

btnAdd.addEventListener('click', function() {
  window.location.href = '../HTML/RegistrarIngreso.html';
});