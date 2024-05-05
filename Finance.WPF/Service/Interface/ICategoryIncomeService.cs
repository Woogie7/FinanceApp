using Finance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Wpf.Service.Interface
{
    public interface ICategoryIncomeService
    {
        public Task<IEnumerable<CategoryIncome>> GetCategoryIncomeAsync();
    }
}
