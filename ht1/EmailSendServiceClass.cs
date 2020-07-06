using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        private MailMessage mm;
        
        // c-tor
        public EmailSendServiceClass() => mm = new MailMessage();
        
        public void DefineMailFromTo(string mailSender, string mailRecipients)
        {
            // отправитель
            mm.From = new MailAddress(mailSender);

            //получатели
            foreach (var address in mailRecipients.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mm.To.Add(address);
            }
           
        }

        public void CreateMailText(string mailSubject = "no name", string mailBody = "empty message")
        {
            mm.Subject = mailSubject;
            mm.Body = mailBody;
            mm.IsBodyHtml = false;          // Не используем html в теле письма
        }

        public void SendMail(SecureString password)
        {
            string userName = mm.From.Address;
            string dictKey = "smtp." + userName.Substring(userName.IndexOf('@') + 1);       // отсылка почты с того же сервера на котором ящик

            // Авторизуемся на smtp-сервере и отправляем письмо
            using (SmtpClient client = new SmtpClient(dictKey, MailInfo.MailServers[dictKey]))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(userName, password);
                client.Send(mm);
            }
            mm.Dispose();
        }

    } // class EmailSendServiceClass

}
