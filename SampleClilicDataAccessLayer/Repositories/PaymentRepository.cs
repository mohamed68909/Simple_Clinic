using Microsoft.EntityFrameworkCore;
using SampleClilicDataAccessLayer.Data;
using SampleClilicDataAccessLayer.Interfaces;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly CilicDbContext _context;
        public PaymentRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment> GetPaymentByIdAsync(Guid paymentId)
        {
            return await _context.Payments.FindAsync(paymentId);
        }
        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await SaveAsync();
        }
        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await SaveAsync();
        }
        public async Task DeleteAsync(Guid paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await SaveAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
