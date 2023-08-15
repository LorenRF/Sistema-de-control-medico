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
    fetch('https://localhost:7286/obtener-habitacion')
.then(response => response.json())
.then(apiResponse => {
  apiResponse.forEach(ingreso => {
    if (ingreso.estatus === "Activo") {

      table.row.add([
        ingreso.iD_Habitacion,
        ingreso.numero,
        ingreso.tipo,
        ingreso.precio,

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


  if (numericData.length === 0 && selectedFunction != 'count') {
    return 'No hay datos numéricos en esta columna';
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

  const numericData = data.map(value => {
    if (!isNaN(value) && !value.includes("/") && !value.includes(":")) {
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

});
