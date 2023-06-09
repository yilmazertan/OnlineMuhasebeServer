using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Persistance.Context;
using OnlineMuhasebeServer.Presentation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Persistance.Services.AppService;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMediatR(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(OnlineMuhasebeServer.Persistance.AssemblyReference).Assembly);

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    setup =>
    {
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            BearerFormat="JWT",
            Name="JWT Authentication",
            In=ParameterLocation.Header,
            Type=SecuritySchemeType.Http,
            Scheme=JwtBearerDefaults.AuthenticationScheme,
            Description="Put **_ONLY_** your JWT Bearer token on textbox below!",
            Reference= new OpenApiReference
            {
                Id= JwtBearerDefaults.AuthenticationScheme,
                Type=ReferenceType.SecurityScheme
            }

        };

        setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        setup.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {jwtSecurityScheme,Array.Empty<string>() }
        });
        }
    );

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
