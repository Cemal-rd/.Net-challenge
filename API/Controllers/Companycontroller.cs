using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Companycontroller : BaseApiController
    {
        public  ICompanyRepository _repository;
        public IMapper _mapper;
        public Companycontroller(ICompanyRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public async  Task<ActionResult<IReadOnlyList<Company>>> GetCompanies()
        {
            if(!ModelState.IsValid){
                var responseError=new ResponseError(StatusCodes.Status400BadRequest,"invalid model");
                var response=new Response(false,ModelState,responseError);
                return BadRequest(response);
            }try{
                var companies = await _repository.GetCompaniesAsync();
                var mappedCompanyDetails = _mapper.Map<IReadOnlyList<Company>, IReadOnlyList<Company>>(companies);
                var response=new Response(true,mappedCompanyDetails,null);
                return Ok(response);

            }catch(Exception e){
                var responseError=new ResponseError(StatusCodes.Status500InternalServerError,e.Message);
                var response=new Response(false,null,responseError);
                return StatusCode(StatusCodes.Status500InternalServerError,response);
            }

           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
             if(!ModelState.IsValid){
                var responseError=new ResponseError(StatusCodes.Status400BadRequest,"invalid model");
                var response=new Response(false,ModelState,responseError);
                return BadRequest(response);
            }try{
                var company= await _repository.GetCompanyByIdAsync(id);
                // var mappedcompanydetails=_mapper.Map<Company, Company>(company); gereksiz
                if(company==null){
                    var responseError = new ResponseError(StatusCodes.Status404NotFound, "companies not found.");
                    var response = new Response(false, null, responseError);
                    return NotFound(response);
                }else{
                    var response=new Response(true,company,null);
                    return Ok(response);

                }
            
            }catch(Exception e){
                var responseError=new ResponseError(StatusCodes.Status500InternalServerError,e.Message);
                var response=new Response(false,null,responseError);
                return StatusCode(StatusCodes.Status500InternalServerError,response);
                }
           
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany(Company company)
        {
             if(!ModelState.IsValid){
                var responseError=new ResponseError(StatusCodes.Status400BadRequest,"invalid model");
                var response=new Response(false,ModelState,responseError);
                return BadRequest(response);
            }try{
                
               
                    _repository.Add(company);
                    await _repository.SaveChangesAsync();
                    var response =new Response(true,company,null);
                    return Ok(response);
            

            } catch(Exception e){
                var responseError=new ResponseError(StatusCodes.Status500InternalServerError,e.Message);
                var response=new Response(false,null,responseError);
                return StatusCode(StatusCodes.Status500InternalServerError,response);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompanyDetail(int id, Company company)
        {
            if(!ModelState.IsValid){
                var responseError=new ResponseError(StatusCodes.Status400BadRequest,"invalid model");
                var response=new Response(false,ModelState,responseError);
                return BadRequest(response);
            } try{
                if(id!=company.Id){
                    var responseError = new ResponseError(StatusCodes.Status404NotFound, "Company not found.");
                    var response = new Response(false, null, responseError);
                    return NotFound(response);

                }else{
                    _repository.Update(company);
                    await _repository.SaveChangesAsync();
                    var response =new Response(true,company,null);
                    return Ok(response);
                }
            }catch(Exception e){
                var responseError=new ResponseError(StatusCodes.Status500InternalServerError,e.Message);
                var response=new Response(false,null,responseError);
                return StatusCode(StatusCodes.Status500InternalServerError,response);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompanyDetail(int id)
        {
            var order_Details = await _repository.GetCompanyByIdAsync(id);
            _repository.Delete(order_Details);
            return Ok(await _repository.SaveChangesAsync());
        }

    }
}