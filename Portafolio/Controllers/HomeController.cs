using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;
using System.Reflection;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {   //necesario para la inyeccion de dependencias
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioproyectos repositorioProyectos;
        private readonly HomeIndexViewModel home;
        private readonly IServicioEmailSendGrid servicioemail;

        //inyeccion de dependencias, recuerda que primero tenemos que agregarlas en el archivo Program.cs
        public HomeController(
            ILogger<HomeController> logger, 
            IRepositorioproyectos repositorioProyectos, 
            HomeIndexViewModel home,
            IServicioEmailSendGrid servicioemail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.home = home;
            this.servicioemail = servicioemail;
        }

        //aca enviando datos hacia la vista Index
        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            /*El ViewBag se utiliza para enviar informacion hacia la view en este caso a la view Index.cshtml*/
            ViewBag.Nombre = "Joseph Rojas";
            /*Esta es otra forma de enviar informacion a la view, dentro de view ponemos el objeto que estamos
             enviando desde la clase persona que esta en la carpeta Models"*/
            return View(modelo);
        }



        //aca enviando datos hacia la vista Proyectos
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View(modelo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //este atributo para el metodo,dice que esta enviando datos a la vista
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        //este atributo para el metodo, dice que este se va a ejecutar cuando recibamos un httpost
        //hacia home/contacto
        [HttpPost]
        //Este metodo recive una clase ContactoViewModel (que esta creada en la carpeta Models)
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioemail.Enviar(contactoViewModel);
            //redirige a la vista Gracias
            return RedirectToAction("Gracias");
        }
        [HttpGet]
        public IActionResult Gracias()
        {
            return View("Gracias");
        }
    }
}
