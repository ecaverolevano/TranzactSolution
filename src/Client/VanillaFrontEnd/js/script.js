$(document).ready(function() {

    // Menu item click event handler
  $('nav ul.menu li a').click(function(e) {
    e.preventDefault();  // Prevenir comportamiento predeterminado del enlace
    
    var pageUrl = $(this).attr('href');  
    var jsFile = $(this).data('js'); 
    var cssFile = $(this).data('css');

    // Cargar contenido HTML parcial mediante AJAX
    $.ajax({
      url: pageUrl,
      method: 'GET',
      success: function(response) {
        // Poblar el contenedor de contenido con el HTML recuperado
        $('#contentContainer').html(response);

        // Cargar archivo JavaScript asociado dinámicamente
        loadScript(jsFile);

        // Cargar archivo CSS asociado dinámicamente
        loadCSS(cssFile);
      },
      error: function(xhr, status, error) {
        console.log('Error:', status, error, xhr);
      }
    });
  });

  // Función para cargar archivos JavaScript dinámicamente
  function loadScript(file) {
    var script = document.createElement('script');
    script.src = '/js/' + file;
    document.head.appendChild(script);
  }

  // Función para cargar archivos CSS dinámicamente
function loadCSS(file) {
    var link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = '/css/' + file;
    document.head.appendChild(link);
  }
   
  });
  