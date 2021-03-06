﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackingFood.Core.Application;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.ExternalService;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.ExternalService;
using TrackingFood.Core.Repository;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<Appsettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<Context>();
            services.AddScoped<IDomainEvent, DomainEvent>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBaseApplication, BaseApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICredencialApplication, CredencialApplication>();
            services.AddScoped<ICompanyApplication, CompanyApplication>();
            services.AddScoped<ICompanyBranchApplication, CompanyBranchApplication>();
            services.AddScoped<IMenuApplication, MenuApplication>();
            services.AddScoped<IMenuItemApplication, MenuItemApplication>();
            services.AddScoped<IQueueApplication, QueueApplication>();
            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IDeliverymanApplication, DeliverymanApplication>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICredencialRepository, CredencialRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyBranchRepository, CompanyBranchRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
            services.AddScoped<IQueueHistoryRepository, QueueHistoryRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IPushNotificationInternalService, PushNotificationInternalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
