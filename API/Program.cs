using API.Extensions;
using API.Middleware;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Use the extensions for cleaning the program class
builder.Services.AddApplicationServices(builder.Configuration);

// Added extensions Identity
builder.Services.AddIdentityServices(builder.Configuration); // Identity

builder.Services.AddSwaggerDocumentation(); //Swagger extensions

var app = builder.Build();

// Use the Middleware for servererror (2)
app.UseMiddleware<ExceptionMiddleware>();

// Admin the error, Example {{url}}/api/endpointthatdoesnotexist (1)
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwaggerDocumentation(); //Swagger extensions

// For the pics
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication(); // Identity
app.UseAuthorization();

app.MapControllers();

// For migrate the data
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<RentalContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

var userManager = services.GetRequiredService<UserManager<AppUser>>();
var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();

try
{
    await context.Database.MigrateAsync();
    await RentalContextSeed.SeedAsync(context);


    await identityContext.Database.MigrateAsync();
    await AppIdentityDbContextSeed.SeedUsersAsync(userManager, roleManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error ocurring during migration");
}


app.Run();
