using System;

namespace IrsMonkeyApi.Models.Dto
{
    public class PaymentDTO
    {
        public MerchantAuthentication merchantAuthentication { get; set; }
        public string refId { get; set; }
        public TransactionRequest transactionRequest { get; set; }
    }

    public class MerchantAuthentication
    {
        public string name { get; set; }
        public string transactionKey { get; set; }
    }

    public class TransactionRequest
    {
        public string transactionType { get; set; }
        public string amount { get; set; }
        public Payment payment { get; set; }
        public LineItems lineItems { get; set; }
        public Tax tax { get; set; }
        public Duty duty { get; set; }
        public Shipping shipping { get; set; }
        public string poNumber { get; set; }
        public Customer customer { get; set; }
        public BillTo billTo { get; set; }
        public ShipTo shipTo { get; set; }
        public string customerIP { get; set; }
        public TransactionSettings transactionSettings { get; set; }
        public UserFields userFields { get; set; }
    }

    public class Payment
    {
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string cardCode { get; set; }
    }

    public class LineItem
    {
        public string itemId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string unitPrice { get; set; }
    }

    public class LineItems
    {
        public LineItem lineItem { get; set; }    
    }

    public class Tax
    {
        public string amount { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Duty
    {
        public string amount { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Shipping
    {
        public string amount { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Customer
    {
        public string id { get; set; }
    }

    public class BillTo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }

    public class ShipTo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }

    public class TransactionSettings
    {
        public Setting setting { get; set; }
    }

    public class Setting
    {
        public string settingName { get; set; }
        public string settingValue { get; set; }
    }

    public class UserFields
    {
            public UserField[] Type { get; set; }
    }

    public class UserField
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}