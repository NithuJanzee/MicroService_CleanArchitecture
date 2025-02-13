using eCommerceInfrastucture;
using eCommerce.Core;
using eCommerce.API.MiddleWares;
var builder = WebApplication.CreateBuilder(args);

//before build add infrastucture service 
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add the controller to the service collection
builder.Services.AddControllers();
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
