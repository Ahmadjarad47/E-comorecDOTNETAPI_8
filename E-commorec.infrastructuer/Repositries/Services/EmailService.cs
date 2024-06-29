

using E_commorec.core.Entity;
using E_commorec.core.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace E_commorec.infrastructuer.Repositries.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async void SendEmail(EmailModel email)
        {
            MimeMessage message = new MimeMessage();
            var from = configuration["EmailSetting:From"];
            message.From.Add(new MailboxAddress("It's Time to die", from));
            message.To.Add(new MailboxAddress(email.To, email.To));
            message.Subject = email.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = email.content // تعيين المحتوى مباشرة بدون string.Format
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(configuration["EmailSetting:Smtp"], int.Parse(configuration["EmailSetting:Port"]), true);
                    await client.AuthenticateAsync(configuration["EmailSetting:From"], configuration["EmailSetting:Password"]);
                    await client.SendAsync(message);


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
