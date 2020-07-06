using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class MailInfo
    {
        // dictionary contains mail server name as a key, and server port as a value
        public static Dictionary<string, int> MailServers { get; private set; } = new Dictionary<string, int>
        {
            { "smtp.yandex.ru", 25 },
            { "smtp.mail.ru", 25 },
            { "smtp.gmail.com", 587 }
        };

    }
}
