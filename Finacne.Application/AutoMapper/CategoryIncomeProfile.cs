using AutoMapper;
using Finance.Application.DTOs.DtoCategory;
using Finance.Application.DTOs.DtoCurrency;
using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.AutoMapper
{
    internal class CategoryIncomeProfile : Profile
    {
        public CategoryIncomeProfile() 
        {
            CreateMap<CategoryIncome, CategoryIncomeDto>()
                   .ForMember(crtI => crtI.Id, i => i.MapFrom(x => x.Id))
                   .ForMember(crtI => crtI.CategoryIncomeName, i => i.MapFrom(x => x.CategoryIncomeName));

            CreateMap<CategoryExpense, CategoryExpenseDto>()
                   .ForMember(crtI => crtI.Id, i => i.MapFrom(x => x.Id))
                   .ForMember(crtI => crtI.CategoryExpenseName, i => i.MapFrom(x => x.CategoryExpenseName));
        }
    }
}
