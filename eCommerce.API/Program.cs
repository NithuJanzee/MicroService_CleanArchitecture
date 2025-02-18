using eCommerceInfrastucture;
using eCommerce.Core;
using eCommerce.API.MiddleWares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mapper;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

//before build add infrastucture service 
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add the controller to the service collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();
app.UseExeptionHandlingMiddleWare();

//Routing 
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization(); 

//controller route
app.MapControllers();

app.Run();
