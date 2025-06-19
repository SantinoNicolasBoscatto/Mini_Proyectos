using System.Net;
using System.Net.Mail;

MailAddress adressFrom = new MailAddress("santinopesyfifa@gmail.com", "Santino");
MailAddress addressTo = new MailAddress("santinoboscatto05@gmail.com");

MailMessage message = new MailMessage(adressFrom, addressTo);
message.Subject = "Test de envio de e-mail";
message.Body = "Texto de prueba";
message.IsBodyHtml = true;

SmtpClient client = new SmtpClient("smtp.gmail.com");
client.Port = 587;
client.EnableSsl = true;
client.UseDefaultCredentials = false;
client.Credentials = new NetworkCredential("santinopesyfifa@gmail.com", "accl zrfe jumt aubg");

try
{
    client.Send(message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}