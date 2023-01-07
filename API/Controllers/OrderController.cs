using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        public IOrderRepository _repository;
        public IMapper _mapper;
        public ICompanyRepository _companyRepository;
        public OrderController(IOrderRepository repository, IMapper mapper,ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> AddOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                var responseError = new ResponseError(StatusCodes.Status400BadRequest, "Invalid model");
                var response = new Response(false, ModelState, responseError);
                return BadRequest(response);
            }
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(order.CompanyId);

                if (!company.IsVerified)
                {
                    var responseError = new ResponseError(StatusCodes.Status400BadRequest,$"{company.CompanyName} adlı firma onaylanmış olmadığından sipariş verilemiyor.");
                    var response = new Response(false, null, responseError);
                    return BadRequest(response);
                }
                else if (order.OrderDate< company.permissionStartDate || order.OrderDate > company.permissionEndDate)
                {
                    var responseError = new ResponseError(StatusCodes.Status400BadRequest, $"{company.CompanyName} adlı firma Bu saat aralığında sipariş kabul etmiyor.");
                    var response = new Response(false, null, responseError);
                    return BadRequest(response);
                }
                else
                {
                    _repository.Add(order);
                    await _repository.SaveChangesAsync();
                    var response = new Response(true, order, null);
                    return Ok(response);

                }
            }




            catch (Exception e)
            {
                var responseError = new ResponseError(StatusCodes.Status500InternalServerError, e.Message);
                var response = new Response(false, null, responseError);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            
        }
    

    }
}