using Domain.DTO;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using Products.Utils;

namespace Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            Response<Customer> response = new Response<Customer>();

            Customer customer = _customerRepository.GetByCpf(login.Cpf);
            if (customer == null)
            {
                response.Errors.Add(string.Format("O CPF {0} não está cadastrado.", login.Cpf));
                return BadRequest(response);
            }
            else if (customer.Senha != login.Senha)
            {
                response.Errors.Add("Senha incorreta.");
                return BadRequest(response);
            }

            response.Data = customer;
            return Ok(response);
        }

        [HttpPost("include")]
        public IActionResult Include([FromBody] CustomerInclude customerInclude)
        {
            Response<Customer> response = new Response<Customer>();

            Customer customer = _customerRepository.GetByCpf(customerInclude.Cpf);
            if (customer != null)
            {
                response.Errors.Add(string.Format("O CPF {0} pertence a outro usuário.", customerInclude.Cpf));
                return BadRequest(response);
            }

            customer = _customerRepository.Incluid(customerInclude.ToCostumer());
            response.Data = customer;

            return Ok(response);
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] CustomerEdit customerEdit)
        {
            Response<Customer> response = new Response<Customer>();
            Customer customer = _customerRepository.Update(customerEdit.ToCostumer());

            response.Data = customer;
            return Ok(response);
        }

        [HttpPost("remove")]
        public IActionResult Remove([FromBody] long codigo)
        {
            Response<Customer> response = new Response<Customer>();

            Customer customer = _customerRepository.GetbyId(codigo);
            if (customer == null)
            {
                response.Errors.Add(string.Format("O Código {0} não está cadastrado.", codigo));
                return BadRequest(response);
            }

            customer = _customerRepository.Remove(customer);
            response.Data = customer;

            return Ok(response);
        }
    }
}
