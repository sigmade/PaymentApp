using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("send")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> NewPay([FromBody] NewPayRequest req, CancellationToken cancellationToken)
        {
            await _paymentService.Handle(new() { Phone = req.Phone, Amount = req.Amount }, cancellationToken);

            return NoContent();
        }
    }
}
