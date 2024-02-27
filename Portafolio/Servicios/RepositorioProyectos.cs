using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioproyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    //creacion de interfaces para RepositorioProyectos
    public class RepositorioProyectos : IRepositorioproyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core",
                    Link = "https://Amazon.com",
                    ImagenURL = "/imagenes/amazon.PNG"
                },
                new Proyecto
                {
                    Titulo = "New york time",
                    Descripcion = "Pagina de noticias en React",
                    Link = "https://nytimes.com",
                    ImagenURL = "/imagenes/nyt.PNG"
                },
                new Proyecto
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://Reddit.com",
                    ImagenURL = "/imagenes/reddit.PNG"
                },
                new Proyecto
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para compra de videojuegos",
                    Link = "https://store.steampowered.com",
                    ImagenURL = "/imagenes/steam.PNG"
                }

            };
        }
    }
}
