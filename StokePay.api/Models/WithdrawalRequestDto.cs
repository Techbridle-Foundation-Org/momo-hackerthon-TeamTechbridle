using System;

namespace StokePay.api.Models;

public class WithdrawalRequestDto
{
    public string PayeeNote { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public PayerDto Payer { get; set; } = new PayerDto();
    public string PayerMessage { get; set; } = string.Empty;
}
