let arrow = document.querySelectorAll(".arrow");
for (var i = 0; i < arrow.length; i++) {
  arrow[i].addEventListener("click", (e)=>{
 let arrowParent = e.target.parentElement.parentElement;
 arrowParent.classList.toggle("showMenu");
  });
}

let sidebar = document.querySelector(".sidebar");
let sidebarBtn = document.querySelector(".bx-menu");
console.log(sidebarBtn);
sidebarBtn.addEventListener("click", ()=>{
  sidebar.classList.toggle("close");
});

// Lista de elementos de ejemplo
const búsqueda = ["Ver Citas", "Agendar una cita", "Ver Altas", "Registrar alta", "Ver ingresos", "Registrar ingreso", "Ver pacientes", "Registrar paciente", "Ver Medicos", "Registrar medico"];

const searchInput = document.getElementById("searchInput");
const searchResults = document.getElementById("searchResults");

searchInput.addEventListener("input", function() {
  const searchTerm = searchInput.value.toLowerCase();
  
  // Filtrar la lista de elementos basándose en el término de búsqueda
  const filteredItems = búsqueda.filter(item => item.toLowerCase().includes(searchTerm));
  
  // Limpiar los resultados anteriores
  searchResults.innerHTML = "";

  // Mostrar los elementos coincidentes debajo del input
  filteredItems.forEach(item => {
    const listItem = document.createElement("li");
    listItem.textContent = item;
    
    // Agregar un evento de clic para manejar la acción cuando se hace clic en un elemento
    listItem.addEventListener("click", function() {
      if (listItem.textContent === "Ver Citas") 
      {
        window.location.href = "Citas.html";
      }
      else if (listItem.textContent === "Agendar una cita")
      {
        window.location.href = "AgregarCita.html";
      }
      else if (listItem.textContent === "Ver Altas")
      {
        window.location.href = "Altas.html";

      }
      else if (listItem.textContent === "Registrar alta")
      {
        window.location.href = "RegistrarAlta.html";

      }
      else if (listItem.textContent === "Ver ingresos")
      {
        window.location.href = "Ingresos.html";

      }
      else if (listItem.textContent === "Registrar ingreso")
      {
        window.location.href = "RegistrarIngreso.html";

      }
      else if (listItem.textContent === "Ver pacientes")
      {
        window.location.href = "Pacientes.html";

      }
      else if (listItem.textContent === "Registrar paciente")
      {
        window.location.href = "RegistrarPaciente.html";

      }
      else if (listItem.textContent === "Ver Medicos")
      {
        window.location.href = "Medicos.html";

      }
      else if (listItem.textContent === "Registrar medico")
      {
        window.location.href = "RegistrarMedico.html";

      }

    });

    searchResults.appendChild(listItem);
  });

  // Mostrar u ocultar la lista de resultados según si hay resultados o no
  if (filteredItems.length > 0) {
    searchResults.style.display = "block";
  } else {
    searchResults.style.display = "none";
  }
});

// Agregar un evento para cerrar los resultados cuando se haga clic fuera de la lista
document.addEventListener("click", function(event) {
  if (!searchResults.contains(event.target) && event.target !== searchInput) {
    searchResults.style.display = "none";
  }
});
