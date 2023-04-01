using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration _emailConfig;

		public EmailSender(EmailConfiguration emailConfig)
		{
			_emailConfig = emailConfig;
		}

		public void SendEmail(Message message) 
		{ 
			var emailMessage = CreateEmailMessage(message);
			Send(emailMessage);
		}

		public async Task SendEmailAsync(Message message)
		{
			var emailMessage = CreateEmailMessage(message);
			await SendAsync(emailMessage);
		}

		private MimeMessage CreateEmailMessage(Message message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(MailboxAddress.Parse(_emailConfig.From));
			emailMessage.To.Add(MailboxAddress.Parse(message.To));
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

			return emailMessage;
		}

		private void Send(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

					client.Send(mailMessage);
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

		private async Task SendAsync(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

					await client.SendAsync(mailMessage);
				}
				catch (Exception)
				{

					throw;
				}
				finally
				{
					await client.DisconnectAsync(true);
					client.Dispose();
				}
			}
		}
	}
}
