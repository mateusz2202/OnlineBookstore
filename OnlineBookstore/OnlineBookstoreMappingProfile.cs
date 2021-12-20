﻿using AutoMapper;
using OnlineBookstore.Entities;
using OnlineBookstore.Models;

namespace OnlineBookstore
{
    public class OnlineBookstoreMappingProfile : Profile
    {
        public OnlineBookstoreMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(x => x.City, c => c.MapFrom(a => a.Address.City))
                .ForMember(x => x.Street, c => c.MapFrom(a => a.Address.Street))
                .ForMember(x => x.AddressLine, c => c.MapFrom(a => a.Address.AddressLine))
                .ForMember(x => x.PostalCode, c => c.MapFrom(a => a.Address.PostalCode))
                .ForMember(x => x.RoleName, c => c.MapFrom(a => a.Role.Name));           
               
        }
    }
}