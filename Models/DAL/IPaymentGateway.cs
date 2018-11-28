using System;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IPaymentGateway
    {
        bool AuthorizePayment(string ApiLoginId, string ApiTransactionKey, decimal amount);
    }
}