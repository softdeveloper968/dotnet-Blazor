using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Security.Claims;
using GaHealthcareNurses.Entity.ViewModels;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace GaHealthcareNurses.Entity.Common
{
    public class Utility
    {
                  /// <summary>
        /// This method is using for getting email template data
        /// </summary>
        /// <param name="xpath"></param>
        public static string GetEmailTemplateValue(string strPath, string xpath)
        {
            string strValue = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(strPath);
            XmlElement root = doc.DocumentElement;
            XmlNode node = doc.DocumentElement.SelectSingleNode(xpath);
            XmlNode childNode = node.ChildNodes[0];
            if (childNode is XmlCDataSection)
            {
                XmlCDataSection cdataSection = childNode as XmlCDataSection;
                strValue = cdataSection.Value.ToString();
            }
            else
            {
                strValue = childNode.Value.ToString();
            }
            return strValue;
        }


        /// <summary>
        /// This method is using to send email if mailtemplete is Stringbuilder type
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="reciverAddress"></param>
        /// <param name="body"></param>
        public static bool SendMailToUser(string subject, string reciverAddress, string body)
        {
            EmailViewModel emailViewModel = new EmailViewModel()
            {
                Subject = subject,
                EmailBody = body,
                Receiver = reciverAddress,
            };
            SendEmail(emailViewModel);
            return true;
        }


        /// <summary>
        /// Master method to send email for dynamic users
        /// </summary>
        /// <param name="emailModel"></param>
        public static bool SendEmail(EmailViewModel emailModel)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build().GetSection("Emails");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(root.GetSection("UserName").Value);
                mail.Subject = emailModel.Subject;
                mail.Body = emailModel.EmailBody;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                if (emailModel.ToEmail != null)
                {
                    foreach (var item in emailModel.ToEmail)
                    {
                        mail.To.Add(item);// root.GetSection("TestEmail").Value);
                    }
                }
                else
                {                   

                    if (!emailModel.Receiver.Contains(','))
                    {
                        mail.To.Add(emailModel.Receiver);
                    }
                    else
                    {
                        var splitReciver = emailModel.Receiver.Split(',');
                        foreach (var item in splitReciver)
                        {
                            mail.To.Add(item);

                        }
                    }
                }
                if (emailModel.CCEmail != null)
                {
                    foreach (var item in emailModel.CCEmail)
                    {
                        mail.CC.Add(item);// root.GetSection("TestEmail").Value);
                    }
                }
                if (emailModel.BCCEmail != null)
                {
                    foreach (var item in emailModel.BCCEmail)
                    {
                        mail.Bcc.Add(item);// root.GetSection("TestEmail").Value);
                    }
                }
                SmtpClient smtpclient = new SmtpClient(root.GetSection("SMTPClient").Value);
                NetworkCredential networkcredential = new NetworkCredential(root.GetSection("UserName").Value, root.GetSection("Password").Value);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = networkcredential;
                smtpclient.Port = Convert.ToInt32(root.GetSection("Port").Value);
                smtpclient.EnableSsl = true;
                try
                {
                    smtpclient.Send(mail);
                    return true;
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// To read Protector secret key connection from appsettings.json
        /// and serving it throughout the application, wherever required.
        /// </summary>
        /// <returns></returns>
        public static string GetProtectorKey()
        {
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                return root.GetSection("ProtectorKey").Value;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
