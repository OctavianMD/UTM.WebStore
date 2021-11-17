using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace FrontOffice.MVC.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database

            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UtmWebStore"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Http Clients

            services.AddHttpClient(Constants.FetchDataHttpClientName).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                //handler.ClientCertificates.Add(CertificateHelper.LoadPrivateCertificate(
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePath"),
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePassword")));
                return handler;
            });

            #endregion

            #region Helpers

            services.AddScoped<BaseCategoryHelper>();
            services.AddScoped<CategoryHelper>();
            services.AddScoped<ProductHelper>();

            #endregion

            #region Application Services

            services.AddScoped<IFetchDataHttpClient, FetchDataHttpClient>();
            services.AddScoped<IFetchDataService, FetchDataService>();
            services.AddScoped<ICategoryService, CategoryService>();

            #endregion

            services.AddControllersWithViews();
        }
    }
}
