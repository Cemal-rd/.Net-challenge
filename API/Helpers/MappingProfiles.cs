using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
           
            public MappingProfiles(){
            CreateMap<Product,ProductToReturnDto>()
            .ForMember(d=>d.Company,o=>o.MapFrom(s=>s.Company.CompanyName));

    }
    }
}