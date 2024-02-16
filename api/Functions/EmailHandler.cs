using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
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

            string name = data?.name;
            string email = data?.email;
            string phone = data?.phone;
            string message = data?.message;

            // Construct the email body with the provided information
            string emailBody = $"Name: {name}\nEmail: {email}\nPhone: {phone}\nMessage: {message}";

            var client = new MailjetClient("67bc2e6661e4ed5105d466b2f0a93e0f", "d82e31b295c8f89ae0e60f958b485b40");

            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.Messages, new JArray {
        new JObject {
            {"From", new JObject {
                {"Email", "aaron_evans@outlook.com"},
                {"Name", "Affordable Windscreens"}
            }},
            {"To", new JArray {
                new JObject {
                    {"Email", "aaron_evans@outlook.com"}, // Admin or target recipient email
                    {"Name", "Affordable Windscreens"}
                }
            }},
            {"Subject", "New Message Received"},
            {"TextPart", emailBody},
            {"HTMLPart", $"<p>{emailBody.Replace("\n", "<br>")}</p>"}
        }
            });

            MailjetResponse response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                log.LogInformation("Email sent successfully.");
                return new OkObjectResult("Email sent successfully.");
            }
            else
            {
                log.LogError($"Failed to send email. Status: {response.StatusCode} Reason: {response.GetErrorMessage()}");
                return new BadRequestObjectResult($"Failed to send email. Status: {response.StatusCode} Reason: {response.GetErrorMessage()}");
            }
        }
    }
}
