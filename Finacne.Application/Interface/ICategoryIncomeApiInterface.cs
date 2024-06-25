using Finance.Application.DTOs.DtoCategory;
using Finance.Application.DTOs.DtoCurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface
{
    public interface ICategoryIncomeApiInterface
    {
        Task<IEnumerable<CategoryIncomeDto>> GetCategoriesAsync();
    }
}
