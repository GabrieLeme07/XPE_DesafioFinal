using Microsoft.EntityFrameworkCore;
using XPEDesafioFinal.Data;
using XPEDesafioFinal.Entities;

namespace XPEDesafioFinal.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Customer>> GetAllAsync()
            => await _context.Customers.ToListAsync();

        public async Task<Customer> GetByIdAsync(int id)
            => await _context.Customers.FindAsync(id);

        public async Task<List<Customer>> GetByNameAsync(string name)
            => await _context.Customers.Where(c => c.Name.Contains(name)).ToListAsync();

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
