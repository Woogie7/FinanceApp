using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Context
{
    public class FinanceDbContextFactory : IDesignTimeDbContextFactory<FinanceDBContext>
    {
        public FinanceDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceDBContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=FinanceDb;Username=postgres; Password=1234");

            return new FinanceDBContext(optionsBuilder.Options);
        }
    }
}
