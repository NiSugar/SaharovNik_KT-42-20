﻿using SaharovNik_KT_42_20.Interfaces.StudentInterfaces;

namespace SaharovNik_KT_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
