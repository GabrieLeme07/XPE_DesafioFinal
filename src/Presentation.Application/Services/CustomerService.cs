using XPEDesafioFinal.Entities;
using XPEDesafioFinal.Repositories;

namespace XPEDesafioFinal.Services
{
    public class CustomerService(ICustomerRepository repository)
    {
        private readonly ICustomerRepository _repository = repository;

        public Task<List<Customer>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Customer> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<List<Customer>> GetByNameAsync(string name) => _repository.GetByNameAsync(name);
        public Task<Customer> CreateAsync(Customer customer) => _repository.CreateAsync(customer);
        public Task<Customer> UpdateAsync(Customer customer) => _repository.UpdateAsync(customer);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
