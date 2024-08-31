using Finance.Application.DTOs.DtoCurrency;
using Finance.Application.DTOs.Income;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Api
{
    public interface ICurrencyApiInterface
    {
        Task<IEnumerable<CurrencyDto>> GetCurenciesAsync();
    }
}
