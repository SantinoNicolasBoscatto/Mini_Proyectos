using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(EmailDTO mail);
    }
    public class ServicioEmail:IServicioEmail
    {
        public IConfiguration Configuration { get; }
        public ServicioEmail(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task Enviar(EmailDTO mail)
        {
            var apiKey = Configuration.GetValue<string>("KeyApi");
            var nombre = Configuration.GetValue<string>("Send");
            var email = Configuration.GetValue<string>("Destinatario");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var to = new EmailAddress(email, nombre);
            var subject = "Contacto PortFolio";
            var plainTextContent = mail.Mensaje;
            var htmlContent = @$"Email: {mail.Email} <br/>Contactante: {mail.Nombre} <br/> Mensaje: {mail.Mensaje}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
