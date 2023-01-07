using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Utils;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
       

        public ProductController(IProductRepository repository, IMapper mapper)
        {
           _repository = repository;
           _mapper =mapper;
        }

   

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            if (!ModelState.IsValid)
            {
                var responseError = new ResponseError(StatusCodes.Status400BadRequest, "invalid model");
                var response = new Response(false, ModelState, responseError);
                return BadRequest(response);
            }
            try
            {
                var products = await _repository.GetProductsAsync();
                var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
              
                var response = new Response(true, products, null);
                return Ok(response);
            }
            catch (Exception e)
            {
                var responseError = new ResponseError(StatusCodes.Status500InternalServerError, e.Message);
                var response = new Response(false, null, responseError);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                var responseError = new ResponseError(StatusCodes.Status400BadRequest, "invalid model");
                var response = new Response(false, ModelState, responseError);
                return BadRequest(response);
            }
            try
            {
                var product = await _repository.GetProductByIdAsync(id);
                var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
                if (mappedProduct == null)
                {
                    var responseError = new ResponseError(StatusCodes.Status404NotFound, "Product not found.");
                    var response = new Response(false, null, responseError);
                    return NotFound(response);

                }
                else
                {
                    var response = new Response(true, mappedProduct, null);
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
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                var responseError = new ResponseError(StatusCodes.Status400BadRequest, "invalid model");
                var response = new Response(false, ModelState, responseError);
                return BadRequest(response);
            }
            try
            {
                if (product.CompanyId == 0)
                {
                    var responseError = new ResponseError(StatusCodes.Status400BadRequest, "cannot be null");
                    var response = new Response(false, ModelState, responseError);
                    return BadRequest(response);
                }
                else
                {
                    _repository.Add(product);
                    await _repository.SaveChangesAsync();
                    var response = new Response(true, product, null);
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