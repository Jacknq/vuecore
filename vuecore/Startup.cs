using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Configuration;
using bVue;
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
using TypeScripter;
using TypeScripter.Readers;
using TypeScripter.TypeScript;
using System.Reflection;
using Microsoft.AspNetCore.Owin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
//using SimpleTokenProvider;
using NLog.Web;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2Vue
{
    public partial class Startup
    {
        public static IConfigurationRoot config{get;set;}
        public static void Main(string[] args)
        {
       
        // Retrieve the configuration information.
        
             config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional:true)               
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
                //j

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot("dist") // use "." to completely remove the wwwroot               
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            RunSomeTasks();
        
            Log.Debug("caaling host run");
            host.Run();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddConsole();
            // if (env.IsDevelopment())
           // {
            app.UseDeveloperExceptionPage();
            
            env.ConfigureNLog("nlog.config");
            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();
            //add NLog.Web
            app.AddNLogWeb();
            
            app.UseStatusCodePagesWithReExecute("/");
 app.UseAuthentication();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
    
          //  }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseCors(builder =>        
            builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin().AllowCredentials()
                );
            //     loggerFactory.AddConsole();
            // app.UseFileServer();
            RunSignlarAuthConfig(app, env);

            // app.UseSimpleTokenProvider(new TokenProviderOptions
            // {
            //     Path = "/token",
            //     Audience = "ExampleAudience",
            //     Issuer = "ExampleIssuer",
            //     SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            //     IdentityResolver = GetIdentity,
            //     Expiration = TimeSpan.FromHours(8)
            // });
           

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
            services.AddAuthentication(); //for isuing tokens
            //services.addap.addapi
            configureSignalr(services);
            // services.Configure<AuthorizationOptions>(options =>
            // {
            //     options.AddPolicy("IAddComment", policy => policy.RequireClaim("IComment", "true"));
            // });
            //NLOG call this in case you need aspnet-user-authtype/aspnet-user-identity
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private void configureSignalr(IServiceCollection services)
        {
            services.AddSignalR(options =>
            {
                options.MessageBus.MaxTopicsWithNoSubscriptions = 1;
                options.Hubs.EnableJavaScriptProxies = true;
                //options.Transports.
                options.MessageBus.MessageBufferSize = 0;
                options.Hubs.EnableDetailedErrors = true;

                var transports = options.Transports;
                // transports.DisconnectTimeout = TimeSpan.FromSeconds(60*10);
                //   //  transports.KeepAlive = TimeSpan.FromSeconds(60*10);
                transports.TransportConnectTimeout = TimeSpan.FromSeconds(110);
            });
            
            services.AddNodeServices();
            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver =
            new DefaultContractResolver());
            services.AddMvcCore().AddApiExplorer();

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,


                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
            // services.AddAuthentication(options =>
            // {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer(o =>
            // {
            //     o.RequireHttpsMetadata = false;
            //     // o.auAutomaticAuthenticate = true
            //     o.TokenValidationParameters = tokenValidationParameters;
            //     o.Events = new CustomBearerEvents();
            // });
        }

     
        private void RunSignlarAuthConfig(IApplicationBuilder app, IHostingEnvironment env)
        {

           // ConfigureAuth(app);

            //    // Add a new middleware validating access tokens.
            //    // app.UseJwtBearerAuthentication(app, options=>{  });
            //app.UseOAuthValidation(options =>
            //{
            //    options.Events = new OAuthValidationEvents
            //    {

            //        // Note: for SignalR connections, the default Authorization header does not work,
            //        // because the WebSockets JS API doesn't allow setting custom parameters.
            //        // To work around this limitation, the access token is retrieved from the query string.
            //        OnRetrieveToken = context =>
            //        {
            //            context.Token = context.Request.Query["token"];

            //            return Task.FromResult(0);
            //        }
            //    };
            //});
            app.UseSignalR("/signalr");
        //     //  app.UseSignalR("/signalr");
        //     //app.useo
        //     // Add a new middleware issuing access tokens.
        //     app.UseOpenIdConnectServer(options => {
        //         // Disable the HTTPS requirement.
        //         options.AllowInsecureHttp = true;

        //        // Disable the authorization endpoint as it's not used in this scenario.
        //        // options.AuthorizationEndpointPath = PathString.Empty;//commented on signalr
        //         options.TokenEndpointPath = "/token";

        //         options.Provider = new AuthorizationProvider();

        //         // Force the OpenID Connect server middleware to use JWT
        //         // instead of the default opaque/encrypted format.
        //         options.AccessTokenHandler = new JwtSecurityTokenHandler();

        //         // Register a new ephemeral key, that is discarded when the application
        //         // shuts down. Tokens signed using this key are automatically invalidated.
        //         // This method should only be used during development.
        //         options.SigningCredentials.AddEphemeralKey();
        //         //options.SigningCredentials.AddKey(new RsaSecurityKey(new RSAParameters(){})"test"));

        //     // On production, using a X.509 certificate stored in the machine store is recommended.
        //     // You can generate a self-signed certificate using Pluralsight's self-cert utility:
        //     // https://s3.amazonaws.com/pluralsight-free/keith-brown/samples/SelfCert.zip
        //     //
        //     // options.SigningCredentials.AddCertificate("7D2A741FE34CC2C7369237A5F2078988E17A6A75");
        // });
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
