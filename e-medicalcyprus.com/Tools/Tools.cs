using System.Net.Mail;
using System.Net;

namespace e_medicalcyprus.com
{
    public class Tools
    {
        public static void SendEmail(MailMessage message)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", 
                optional: true, 
                reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string username = configuration["UserName"];
            string password = configuration["Password"];

            using (var client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.Host = "smtp.office365.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(
                    username,
                    password);
                client.Send(message);
            }
        }
    }
}
