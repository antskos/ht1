using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ht1
{
    public class EmailSendServiceClass : IDisposable
    {
        private MailMessage mm;
        
        // c-tor
        public EmailSendServiceClass() 
        {
            mm = new MailMessage();
        }

        public void DefineMailFromTo(string mailSender, string mailRecipients)
        {
            foreach (var address in mailRecipients.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mm.To.Add(address);
            }
            mm.From = new MailAddress(mailSender);
         }

        public void CreateMailText(string mailSubject = "no name", string mailBody = "empty message")
        {
            mm.Subject = mailSubject;
            mm.Body = mailBody;
            mm.IsBodyHtml = false;          // Не используем html в теле письма
        }

        public void SendMail(string password)
        {
            string tmpStr = mm.From.Address;
            string dictKey = "smtp." + tmpStr.Substring(tmpStr.IndexOf('@') + 1);

            // Авторизуемся на smtp-сервере и отправляем письмо
            SmtpClient sc = new SmtpClient(dictKey, MailInfo.mailServers[dictKey]);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential(tmpStr, password);
            sc.Send(mm);
        }

        public void Dispose()
        {
            ((IDisposable)mm).Dispose();
        }
    }
}
