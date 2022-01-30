using Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("send")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> NewPay([FromBody] NewPayRequest request, CancellationToken cancellationToken)
        {
            await _paymentService.Handle(request.Phone, request.Amount, cancellationToken);

            return NoContent();
        }
    }
}
