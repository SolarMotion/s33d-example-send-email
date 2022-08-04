using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Start send email");

                SendEmail();

                WriteLine("Finish send email");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Write("Press any key to exit");
                Read();
            }
        }

        private static void SendEmail()
        {
            var fromAddress = new MailAddress("solarmotion0106@gmail.com", "Chien");
            var toAddress = new MailAddress("weichienyap@seednet.com.my", "Test User");
            const string fromPassword = "Solar2.0..0";
            const string subject = "test";
            const string body = "Hey now!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000,               
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })
            {
                smtp.Send(message);
            }
        }
    }
}
