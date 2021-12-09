using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Becomex.Robot.IoC
{
    public static class InjectionConfiguration
    {
        public static void AddDependenyInjectionConfiguration(this IServiceCollection services)
        {
            BootstrappInjector.RegisterServices(services);
        }
    }
}
