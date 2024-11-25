using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailUtils{
    public class MailUtils{
        // public static async Task<string> SendMail(string _from, string _to, string _subject,string _content){
        //     MailMessage mailMessage= new MailMessage(_from,_to, _subject, _content);
        //     mailMessage.BodyEncoding = Encoding.UTF8;
        //     mailMessage.SubjectEncoding = Encoding.UTF8;
        //     mailMessage.IsBodyHtml = true;
        //     mailMessage.ReplyToList.Add(new MailAddress(_from));
        //     mailMessage.Sender=new MailAddress(_from);
        //     using var smtpClient=new SmtpClient("localhost");
        //     try{
        //         await smtpClient.SendMailAsync(mailMessage);
        //         return "Gửi email thành công!";
        //     }
        //     catch(Exception ex){
        //         Console.WriteLine(ex.Message);
        //         return "Gửi email thất bại!";
        //     }
        // }
        public static async Task<string> SendGmail(string _from, string _to, string _subject,string _content,string _gmail,string _password){

            MailMessage mailMessage= new MailMessage(_from,_to, _subject, _content);

            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.ReplyToList.Add(new MailAddress(_from));
            mailMessage.Sender=new MailAddress(_from);

            using var smtpClient=new SmtpClient("smtp.gmail.com");

            smtpClient.Port=587;
            smtpClient.EnableSsl=true;
            smtpClient.Credentials=new NetworkCredential(_gmail,_password);

            try{
                await smtpClient.SendMailAsync(mailMessage);
                return "Gửi email thành công!";
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                return "Gửi email thất bại!";
            }
        }
    }
}