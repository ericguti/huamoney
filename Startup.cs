using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;

namespace HuaMoney
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //Service se configura el inyector de dependencias.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ComplaintsPortalContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("ComplaintsPortalConnection")));

            services.AddControllersWithViews(options => SetDataAnotationsGeneral(services, options))
           .AddViewLocalization(opt => opt.ResourcesPath = "Resources")
           .AddDataAnnotationsLocalization();

            services.Configure<RouteOptions>(opt => opt.LowercaseUrls = false);
            //Configuramos las dependencias.
            //services.AddComplaintsPortalManagementWeb(_configuration);

            services.AddDistributedMemoryCache();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "AuthCPComplaintsWeb";
                options.ExpireTimeSpan = TimeSpan.FromHours(48);
                //options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/error/401";
                options.SlidingExpiration = true;
            });
        }

        //Middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error/exception");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/exception");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=main}/{action=index}");

            });
        }

        private void SetDataAnotationsGeneral(IServiceCollection services, MvcOptions options)
        {
            var F = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var L = F.Create("ModelBindingMessages", "ComplaintsPortal.ComplaintsWeb");
            options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                (x) => L["ValueIsInvalid"]);
            options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
                (x) => L["ValueMustBeANumber", x]);
            options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
                (x) => L["MissingBindRequiredValue", x]);
            options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                (x, y) => L["AttemptedValueIsInvalid", x, y]);
            options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
                () => L["MissingKeyOrValue"]);
            options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
                (x) => L["UnknownValueIsInvalid", x]);
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                (x) => L["ValueMustNotBeNull", x]);

        }
    }
}
