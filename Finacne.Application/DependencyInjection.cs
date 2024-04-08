using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AppApplication(this IServiceCollection service)
        {
            service.AddMediatR(typeof(DependencyInjection).Assembly);
            return service;
        }
    }
}
