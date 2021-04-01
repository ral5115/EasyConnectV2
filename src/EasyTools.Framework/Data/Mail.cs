using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.Framework.Data
{
    public class Mail
    {
        public SmtpClient ConfigureSmtp(MailMessage message, MailConfiguration conf)
        {
            bool defaultCredential = false;

            message.Sender = new MailAddress(conf.EmailUser);
            message.From = new MailAddress(conf.EmailUser);

            SmtpClient client = new SmtpClient(conf.EmailServer, int.Parse(conf.EmailPort));
            client.EnableSsl = conf.EmailEnableSSL;
            client.UseDefaultCredentials = defaultCredential;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(conf.EmailUser, Crypto.DecrytedString(conf.EmailPassword));
            return client;
        }

        public bool SendMail(MailConfiguration conf, string toAddress, string subject, string message, bool IsHtml)
        {
            try
            {
                System.Net.Mail.MailMessage mailmessage = new System.Net.Mail.MailMessage
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = IsHtml, //send a plain text mail
                    DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.Never
                };
                string[] adress = toAddress.Split(char.Parse(";"));
                if (adress != null && adress.Length > 0)
                {
                    bool first = true;
                    foreach (string item in adress)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            if (first)
                            {
                                mailmessage.To.Add(item);
                                first = false;
                            }
                            else
                                mailmessage.CC.Add(item);

                        }
                    }
                }

                Mail ms = new Mail();
                System.Net.Mail.SmtpClient client = ms.ConfigureSmtp(mailmessage, conf); //Create de SMTP client
                client.Send(mailmessage); //Try to send the email
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}