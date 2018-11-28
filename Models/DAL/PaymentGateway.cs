using System;
using IrsMonkeyApi.Controllers;

namespace IrsMonkeyApi.Models.DAL
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool AuthorizePayment(string apiLoginId, string apiTransactionKey, decimal amount)
        {
            return true;
        }
    }
}