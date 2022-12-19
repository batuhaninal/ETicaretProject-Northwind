using Autofac;
using Autofac.Extensions.DependencyInjection;
using ETicaret.Business.Abstract;
using ETicaret.Business.Concrete;
using ETicaret.Business.DependencyResolvers.Autofac;
using ETicaret.DataAccess.Abstract;
using ETicaret.DataAccess.Concrete.EntityFramework.Repositories;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductRepository, EfProductRepository>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
