namespace IrsMonkeyApi.Models.Dto
{
    public class PaymentResponseDto
    {
        public TransactionResponse transactionResponse { get; set; }
    }

    public class TransactionResponse
    {
        public string responseCode { get; set; }
        public string authCode { get; set; }
        public string avsResultCode { get; set; }
        public string cvvResultCode { get; set; }    
        public string transID { get; set; }
        public string refTransId { get; set; }
        public string transHash { get; set; }
        public string testRequest { get; set; }
        public string accountNumber { get; set; }
        public string accountType { get; set; }
        public Message[] messages { get; set; }
        public string transHashSha2 { get; set; }
        public int SupplementalDataQualificationIndicator { get; set; }
    }

    public class Message
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Messages
    {
        public string resultCode { get; set; }
        public Message2 message { get; set; }
    }

    public class Message2
    {
        public string code { get; set; }
        public string text { get; set; }
    }
}