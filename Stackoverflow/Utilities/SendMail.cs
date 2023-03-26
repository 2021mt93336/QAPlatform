using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StackOverflow.Utilities
{
    public class SendMail
    {
        public static bool MailUser(string message,string To,string CC,string Subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(To);
                if(CC != "")
                    mailMessage.CC.Add(CC);
                mailMessage.From = new MailAddress("bphanipranav@micron.com");
                mailMessage.Subject = Subject;
                mailMessage.Body = message;
                new SmtpClient("relay.micron.com", 25).Send(mailMessage);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return false;
            }
        }

    }
}
