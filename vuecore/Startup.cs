using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System;
//using AspNet.Security.OpenIdConnect.Server;
//using AspNet.Security.OpenIdConnect.Primitives;
using System.Security.Claims;
//using AspNet.Security.OpenIdConnect.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
//using AspNet.Security.OAuth.Validation;

//using bVue.code.Providers;

using System.Reflection;
//using Microsoft.AspNetCore.Owin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using NLog.Web;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using bVue.code.controllers;
using bVue.code;
//using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore;
using System.Web;
//using System.Web.Http;
//using System.Web.Routing;
using Microsoft.Extensions.Hosting;


namespace WebApplication2Vue
{
    public partial class Startup
    {
        public static IConfigurationRoot config { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {

            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            //     // app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            //     // {
            //     //     HotModuleReplacement = true
            //     // });
            // }

            //    env.ConfigureNLog("nlog.config");
            //add NLog to ASP.NET Core
            //  loggerFactory.AddNLog();

            app.UseStatusCodePagesWithReExecute("/");
            app.UseAuthentication();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //  }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            // app.UseSimpleTokenProvider(new TokenProviderOptions
            // {
            //     Path = "/token",
            //     Audience = "ExampleAudience",
            //     Issuer = "ExampleIssuer",
            //     SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            //     IdentityResolver = GetIdentity,
            //     Expiration = TimeSpan.FromHours(8)
            // });

            //GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                    template: "{controller=Home}/{action=Index}/{*path}");
            });

        }

        SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretKey"));

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(); //for isuing tokens

            //  services.AddNodeServices();
            services.AddMvc(option => option.EnableEndpointRouting = false)
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            //.AddJsonOptions(options => options.SerializerSettings.ContractResolver =
            //new DefaultContractResolver());
            // new Newtonsoft.Json.Serialization.DefaultContractResolver());
            services.AddMvcCore().AddApiExplorer();
            services.AddCors();
            // services.Configure<AuthorizationOptions>(options =>
            // {
            //     options.AddPolicy("IAddComment", policy => policy.RequireClaim("IComment", "true"));
            // });
            //NLOG call this in case you need aspnet-user-authtype/aspnet-user-identity
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void RunSomeTasks()
        {
            //lite.RunDMC();      

        }





    }//end startup

    public static class Log
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string message)
        {
            _logger.Debug(message);

        }
        public static void Error(string message)
        {
            _logger.Error(message);

        }
        public static void Warn(string message)
        {
            _logger.Warn(message);

        }

    }
}
