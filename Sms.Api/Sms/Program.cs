using Application.Commands.Standards;
using Domain.Data;
using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Sms.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* AutoMapping, EdmBuilder, ConfigurationSection */
//builder.Services.AddConfigurationSectionBindings(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapping));

/* HTTP_CONTEXT_ACCESSOR */
builder.Services.AddHttpContextAccessor();

/* Data base connection string */
builder.Services.AddDbContext<SmsDevContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(SmsDevContext));
    options.UseSqlServer(connectionString);
});

/* CORS */
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
/* EDM Model */
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
        options.SerializerSettings.Formatting = Formatting.None;
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddOData(options =>
    {
        options.TimeZone = TimeZoneInfo.Utc;
        options.Count().Filter().Expand().Select().OrderBy().SetMaxTop(200)
            .AddRouteComponents("odata", EdmModelBuilder.GetEdmModel());
    });

builder.Services.AddMediatR(typeof(GetStandardQuery).GetTypeInfo().Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = " Api", Version = "v1.0.0" });
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchema, new[] {"Bearer"}}
    });
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
