using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace ABC_mall
{
    public class SendMailService
    {
        public IActionResult sendmessage(string recipentemail)
        {
            string from = "iinfra178@gmail.com";
            string password = "kzen otjh jwsl bgsc";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = "Wellcome";
            message.To.Add(new MailAddress(recipentemail));
            message.Body = "We Suspected Activity From Your Account";
            message.IsBodyHtml = true;
            var smtpclient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, password),
                EnableSsl = true,

            };
            smtpclient.Send(message);
            return new OkResult();

        }
    }
}
