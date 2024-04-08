using Finance.Domain.Entities;
using MediatR;

namespace Finance.Application.Features.IncomeFeatures.Queries;

public record GetAllIncomeQuery : IRequest<List<Income>>;
