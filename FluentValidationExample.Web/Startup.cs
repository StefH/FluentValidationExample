using AutoMapper;
using FluentValidation;
using FluentValidationExample.Web.Filters;
using FluentValidationExample.Web.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationExample.Web
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
            services.AddAutoMapper();

            services.AddBusiness();

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(GlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IFluentValidationPropertyNameResolver, FluentValidationPropertyNameResolver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMapper autoMapper, IFluentValidationPropertyNameResolver resolver)
        {
            ConfigureAutoMapperAndFluentValidation(autoMapper, resolver);

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

        private void ConfigureAutoMapperAndFluentValidation(IMapper autoMapper, IFluentValidationPropertyNameResolver resolver)
        {
            autoMapper.ConfigurationProvider.AssertConfigurationIsValid();

            ValidatorOptions.PropertyNameResolver = resolver.Resolve;
        }
    }
}
