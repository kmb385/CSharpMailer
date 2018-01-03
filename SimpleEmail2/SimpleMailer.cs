using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;


namespace SimpleEmail2
{
    class SimpleMailer
    {

        private MailAddress fromMailAddress { get; set; }
        private MailAddress toMailAddress { get; set; }

        private int port = Int32.Parse(ConfigurationManager.AppSettings.Get("port"));
        private string host = ConfigurationManager.AppSettings.Get("host");
        private string user = ConfigurationManager.AppSettings.Get("user");
        private string password = ConfigurationManager.AppSettings.Get("password");

        private string subject { get; set; }
        private string body { get; set; }

        SmtpClient smtpClient = new SmtpClient();

        public SimpleMailer()
        {
            smtpClient.Port = port;
            smtpClient.Host = host;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(user, password);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void send(MailMessage message)
        {
            try
            {
                smtpClient.Send(message);
            } catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(message != null)
                {
                    message.Dispose();
                }
            }
        }

    }
}
