using Digibooky.API.Controllers.Books;
using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.API.Controllers.Lendings;
using Digibooky.API.Controllers.Lendings.Interfaces;
using Digibooky.API.Controllers.Users;
using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.API.Helpers;
using Digibooky.Services.BookServices;
using Digibooky.Services.BookServices.Interfaces;
using Digibooky.Services.LendingServices;
using Digibooky.Services.LendingServices.Interfaces;
using Digibooky.Services.UserServices;
using Digibooky.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Digibooky.API
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
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IBookMapper, BookMapper>();
            services.AddSingleton<ILendingService, LendingService>();
            services.AddSingleton<ILendingMapper, LendingMapper>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });

            app.UseAuthentication();

            app.UseMvc();

            app.Run(async context =>
            {
                context.Response.Redirect("/swagger");
            });

        }
    }
}
