using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using StokePay.api.Models;
using StokePay.api.Interfaces;

namespace StokePay.api.Services
{
    public class MoMoService : IMoMoService
    {
        private readonly HttpClient _http;
        private readonly MoMoSettings _settings;

        private string? _cachedToken;
        private DateTime _tokenExpiry;

        public MoMoService(HttpClient http, IOptions<MoMoSettings> options)
        {
            _http = http;
            _settings = options.Value;

            
            _http.BaseAddress = new Uri(_settings.BaseUrl.TrimEnd('/') + "/collection/");

           
            _http.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _settings.SubscriptionKey);
            _http.DefaultRequestHeaders.Add("X-Target-Environment", _settings.TargetEnv);
        }

       
        public async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _tokenExpiry)
                return _cachedToken;

            using var request = new HttpRequestMessage(HttpMethod.Post, "token/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _settings.AuthBasic);

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            _cachedToken = doc.RootElement.GetProperty("access_token").GetString()!;
            int expiresIn = doc.RootElement.GetProperty("expires_in").GetInt32();
            _tokenExpiry = DateTime.UtcNow.AddSeconds(expiresIn - 30); 

            return _cachedToken;
        }

       
        public async Task<string> RequestPaymentAsync(PaymentRequestDto model)
        {
            var token = await GetAccessTokenAsync();
            var referenceId = Guid.NewGuid().ToString();

            var requestBody = new
            {
                amount = model.Amount,
                currency = model.Currency,
                externalId = model.ExternalId,
                payer = new { partyIdType = model.Payer.PartyIdType, partyId = model.Payer.PartyId },
                payerMessage = model.PayerMessage,
                payeeNote = model.PayeeNote
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "v1_0/requesttopay");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("X-Reference-Id", referenceId);
            request.Headers.Add("X-Target-Environment", _settings.TargetEnv);
            request.Headers.Add("Ocp-Apim-Subscription-Key", _settings.SubscriptionKey);

            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"RequestPayment failed: {response.StatusCode} - {content}");

            return content;
        }

        public async Task<string> RequestWithdrawAsync(WithdrawalRequestDto request)
{
    var token = await GetAccessTokenAsync();
    var referenceId = Guid.NewGuid().ToString();

    var requestBody = JsonSerializer.Serialize(request);

    using var httpRequest = new HttpRequestMessage(HttpMethod.Post, "v1_0/requesttowithdraw")
    {
        Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
    };

    httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    httpRequest.Headers.Add("X-Reference-Id", referenceId);
    httpRequest.Headers.Add("X-Target-Environment", _settings.TargetEnv);
    httpRequest.Headers.Add("Ocp-Apim-Subscription-Key", _settings.SubscriptionKey);

    var response = await _http.SendAsync(httpRequest);
    var content = await response.Content.ReadAsStringAsync();

    if (!response.IsSuccessStatusCode)
        return $"Withdrawal failed: {response.StatusCode} - {content}";

    return content;
}



       
        public async Task<string> GetTransactionStatusAsync(string referenceId)
        {
            var token = await GetAccessTokenAsync();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"v1_0/requesttopay/{referenceId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("X-Target-Environment", _settings.TargetEnv);
            request.Headers.Add("Ocp-Apim-Subscription-Key", _settings.SubscriptionKey);

            var response = await _http.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"GetTransactionStatus failed: {response.StatusCode} - {content}");

            return content;
        }
    }
}
