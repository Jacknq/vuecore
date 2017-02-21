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
using AspNet.Security.OpenIdConnect.Server;
using AspNet.Security.OpenIdConnect.Primitives;
using System.Security.Claims;
using AspNet.Security.OpenIdConnect.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;

using bVue.code.Providers;
using TypeScripter;
using TypeScripter.Readers;
using TypeScripter.TypeScript;
using System.Reflection;

namespace WebApplication2Vue
{
    public class Startup
    {
        public static IConfigurationRoot config{get;set;}
        public static void Main(string[] args)
        {
       
        // Retrieve the configuration information.
        
             config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")               
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
            //var configValue = config["dbpath"];

            host.Run();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
             //     loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //     List<Customer> c = lite.getCustomerInfo().ToList();
            //     string ret = "";ret+=c.First().Phones[0];
            //     lite.getCustomerInfo().ForEach(a=>ret +=a.Name+ " ");

            //     await context.Response.WriteAsync("Hello World! " + ret);
            // });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
         
           
           app.UseCors(builder =>
            // This will allow any request from any server. Tweak to fit your needs!
            // The fluent API is pretty pleasant to work with.
            builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin().AllowCredentials()
                );
            
       
            RunSignlarAuthConfig(app, env);
               
        }

      

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver =
            new DefaultContractResolver());
            services.AddCors();
            services.AddAuthentication(); //for isuing tokens

            services.AddSignalR(options =>{
                options.MessageBus.MaxTopicsWithNoSubscriptions =1;
                options.Hubs.EnableJavaScriptProxies = true;
                //options.Transports.
                 options.MessageBus.MessageBufferSize=0;
                 options.Hubs.EnableDetailedErrors = true;});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        // {
        //     loggerFactory.AddConsole();

        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }

        //     app.Run(async (context) =>
        //     {
        //         await context.Response.WriteAsync("Hello World!");
        //     });
        // }
        private void RunSignlarAuthConfig(IApplicationBuilder app, IHostingEnvironment env)
        {
              app.UseSignalR();
            // Add a new middleware validating access tokens.
            app.UseOAuthValidation(options => {
                options.Events = new OAuthValidationEvents
                {
                    // Note: for SignalR connections, the default Authorization header does not work,
                    // because the WebSockets JS API doesn't allow setting custom parameters.
                    // To work around this limitation, the access token is retrieved from the query string.
                    OnRetrieveToken = context => {
                        context.Token = context.Request.Query["access_token"];

                        return Task.FromResult(0);
                    }
                };
            });

          //  app.UseSignalR("/signalr");

            // Add a new middleware issuing access tokens.
            app.UseOpenIdConnectServer(options => {
                // Disable the HTTPS requirement.
                options.AllowInsecureHttp = true;

                // Disable the authorization endpoint as it's not used in this scenario.
               // options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/token";

                options.Provider = new AuthorizationProvider();

                // Force the OpenID Connect server middleware to use JWT
                // instead of the default opaque/encrypted format.
                options.AccessTokenHandler = new JwtSecurityTokenHandler();

                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                options.SigningCredentials.AddEphemeralKey();
               // options.SigningCredentials.AddKey(new RsaSecurityKey("test"));

            // On production, using a X.509 certificate stored in the machine store is recommended.
            // You can generate a self-signed certificate using Pluralsight's self-cert utility:
            // https://s3.amazonaws.com/pluralsight-free/keith-brown/samples/SelfCert.zip
            //
            // options.SigningCredentials.AddCertificate("7D2A741FE34CC2C7369237A5F2078988E17A6A75");
        });
        }

        public static void RunSomeTasks()
        {
            //lite.RunDMC();

           // var assembly = Assembly.GetEntryAssembly(); // this.GetType().Assembly;
           // var scripter = new TypeScripter.Scripter();
            // var output = scripter
            //     .UsingTypeReader(
            //         new TypeScripter.Readers.CompositeTypeReader(
            //             new TypeScripter.Readers.TypeReader()//,
            //             //new TypeScripter.Readers.ServiceContractTypeReader()
            //         )
            //     )
            //     .AddTypes(assembly)
            //     .ToString();
            // File.WriteAllText("D:\\TYPESCRIPT.ts", output);

        }


     
     

    }//end startup
}
