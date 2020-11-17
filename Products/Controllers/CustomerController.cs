using Domain.DTO;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Services;
using Products.Utils;
using System;

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

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
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

            customer.Senha = null;
            response.Data = customer;

            string token = TokenService.GenerateToken(customer);
            response.Token = token;

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("include")]
        public IActionResult Include([FromBody] CustomerInclude customerInclude)
        {
            Response<Customer> response = new Response<Customer>();

            DateTime today = DateTime.Today;
            int age = today.Year - customerInclude.DataNascimento.Year;
            if (customerInclude.DataNascimento.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age < 18)
            {
                response.Errors.Add("A idade informada é menor que a permitida.");
                return BadRequest(response);
            }

            Customer customer = _customerRepository.GetByCpf(customerInclude.Cpf);
            if (customer != null)
            {
                response.Errors.Add(string.Format("O CPF {0} pertence a outro usuário.", customerInclude.Cpf));
                return BadRequest(response);
            }

            customer = _customerRepository.Incluid(customerInclude.ToCostumer());
            customer.Senha = null;

            response.Data = customer;
            string token = TokenService.GenerateToken(customer);
            response.Token = token;

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [Route("edit")]
        public IActionResult Edit([FromBody] CustomerEdit customerEdit)
        {
            Response<Customer> response = new Response<Customer>();
            Customer customer = _customerRepository.Update(customerEdit.ToCostumer());
            customer.Senha = null;

            response.Data = customer;
            return Ok(response);
        }

        [Authorize]
        [HttpDelete]
        [Route("remove")]
        public IActionResult Remove([FromQuery] long codigo)
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
