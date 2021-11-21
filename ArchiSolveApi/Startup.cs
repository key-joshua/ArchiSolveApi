// using ArchiSolveApi.Models;
// using Autofac;
// using Entities;
// using Common;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using WebFramework.Configuration;
// using WebFramework.CustomMapping;
// using WebFramework.Middlewares;
// using WebFramework.Swagger;
// using Services;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Net.Http.Headers;
// using Microsoft.AspNetCore.Cors.Infrastructure;

// namespace ArchiSolveApi
// {
//     public class Startup
//     {
//         readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;


//             //Mapper.Initialize(config =>
//             //{
//             //    config.CreateMap<Section, SectionDto>().ReverseMap();
//             //        //.ForMember(p => p.Author, opt => opt.Ignore())
//             //        //.ForMember(p => p.Category, opt => opt.Ignore());

//             //});

//             _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
//         }

//         public IConfiguration Configuration { get; }
//         private readonly SiteSettings _siteSetting;

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
          




//             services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
//             services.InitializeAutoMapper();
//             //AutoMapperConfiguration.InitializeAutoMapper();
//             //Boosting map speed //First time time-consuming//Optional depends on you
//             //Mapper.Configuration.CompileMappings();

//             services.AddDbContext(Configuration);

//             //services.AddDbContext<ApplicationDbContext>(options =>
//             //{
//             //    options.UseSqlServer(Configuration.GetConnectionString("SQLServer"));
//             //});

//             services.AddCustomIdentity(_siteSetting.IdentitySettings);

//             services.Configure<MailSettings>(Configuration.GetSection(nameof(MailSettings)));
//             services.AddTransient<IMailService, MailService>();
//             //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//             //services.AddScoped<IUserRepository, UserRepository>();
//             //services.AddScoped<IJwtService, JwtService>();
//             services.AddControllers();
//             services.AddJwtAuthentication(_siteSetting.JwtSettings);
//             services.AddCustomApiVersioning();
//             services.AddSwagger();

//             services.AddCors(options =>
//             {
//                 options.AddPolicy(name: MyAllowSpecificOrigins,
//                                   builder =>
//                                   {
//                                       builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
//                                   });
//             });

//             // Don't create a ContainerBuilder for Autofac here, and don't call builder.Populate()
//             // That happens in the AutofacServiceProviderFactory for you.
//             //services.BuildAutofacServiceProvider();

//         }

//         // ConfigureContainer is where you can register things directly with Autofac. 
//         // This runs after ConfigureServices so the things ere will override registrations made in ConfigureServices.
//         // Don't build the container; that gets done for you by the factory.
//         public void ConfigureContainer(ContainerBuilder builder)
//         {
//             //Register Services to Autofac ContainerBuilder
//             builder.AddServices();
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             // app.IntializeDatabase();

//             app.UseCustomExceptionHandler();
//             app.UseHsts(env);

//             //if (env.IsDevelopment())
//             //{
//             //    //app.UseDeveloperExceptionPage();
//             //}
//             //else
//             //{
//             //    //app.UseExceptionHandler();
//             //    app.UseHsts();
//             //}

//             app.UseHttpsRedirection();
//             app.UseSwaggerAndUI();
//             app.UseRouting();
//             app.UseCors(MyAllowSpecificOrigins);
//             app.UseAuthentication();
//             app.UseAuthorization();


//             app.UseEndpoints(config =>
//             {
//                 config.MapControllers(); // Map attribute routing
//                                          //    .RequireAuthorization(); Apply AuthorizeFilter as global filter to all endpoints
//                                          //config.MapDefaultControllerRoute(); // Map default route {controller=Home}/{action=Index}/{id?}
//                 config.MapControllers()
//                          .RequireCors(MyAllowSpecificOrigins);
//             });

//             //Using 'UseMvc' to configure MVC is not supported while using Endpoint Routing.
//             //To continue using 'UseMvc', please set 'MvcOptions.EnableEndpointRouting = false' inside 'ConfigureServices'.
//             //app.UseMvc();
//         }
//     }
// }



using ArchiSolveApi.Models;
using Autofac;
using Entities;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFramework.Configuration;
using WebFramework.CustomMapping;
using WebFramework.Middlewares;
using WebFramework.Swagger;
using Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ArchiSolveApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            //Mapper.Initialize(config =>
            //{
            //    config.CreateMap<Section, SectionDto>().ReverseMap();
            //        //.ForMember(p => p.Author, opt => opt.Ignore())
            //        //.ForMember(p => p.Category, opt => opt.Ignore());

            //});

            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public IConfiguration Configuration { get; }
        private readonly SiteSettings _siteSetting;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          




            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.InitializeAutoMapper();
            //AutoMapperConfiguration.InitializeAutoMapper();
            //Boosting map speed //First time time-consuming//Optional depends on you
            //Mapper.Configuration.CompileMappings();

            services.AddDbContext(Configuration);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SQLServer"));
            //});

            services.AddCustomIdentity(_siteSetting.IdentitySettings);

            services.Configure<MailSettings>(Configuration.GetSection(nameof(MailSettings)));
            services.AddTransient<IMailService, MailService>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IJwtService, JwtService>();
            services.AddControllers();
            services.AddJwtAuthentication(_siteSetting.JwtSettings);
            services.AddCustomApiVersioning();
           // services.AddSwagger();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                                  });
            });

            // Don't create a ContainerBuilder for Autofac here, and don't call builder.Populate()
            // That happens in the AutofacServiceProviderFactory for you.
            //services.BuildAutofacServiceProvider();

        }

        // ConfigureContainer is where you can register things directly with Autofac. 
        // This runs after ConfigureServices so the things ere will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Register Services to Autofac ContainerBuilder
            builder.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.IntializeDatabase();

            app.UseCustomExceptionHandler();
            app.UseHsts(env);

            //if (env.IsDevelopment())
            //{
            //    //app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    //app.UseExceptionHandler();
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            //app.UseSwaggerAndUI();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(config =>
            {
                config.MapControllers(); // Map attribute routing
                                         //    .RequireAuthorization(); Apply AuthorizeFilter as global filter to all endpoints
                                         //config.MapDefaultControllerRoute(); // Map default route {controller=Home}/{action=Index}/{id?}
                config.MapControllers()
                         .RequireCors(MyAllowSpecificOrigins);
            });

            //Using 'UseMvc' to configure MVC is not supported while using Endpoint Routing.
            //To continue using 'UseMvc', please set 'MvcOptions.EnableEndpointRouting = false' inside 'ConfigureServices'.
            //app.UseMvc();
        }
    }
}

