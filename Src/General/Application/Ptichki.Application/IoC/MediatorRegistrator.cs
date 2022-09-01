using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ptichki.Application.IoC
{
    public static class MediatorRegistrator
    {
        public static IServiceCollection AddMediator(this IServiceCollection services) => services
            .AddMediatR(typeof(MediatorRegistrator).Assembly);
    }
}
