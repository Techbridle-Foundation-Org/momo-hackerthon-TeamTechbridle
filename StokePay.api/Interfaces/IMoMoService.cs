
using StokePay.api.Models;

namespace StokePay.api.Interfaces;


   public interface IMoMoService
{
    Task<string> GetAccessTokenAsync();
    Task<string> RequestPaymentAsync(PaymentRequestDto request);
    Task<string> RequestWithdrawAsync(WithdrawalRequestDto request);
    Task<string> GetTransactionStatusAsync(string referenceId);
}



