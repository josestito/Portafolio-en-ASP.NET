using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmailSendGrid
    {
        Task Enviar(ContactoViewModel contacto);
    }
    public class ServicioEmailSendGrid : IServicioEmailSendGrid
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var apykey = configuration.GetValue<String>("SENDGRID_API_KEY");
            var email = configuration.GetValue<String>("SENDGRID_FROM");
            var nombre = configuration.GetValue<String>("SEND_NOMBRE");

            var cliente = new SendGridClient(apykey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensaTextoPlano = contacto.Mensaje;
            var contenidoHtml = $@"De: {contacto.Nombre} 
            Email: {contacto.Email} 
            mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from,to, subject, mensaTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
