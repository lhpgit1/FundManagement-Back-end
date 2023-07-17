using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationtest1.Data.Repositories;
using WebApplicationtest1.Services;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationtest1.Services.Impl;
using WebApplicationtest1.Profiles;
using WebApplicationtest1.Data.Repositories.Impl;

var builder = WebApplication.CreateBuilder(args);
//db
builder.Services.AddDbContext<WebApplicationtest1.Models.FundmanagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FundmanagementDbContext")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IFundRepository, FundRepository>();
builder.Services.AddScoped<IFundTrendRepository,FundTrendRepository>();
builder.Services.AddScoped<IFundService, FundServiceImpl>();
builder.Services.AddScoped<FundServiceImpl>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockServiceImpl>();
builder.Services.AddScoped<IStockTrendRepository, StockTrendRepository>();
builder.Services.AddScoped<StockServiceImpl>();
builder.Services.AddScoped<IInvestmentPortfolioRepository,InvestmentPortfolioRepository>();
builder.Services.AddScoped<IInvestmentPortfolioService,InvestmentPortfolioServiceImpl>();
builder.Services.AddScoped<InvestmentPortfolioServiceImpl>();
builder.Services.AddScoped<ITransRecordRepository,TransRecordRepository>();
builder.Services.AddScoped<ITransRecordService, TransRecordServiceImpl>();
builder.Services.AddScoped<TransRecordServiceImpl>();
builder.Services.AddControllers();
builder.Services.AddMvc();
//AutoMapper×¢²á
builder.Services.AddAutoMapper(typeof(PortfolioDtoProfile));
builder.Services.AddAutoMapper(typeof(TransRecordDtoProfile));
builder.Services.AddAutoMapper(typeof(FundTrendDtoProfile));
builder.Services.AddAutoMapper(typeof(FundCureDtoProfile));

// Add services to the container.
builder.Services.AddControllersWithViews();
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
app.UseCors();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
