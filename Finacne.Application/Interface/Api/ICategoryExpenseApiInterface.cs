using Finance.Application.DTOs.DtoCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Api
{
    public interface ICategoryExpenseApiInterface
    {
        Task<IEnumerable<CategoryExpenseDto>> GetCategoriesExpenseAsync();
    }
}
