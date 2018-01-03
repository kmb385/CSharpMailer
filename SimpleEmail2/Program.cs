using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SimpleEmail2
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerName = "Mrs. Warren";
            string medicationName = "Advil";
            string quantity = "3";
            string unitOfMeasure = "Boxes";

            MailAddress toAddress = new MailAddress("kmb385@gmail.com");
            MailAddress fromAddress = new MailAddress("kmb385@gmail.com");
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = $"New Medication Order for {customerName}";
            mailMessage.Body = "<p>A new order has arrived.</p>" +
                    $"<p>{customerName} has ordered {quantity} {unitOfMeasure} of {medicationName}";


            SimpleMailer mailer = new SimpleMailer();
            mailer.send(mailMessage);
        }
    }
}
