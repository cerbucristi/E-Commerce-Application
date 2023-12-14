using ECommerce.API.Utility;
using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Models;
using ECommerce.Identity;
using ECommerce.API.Utility;
using ECommerce.Application;
using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Models;
using ECommerce.Infrastructure;
using ECommerce.Identity;
using Infrastructure;
using Microsoft.OpenApi.Models;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
// Add services to the container.
builder.Services.AddInfrastrutureToDI(
    builder.Configuration);
builder.Services.AddInfrastrutureIdentityToDI(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ECommerce-Application Management API",

    });

    c.OperationFilter<FileResultContentTypeOperationFilter>();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

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
