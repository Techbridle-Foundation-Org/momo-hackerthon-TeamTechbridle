using System;
using StokePay.api.Models;

namespace StokePay.api.Models;

public class PaymentRequestDto
{
        public string Amount { get; set; } = string.Empty; 
        public string Currency { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public PayerDto Payer { get; set; } = new();     
        public string PayerMessage { get; set; } = string.Empty;
        public string PayeeNote { get; set; } = string.Empty;
}


