using eCommerceInfrastucture;
using eCommerce.Core;
using eCommerce.API.MiddleWares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mapper;
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
