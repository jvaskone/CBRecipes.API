using CBRecipes.API;
using CBRecipes.API.DbContexts;
using CBRecipes.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<RecipesDataStore>();


var connectionString = builder.Configuration["ConnectionStrings:CBRecipesDBConnectionString"];
if (connectionString != null) 
{
    builder.Services.AddDbContext<CBRecipesContext>(
        dbContextOptions => dbContextOptions.UseSqlite(
            connectionString
        ));
}
else
{
    Console.Out.WriteLine("No connection string was found.");
}

builder.Services.AddScoped<ICBRecipesRepository, CBRecipesRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
