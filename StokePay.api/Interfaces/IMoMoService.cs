using System;
using StokePay.api.Models;

namespace StokePay.api.Interfaces;

public interface IMoMoService
{
    Task<string> GetAccessTokenAsync();
    Task<string> RequestPaymentAsync(PaymentRequestDto model);
    Task<string> GetTransactionStatusAsync(string referenceId);
}

