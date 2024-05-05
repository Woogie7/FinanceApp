using Finance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Wpf.Service.Interface
{
    public interface ICurrencyService
    {
        public Task<IEnumerable<Currency>> GetCurrenciesAsync();
    }
}
