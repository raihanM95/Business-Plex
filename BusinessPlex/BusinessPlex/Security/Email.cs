using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BusinessPlex.Security
{
    public class Email
    {
        public static void SendVarificationEmail(string Email, string link)
        {
            var fromEmail = new MailAddress("hospital.diu@gmail.com", "BusinessPlex");
            var ToEmail = new MailAddress(Email);
            var FormEmailPass = "amarbangla1";
            string Subject = "Your account successfully created";

            string body = "<br><br><br><b>Welcome!!</b>  <br>" +
                          "Successfully created your account. Please click on the link to active your account  " +
                          "<a href='" + link + "'><strong> click Here</strong></a> <br><br><br>" + link;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, FormEmailPass),
            };

            var message = new MailMessage(fromEmail, ToEmail);
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = body;
            smtp.Send(message);
        }
    }
}