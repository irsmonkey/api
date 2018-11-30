using System;
using System.Net;
using System.Threading.Tasks;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IPaymentGateway
    {
        PaymentResponseDto ChargeCreditCard(PaymentDTO paymentDetails, Guid memberId);
    }
}