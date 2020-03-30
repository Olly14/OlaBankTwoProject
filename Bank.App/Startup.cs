using System;
using AutoMapper;
using Bank.App.ModelMappers.Accounts;
using Bank.App.ModelMappers.AppUsers;
using Bank.App.ModelMappers.DropDownLists;
using Bank.App.Models;
using Bank.App.Models.ModelValidators.AccountValidators;
using Bank.App.Utilities;
using Bank.Data;
using Bank.Data.DatabasePopulated;
using Bank.Data.Infrastructure.Persistence;
using Bank.Data.Infrastructure.Persistence.AccountRepository;
using Bank.Data.Infrastructure.Persistence.AccountsRepository;
using Bank.Data.Infrastructure.Persistence.AppUserRepository;
using Bank.Data.Infrastructure.Persistence.AppUSerRepository;
using Bank.Data.Infrastructure.Persistence.DropDownListsRepository;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IAccountsRepository;
using Bank.Data.Infrastructure.Repository.IAppUserRepository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using Bank.App.ModelValidators.UserModelValidators;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Bank.App
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AccountViewModelAutoMapperProfile());
                mc.AddProfile(new AppUserViewModelAutoMapperProfile());
                mc.AddProfile(new DropDownListsViewModelAutoMApperProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddControllers()
            //    .AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Startup>())
            //    .AddNewtonsoftJson();



            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                

                options.EnableEndpointRouting = false;

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddScoped<IValidator<AccountTransactionViewModel>, AccountTransactionViewModelValidator> ();
            services.AddScoped<IValidator<AppUserViewModel>, AppUserViewModelValidator>();

            services.AddScoped<BankContext>();

            services.AddScoped<IPopulateDatabaseWithData, PopulateDatabaseWithData>();

            services.AddScoped<UserManager<AppUser>>();

            services.AddScoped<SignInManager<AppUser>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IMaskIds, MaskIds>();
            services.AddScoped<ISetAccountRate, SetAccountRate>();

            services.AddScoped<IAccountRepositoryCalculateInterest, AccountRepositoryCalculateInterest>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRepository<AccountTransaction>, AccountTransactionRepository>();

            services.AddScoped<IRepository<AppUser>, AppUserRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IDropDownListRepository<TransactionType>, TransactionTypeRepository>();

            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IDropDownListRepository<Gender>, GenderRepository>();
            services.AddScoped<IDropDownListRepository<Currency>, CurrencyRepository>();
            services.AddScoped<IDropDownListRepository<Country>, CountryRepository>();
            services.AddScoped<ITransactionType, TransactionTypeRepository>();
            services.AddScoped<IOrderByTypeRepository, OrderByTypeRepository>();


            services.AddScoped<IUnitOfWorkB<Account>, UnitOfWorkAccountRepo>();

            services.AddScoped<IUnitOfWorkB<AppUser>, UnitOfWorkAppUserRepo>();

            services.AddScoped<IDesignTimeDbContextFactory<BankContext>, BankContextDbContextFactory>();


            services.AddDbContext<BankContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BankDbConnectionString"), b => b.MigrationsAssembly("Bank.App"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<BankContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.LoginPath = "/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment /*IHostingEnvironment*/ env, BankContext bankContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UseHpkp(hpkp =>
            //{
            //    hpkp.UseMaxAgeSeconds(7 * 24 * 60 * 60)
            //        .AddSha256Pin("nrmpk4ZI3wbRBmUZIT5aKAgP0LlKHRgfA2Snjzeg9iY=")
            //        .SetReportOnly()
            //        .ReportViolationsTo("/hpkp-report");
            //});

            //populateDatabaseWithData.EnsureSeedDataContext();
            //bankContext.Database.Migrate();
            //bankContext.EnsureSeedDataContext();
            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Scripts")),
                RequestPath = "/Scripts"


            });

            app.UseCookiePolicy();
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
