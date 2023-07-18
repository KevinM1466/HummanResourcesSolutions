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
            senderMail = "soportebve@gmail.com";
            password = "svqqudoriknjfsru";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
