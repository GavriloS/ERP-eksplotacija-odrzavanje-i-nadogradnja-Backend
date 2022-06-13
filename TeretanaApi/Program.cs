using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using TeretanaApi.Auth;
using TeretanaApi.Data;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities.DataContext;
using TeretanaApi.Helper;
using TeretanaApi.StripeSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(setupAction => //Podrzavanje Problem Details for http APIs
    {
        setupAction.InvalidModelStateResponseFactory = context =>
        {
            ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                .GetRequiredService<ProblemDetailsFactory>();

            //Prevodi validacione greške iz ModelState-a u RFC format
            ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);
            problemDetails.Detail = "Pogledajte Error polje za detaljnije informacije.";
            problemDetails.Instance = context.HttpContext.Request.Path;

            //Definisemo da za validacione greske ne zelimo status kod 400 nego 422 - UnprocessibleEntity
            var actionExecutiongContext = context as ActionExecutingContext;
            if ((context.ModelState.ErrorCount > 0) && (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
            {
                problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                problemDetails.Title = "Desila se greška prilikom validacije.";

                //Sve se vraca kao UnprocessibleEntity objekat
                return new UnprocessableEntityObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }

            //Ako nesto ne moze da se parsira vraca se status kod 400 - Bad Request
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = "Desila se greška prilikom parsiranja.";
            return new BadRequestObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" }
            };
        };
    }); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization header using the bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Stripe
ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<StripeSettings>(configuration.GetSection("Stripe"));

//JWT
var key = "test_secure_key_5302_test";
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSingleton<JwtAuthManager>(new JwtAuthManager(key));

//Repositories
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IGroupTrainingTypeRepository,GroupTrainingTypeRepository>();
builder.Services.AddScoped<ISuplementTypeRepository,SuplementTypeRepository>();
builder.Services.AddScoped<ISuplementRepository,SuplementRepository>();
builder.Services.AddScoped<IEquipmentRepository,EquipmentRepository>();
builder.Services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IGroupTrainingRepository, GroupTrainingRepository>();
builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
builder.Services.AddScoped<IMembershipRepository,MembershipRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IBasketEquipmentRepository, BasketEquipmentRepository>();
builder.Services.AddScoped<IBasketSuplementRepository, BasketSuplementRepository>();

//Helper
builder.Services.AddScoped<IProcessStripeEvents, ProcessStripeEvents>();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<GymContext>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

StripeConfiguration.ApiKey = configuration.GetValue<string>("Stripe:SecretKey");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseCors("corsapp");
app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("http://localhost:4200"));

app.Run();
