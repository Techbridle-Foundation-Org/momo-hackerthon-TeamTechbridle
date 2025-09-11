using System;

namespace StokePay.api.Models;

public class PayerDto
{
        public string PartyIdType { get; set; } = "MSISDN";
        public string PartyId { get; set; } = string.Empty;
}