using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using ExpenseManagementSystem.Persistence;
using ExpenseManagementSystem.Infrastructure;
using Mapster;
using ExpenseManagementSystem.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using ExpenseManagementSystem.Domain.Entities.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ExpenseManagementSystem.Infrastructure.BackgroundServices;
using FluentValidation.AspNetCore;
using ExpenseManagementSystem.Application.Validators;
using ExpenseManagementSystem.API.ExceptionHandlers;
using System.Text.Json.Serialization;
using System.Reflection;
using ExpenseManagementSystem.Domain.Enums;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<EftBackgroundService>();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMapster();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAndPersonnel",
         policy => policy.RequireRole(ApplicationRole.Admin, ApplicationRole.Personnel));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
})
.AddRoles<ApplicationRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Expense Management API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        setup.IncludeXmlComments(xmlPath);
    }

    setup.MapType<ApprovalStatus>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(ApprovalStatus))
                   .Select(name => (IOpenApiAny)new OpenApiString(name))
                   .ToList()
    });

    setup.MapType<PaymentStatus>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(PaymentStatus))
                   .Select(name => (IOpenApiAny)new OpenApiString(name))
                   .ToList()
    });


    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
////
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context => {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                error = "Unauthorized",
                message = "Bu işlem için yetkiniz bulunmamaktadır."
            }));
        }
    };
});

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    { c.RouteTemplate = "swagger/{documentName}/swagger.json"; }
 );
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Management API v1");
        c.RoutePrefix = "swagger"; 
    });
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run(); 