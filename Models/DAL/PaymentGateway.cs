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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Order = IrsMonkeyApi.Models.DB.Order;

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
                //var parsedBody = new System.Xml.Serialization.XmlSerializer(paymentDetails.GetType()).ToString();
                var content = new StringContent(parsedBody, Encoding.UTF8, "t/json");
                
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

                var formSubmitted = _context.FormSubmitted.Where(form => form.MemberId == memberId).OrderByDescending(x => x.FormSubmittedId).FirstOrDefault();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        switch (respObject.transactionResponse.responseCode)
                        {
                            case "1":
                                using (var transaction = _context.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        //Lets save the order
                                        var order = new Order
                                        {
                                            MemberId = memberId,
                                            OrderStatusId = 1,
                                            OrderDate = DateTime.Now,
                                            OrderTotal = decimal.Parse(paymentDetails.createTransactionRequest
                                                .transactionRequest.amount),
                                            PaymentTypeId = 1
                                        };
                                        _context.Order.Add(order);
                                        _context.SaveChanges();
                                        //lets save the line items
                                        foreach (var lineItem in paymentDetails.createTransactionRequest.transactionRequest.lineItems.lineItem)
                                        {
                                            var orderItem = new OrderItem
                                            {
                                                OrderId = order.OrderId,
                                                ItemId = int.Parse(lineItem.itemId),
                                                Price = decimal.Parse(lineItem.unitPrice),
                                                Quantity = int.Parse(lineItem.quantity)
                                            };
                                            _context.OrderItem.Add(orderItem);
                                            _context.SaveChanges();
                                            _context.Entry(orderItem).State = EntityState.Detached;
                                        }
                                        // lets save the status of the form
                                        formSubmitted.FormSubmitedStatusId = 3;
                                        _context.SaveChanges();
                                        transaction.Commit();
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception(e.Message);
                                    }
                                    break;
                                }
                            case "3":
                                formSubmitted.FormSubmitedStatusId = 4;
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