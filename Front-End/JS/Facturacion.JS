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
    const columnIndex = $(this).parent().index();
    const filterValue = $(this).val();
    
    
      table.column(columnIndex).search(filterValue).draw();
    
  } else {
    table.column($(this).parent().index()).search(this.value).draw();
  }
  });
  