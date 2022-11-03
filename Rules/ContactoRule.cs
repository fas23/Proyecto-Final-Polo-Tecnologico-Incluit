using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Proyecto_Final_Polo_Tecnologico_Incluit.Rules
{
    public class ContactoRule
    {
        private readonly IConfiguration _configuration;
     
        public ContactoRule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string emailTo, string mensaje, string asunto, string ? deQuien)
        {
            var from = _configuration["Email:fromEmail"];
            var fromName = deQuien ?? _configuration["Email: fromName"];

            //crear el mensaje
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromName, from));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = asunto;
            email.Body = new TextPart(TextFormat.Html) { Text = mensaje };

            //enviar mensaje

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["Email: smptServer"], int.Parse(_configuration["Email:smptPort"]));
            smtp.Authenticate(_configuration["Email:fromEmail"], _configuration["Email: password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
            
        }
    }
}
