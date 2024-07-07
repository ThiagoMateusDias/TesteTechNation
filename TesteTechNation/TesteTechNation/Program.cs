using Microsoft.EntityFrameworkCore;
using TesteTechNation.Business.Interface;
using TesteTechNation.Business.Services;
using TesteTechNation.Data.Repository;
using TesteTechNation.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddConfigurationContext(builder.Configuration);

builder.Services.ResolveDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public static class ContextConfig
{
    public static IServiceCollection AddConfigurationContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DashBoardFiscaisContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<DashBoardFiscaisContext>();

        services.AddScoped<NotaFiscalRepository>();

        services.AddScoped<TipoPagamentoRepository>();

        services.AddScoped<StatusNotaRepository>();

        services.AddScoped<INotaFiscalService, NotaFiscalService>();

        services.AddScoped<IStatusNotaService, StatusNotaService>();

        services.AddScoped<ITipoPagamentoService, TipoPagamentoService>();

        return services;
    }
}