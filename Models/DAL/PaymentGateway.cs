using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IrsMonkeyApi.Controllers;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Newtonsoft.Json;

namespace IrsMonkeyApi.Models.DAL
{
    public class PaymentGateway : IPaymentGateway
    {
        static HttpClient client = new HttpClient();
        private readonly IRSMonkeyContext _context;

        public PaymentGateway(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public HttpWebResponse ChargeCreditCard(PaymentDTO paymentDetails, Guid memberId)
        {
            try
            {
                var uri = new Uri("https://apitest.authorize.net/xml/v1/request.api");
                var parsedBody = JsonConvert.SerializeObject(paymentDetails).ToString();
                var content = new StringContent(parsedBody, Encoding.UTF8, "application/json");
                /*content.Headers.ContentLength = parsedBody.Length;
                var response = await client.PostAsJsonAsync(uri, content);
                response.EnsureSuccessStatusCode();
                var transaction = response;
                return true;*/
                
                var request = WebRequest.Create(uri) as HttpWebRequest;
                var postBytes = Encoding.ASCII.GetBytes(parsedBody);
                request.ContentLength = postBytes.Length;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = postBytes.Length;
                request.Expect = "application/json";
                request.GetRequestStream().Write(postBytes, 0, postBytes.Length);
                var response = request.GetResponse() as HttpWebResponse;
                var streamResponse = response.GetResponseStream();
                var streamReader = new StreamReader(streamResponse, Encoding.UTF8);
                var order = _context.FormSubmitted.FirstOrDefault(form => form.MemberId == memberId);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    if (order != null)
                    {
                        order.FormSubmitedStatus = new FormSubmittedStatus()
                        {
                            FormSubmittedStatusId = 2
                        };
                    }
                }else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    order.FormSubmitedStatus = new FormSubmittedStatus()
                    {
                        FormSubmittedStatusId = 3
                    };
                }
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}