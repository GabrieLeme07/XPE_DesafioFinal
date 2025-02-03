using XPEDesafioFinal.Entities;

namespace XPEDesafioFinal.Repositories
{
    public interface ICustomerRepository
    {
        // Query
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<List<Customer>> GetByNameAsync(string name);

        // Command
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
    }
}
