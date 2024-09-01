using AutoMapper;
using Finance.Application.DTOs;
using Finance.Application.DTOs.Income;
using Finance.Domain.Entities;

namespace Finance.Application.AutoMapper
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile() 
        {
            CreateMap<CreateIncomeDto, Income>()
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.CurrencyId, i => i.MapFrom(x => x.CurrencyId))
                .ForMember(crtI => crtI.CategoryIncomeId, i => i.MapFrom(x => x.CategoryIncomeId))
                .ForMember(crtI => crtI.UserId, i => i.MapFrom(x => x.UserId))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));

            CreateMap<Income, CreateIncomeDto>()
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.CurrencyId, i => i.MapFrom(x => x.CurrencyId))
                .ForMember(crtI => crtI.CategoryIncomeId, i => i.MapFrom(x => x.CategoryIncomeId))
                .ForMember(crtI => crtI.UserId, i => i.MapFrom(x => x.UserId))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));

            CreateMap<Income, IncomeDTO>()
                .ForMember(crtI => crtI.ID, i => i.MapFrom(x => x.Id))
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.Currency, i => i.MapFrom(x => x.Currency.CurrencyName))
                .ForMember(crtI => crtI.CategoryIncome, i => i.MapFrom(x => x.Category.CategoryIncomeName))
                .ForMember(crtI => crtI.UserName, i => i.MapFrom(x => x.User.Email))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));

            CreateMap<Income, DeteilsIncomeDTO>()
                .ForMember(crtI => crtI.id, i => i.MapFrom(x => x.Id))
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.Currency, i => i.MapFrom(x => x.Currency.Id))
                .ForMember(crtI => crtI.CategoryIncome, i => i.MapFrom(x => x.Category.Id))
                .ForMember(crtI => crtI.Email, i => i.MapFrom(x => x.User.Email))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));


        }
    }
}
