using AlfaSample.Data.Models;
using AlfaSample.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlfaSample.Infrastructure
{
    public class AutoMapperProfile : Profile    
    {
        public AutoMapperProfile() 
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Invoice, InvoiceViewModel>();
            CreateMap<InvoiceChart, InvoiceChartViewModel>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => {
                a.AddProfile<AutoMapperProfile>();
            });
        }
    }
}