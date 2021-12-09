using Microsoft.Extensions.DependencyInjection;
using Becomex.Robot.Application.Interfaces;
using System;

namespace Becomex.Robot.IoC
{
    public class BootstrappInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IRobot, Application.Robot>();
        }
    }
}
