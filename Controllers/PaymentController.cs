using System;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IrsMonkeyApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentGateway _dal;

        public PaymentController(IPaymentGateway dal)
        {
            _dal = dal;
        }
        
        [Route("chargeCard"), HttpPost]
        public IActionResult Index([FromBody] PaymentDTO paymentDetails, [FromQuery(Name = "memberId")] Guid memberId)
        {
            try
            {
                var payment = _dal.ChargeCreditCard(paymentDetails, memberId);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}