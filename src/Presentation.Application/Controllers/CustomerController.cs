using Microsoft.AspNetCore.Mvc;
using XPEDesafioFinal.Entities;
using XPEDesafioFinal.Services;

namespace XPEDesafioFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(CustomerService service) : Controller
    {
        private readonly CustomerService _service = service;

        [HttpGet]
        public async Task<IActionResult> Index() 
            => View(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpGet("create")]
        public IActionResult Create() => View();

        [HttpPost("create")]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
