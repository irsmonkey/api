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
        
        public PaymentResponseDto ChargeCreditCard(PaymentDTO paymentDetails, Guid memberId)
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
                var responseObject = new PaymentResponseDto();
                var streamResponse = response.GetResponseStream();
                var streamReader = new StreamReader(streamResponse, Encoding.UTF8);
                var resp = streamReader.ReadToEnd();
                var respObject = JsonConvert.DeserializeObject<PaymentResponseDto>(resp);
                responseObject = respObject;

                var order = _context.FormSubmitted.Where(form => form.MemberId == memberId).OrderByDescending(x => x.FormSubmittedId).FirstOrDefault();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        switch (respObject.transactionResponse.responseCode)
                        {
                            case "1":
                                order.FormSubmitedStatusId = 3;
                                _context.SaveChanges();
                                break;
                            case "3":
                                order.FormSubmitedStatusId = 4;
                                _context.SaveChanges();
                                break;
                        }

                        break;
                    case HttpStatusCode.BadRequest:
                        throw new Exception("There was an error");
                }
                return responseObject;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}