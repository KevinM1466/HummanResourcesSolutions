using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailServices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail() {
            senderMail = "noramartinez14@hotmail.com";
            password = "Kevin1978";
            host = "smtp-mail.outlook.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
