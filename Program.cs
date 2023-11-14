using Microsoft.EntityFrameworkCore;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Repositories;
using PracticeAPI.Services.Contracts;
using PracticeAPI.Services;
using PracticeAPI.Models;
using PracticeAPI.Helpers;
using System.Reflection;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddDbContext<MyStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyStore"));
});

builder.Services.AddCors();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practice API", Version = "v1" });

    // Include the JWT bearer token in the Swagger requests
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services.Configure<SwaggerGeneratorOptions>(options =>
{
    options.InferSecuritySchemes = true;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Remember to set to true on production
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                        (config["JwtToken:NotTokenKeyForSureSourceTrustMeDude"])),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = config["JwtToken:Issuer"],
                    ValidAudience = config["JwtToken:Audience"],
                    RoleClaimType = ClaimTypes.Email
                };
            });

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email, "Admin"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:7106")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
