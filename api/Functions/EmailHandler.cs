using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace affordable_windscreens.Functions
{
    public static class EmailHandler
    {
        [FunctionName("EmailHandler")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "email")] HttpRequest req,
        ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var client = new SendGridClient("mlsn.d3bff8e80d7cc86604efb105fa35ae70ca8b87852b1ba444dac039073127679a");
            var from = new EmailAddress("aaron_evans@outlook.com", "Aaron");
            var subject = "New Contact Form Submission";
            var to = new EmailAddress("aaron_evans@outlook.com", "Aaron");
            var plainTextContent = $"Message from {data.name}: {data.message}";
            var htmlContent = $"<strong>Message from {data.name}:</strong><p>{data.message}</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            return new OkObjectResult("Email sent");
        }
    }
}
