using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for MAILER
/// </summary>
public class MAILER
{
    public class _MAILER
    {
        public string EmailReturn()
        {
            string[] email = { "1@xx.com", "2@xx.com" };
            Random rnd = new Random();

            return email[rnd.Next(0, 2)].ToString();
        }
        public string Send_Mail(string To, string Nm, string Subject, string CC, string BCC, string Body, string Msg_To)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                string Mail2 = "";
                string FooterImg = "";
                if (Msg_To == "Client")
                {
                    Mail2 = To;
                }
                else if (Msg_To == "Admin")
                {
                    Mail2 = "mukhtar@stateofart.biz";
                }
                System.Net.NetworkCredential basicCrenntial = new System.Net.NetworkCredential("mukhtar@stateofart.biz", "Admin@2012");
                MailAddress fromAddress = new MailAddress("mukhtar@stateofart.biz", "www.stateofart.biz", System.Text.Encoding.UTF8);
                smtpClient.Port = 80;
                //smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.asia.secureserver.net";
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = basicCrenntial;
                message.From = fromAddress;//here you can set address      
                message.To.Add(Mail2);//here you can add multiple to
                message.Subject = Subject;//subject of email
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Priority = MailPriority.High;
                if (CC != "")
                {
                    message.CC.Add(CC);//ccing the same email to other email address
                }
                if (BCC != "")
                {
                    message.Bcc.Add(new MailAddress(BCC));//here you can add bcc address
                }
                message.IsBodyHtml = true;//To determine email body is html or not
                message.Body = @Body + FooterImg;
                smtpClient.Send(message);
                return "Sent";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw exception here you can write code to handle exception here
            }
        }


        public string Send_Mail_withAttachment(string To, string Nm, string Subject, string CC, string BCC, string Body, string Msg_To, Attachment AttachmentFile)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                string Mail2 = "";
                string FooterImg = "";
                if (Msg_To == "Client")
                {
                    Mail2 = To;
                }
                else if (Msg_To == "Admin")
                {
                    Mail2 = "";
                }
                System.Net.NetworkCredential basicCrenntial = new System.Net.NetworkCredential(EmailReturn(), "Admin@2014");
                MailAddress fromAddress = new MailAddress("info@xx.com", "www.xx.com", System.Text.Encoding.UTF8);
                //smtpClient.Port = 587;
                //smtpClient.EnableSsl = true;
                smtpClient.Host = "mail.xx.org";
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = basicCrenntial;
                message.From = fromAddress;//here you can set address      
                message.To.Add(Mail2);//here you can add multiple to
                message.Subject = Subject;//subject of email
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Priority = MailPriority.High;
                if (CC != "")
                {
                    message.CC.Add(CC);//ccing the same email to other email address
                }
                if (BCC != "")
                {
                    message.Bcc.Add(new MailAddress(BCC));//here you can add bcc address
                }

                message.Attachments.Add(AttachmentFile);
                message.IsBodyHtml = true;//To determine email body is html or not
                message.Body = @Body + FooterImg;
                smtpClient.Send(message);
                return "Sent";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw exception here you can write code to handle exception here
            }
        }
    }
}