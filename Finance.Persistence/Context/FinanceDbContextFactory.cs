using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Finance.Infrastructure.Authentication;

namespace Finance.Persistence.Context
{
    public class FinanceDbContextFactory : IDesignTimeDbContextFactory<FinanceDBContext>
    {
        private readonly IOptions<AuthorizationsOptions> _authOptions;

        public FinanceDbContextFactory()
        {
            // Optionally set a default value for _authOptions if needed
            _authOptions = Options.Create(new AuthorizationsOptions { /* Default settings */ });
        }

        public FinanceDbContextFactory(IOptions<AuthorizationsOptions> authOptions)
        {
            _authOptions = authOptions;
        }

        public FinanceDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceDBContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=FinanceDb;Username=postgres; Password=1234");

            return new FinanceDBContext(optionsBuilder.Options, _authOptions);
        }
    }
}
