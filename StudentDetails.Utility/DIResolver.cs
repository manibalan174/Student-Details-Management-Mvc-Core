using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentDetailsManagement.Core.IRepositories;
using StudentDetailsManagement.Core.IService;
using StudentDetailsManagement.Services.Service;
using StudentDetailsManagement.Resource.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsManagement.Utility
{
   public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IService, Service> ();

            services.AddScoped<IRepositories, Repositories>();
        }
    }
}
