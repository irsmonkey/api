using System;
using System.Net;
using System.Threading.Tasks;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IPaymentGateway
    {
        HttpWebResponse ChargeCreditCard(PaymentDTO paymentDetails, Guid memberId);
    }
}