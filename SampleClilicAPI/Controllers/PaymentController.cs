using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Models;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet]
       public async Task<ActionResult<IEnumerable<PaymentDTO >>> GetAllPayments()
        {
            var payments = await paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPaymentById(Guid id)
        {
            var payment = await paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePayment( PaymentDTO payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }
            await paymentService.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment(PaymentDTO payment)
        {
         
            await paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(Guid id)
        {
            var payment = await paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            await paymentService.DeletePaymentAsync(id);
            return NoContent();
        }

    }
}
