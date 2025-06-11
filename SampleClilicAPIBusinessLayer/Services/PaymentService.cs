using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Interfaces;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Services
{
    public class PaymentService : IPaymentService

    {
        readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }
        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            var Payment= await _paymentRepository.GetAllPaymentsAsync();
            return Payment.Select(p => new PaymentDTO
            {
                PatientID = p.PatientId,
                PaymentID = p.PaymentId,
                AmountPaid = p.AmountPaid,
                PaymentDate = p.PaymentDate,
                PaymentMethod = p.PaymentMethod,
               AdditionalNotes= p.AdditionalNotes
            }).ToList();
        }
        public async Task<PaymentDTO> GetPaymentByIdAsync(Guid paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(paymentId);
            if (payment == null) return null;
            return new PaymentDTO
            {
                PaymentID = payment.PaymentId,
                PatientID = payment.PatientId,
                AmountPaid = payment.AmountPaid,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                AdditionalNotes = payment.AdditionalNotes
            };
        }

        public async Task AddPaymentAsync(PaymentDTO paymentDto)
        {
            var payment = new Payment
            {
                PatientId = paymentDto.PatientID,
                PaymentDate = paymentDto.PaymentDate,
                PaymentMethod = paymentDto.PaymentMethod,
                AmountPaid = paymentDto.AmountPaid,
                AdditionalNotes = paymentDto.AdditionalNotes
            };
            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveAsync();
        }
        public async Task UpdatePaymentAsync(PaymentDTO paymentDto)
        {
            var payment = new Payment
            {
                PaymentId = paymentDto.PaymentID,
                PatientId = paymentDto.PatientID,
                PaymentDate = paymentDto.PaymentDate,
                PaymentMethod = paymentDto.PaymentMethod,
                AmountPaid = paymentDto.AmountPaid,
                AdditionalNotes = paymentDto.AdditionalNotes
            };
            await _paymentRepository.UpdateAsync(payment);
            await _paymentRepository.SaveAsync();
        }
        public async Task DeletePaymentAsync(Guid paymentId)
        {
            await _paymentRepository.DeleteAsync(paymentId);
            await _paymentRepository.SaveAsync();
        }
    }
}
