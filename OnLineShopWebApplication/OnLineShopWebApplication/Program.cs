using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnLineShop.Db;
using OnLineShop.Db.Data;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Helpers;
using Serilog;


namespace OnLineShopWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("online_book_shop");

			// Add services to the container.

			builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
			builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
			builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
			builder.Services.AddTransient<IFavoritesRepository, FavoritesDbRepository>();

			//builder.Services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
			//builder.Services.AddSingleton<IUsersManager, UserManager>();

			builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

            builder.Services.AddTransient<ImagesProvider>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //добавляем контекст IndentityContext в качестве сервиса в приложение
            builder.Services.AddIdentity<User, IdentityRole>(opts => {
				opts.Password.RequiredLength = 5;   // минимальная длина
				opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
				opts.Password.RequireDigit = false; // требуются ли цифры
			})

			// устанавливаем тип хранилища - IdentityContext
			.AddEntityFrameworkStores<IdentityContext>();

            builder.Services.AddControllersWithViews();

			// настройка cookie
			builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
            {
                loggerConfiguration
                .ReadFrom.Configuration(hostContext.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Book Shop");
            });

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<User>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityInitializer.Initialize(userManager, rolesManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
        }
    }
}