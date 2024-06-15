using AutoMapper;
using Finance.Domain.Entities;
using Finance.Application.DTOs.DtoExpense;
using Finance.Application.DTOs;

namespace Finance.Application.AutoMapper
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>()
                .ForMember(crtI => crtI.ID, i => i.MapFrom(x => x.Id))
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.Currency, i => i.MapFrom(x => x.Currency.CurrencyName))
                .ForMember(crtI => crtI.CategoryExpense, i => i.MapFrom(x => x.Category.CategoryExpenseName))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));

            CreateMap<CreateExpenseDto, Expense>()
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.CurrencyId, i => i.MapFrom(x => x.CurrencyId))
                .ForMember(crtI => crtI.CategoryExpenseId, i => i.MapFrom(x => x.CategoryExpenseId))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));

            CreateMap<Expense, CreateExpenseDto>()
                .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
                .ForMember(crtI => crtI.CurrencyId, i => i.MapFrom(x => x.CurrencyId))
                .ForMember(crtI => crtI.CategoryExpenseId, i => i.MapFrom(x => x.CategoryExpenseId))
                .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));
        }
    }
}
