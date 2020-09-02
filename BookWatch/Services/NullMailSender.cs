using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Services
{
    public class NullMailSender : IMailSender
    {
        private readonly ILogger<NullMailSender> _logger;

        public NullMailSender(ILogger<NullMailSender> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            // Log the message
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
