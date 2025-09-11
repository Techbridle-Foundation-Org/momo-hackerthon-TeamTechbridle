using Microsoft.AspNetCore.Mvc;
using StokePay.api.Interfaces;
using StokePay.api.Models;
using StokePay.api.Services;
using System.Threading.Tasks;

namespace StokePay.api.Controllers
{
    [ApiController]
    [Route("api/momo")]
    public class MoMoController : ControllerBase
    {
        private readonly IMoMoService _momoService;

        public MoMoController(IMoMoService momoService)
        {
            _momoService = momoService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken()
        {
            try
            {
                var token = await _momoService.GetAccessTokenAsync();
                return Ok(new { success = true, accessToken = token });
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(502, new { success = false, error = httpEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("pay")]
public async Task<IActionResult> RequestPayment([FromBody] PaymentRequestDto model)
{
    if (string.IsNullOrEmpty(model.Amount) || string.IsNullOrEmpty(model.Payer?.PartyId))
        return BadRequest(new { message = "Amount and PayerNumber are required." });

    try
    {
        var response = await _momoService.RequestPaymentAsync(model);
        return Ok(new { success = true, data = response });
    }
    catch (HttpRequestException httpEx)
    {
        return StatusCode(502, new { success = false, error = httpEx.Message });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { success = false, error = ex.Message });
    }
}


        [HttpGet("status/{referenceId}")]
        public async Task<IActionResult> GetTransactionStatus(string referenceId)
        {
            if (string.IsNullOrEmpty(referenceId))
                return BadRequest(new { message = "Reference ID is required." });

            try
            {
                var response = await _momoService.GetTransactionStatusAsync(referenceId);
                return Ok(new { success = true, data = response });
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(502, new { success = false, error = httpEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
}
