using AutoMapper;
using Finance.Application.DTOs.DtoCurrency;
using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.AutoMapper
{
    internal class CurrencyProfile : Profile
    {
        public CurrencyProfile() {
            CreateMap<Currency, CurrencyDto>()
                   .ForMember(crtI => crtI.Id, i => i.MapFrom(x => x.Id))
                   .ForMember(crtI => crtI.CurrencyName, i => i.MapFrom(x => x.CurrencyName));
        }
       
    }
}
