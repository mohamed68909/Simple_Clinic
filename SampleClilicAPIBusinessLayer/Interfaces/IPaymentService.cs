using SampleClilicDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task<PaymentDTO> GetPaymentByIdAsync(Guid paymentId);
        Task AddPaymentAsync(PaymentDTO payment);
        Task UpdatePaymentAsync(PaymentDTO payment);
        Task DeletePaymentAsync(Guid paymentId);
      
    }
}
