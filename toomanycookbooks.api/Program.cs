using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Configuration;
using TooManyCookbooks.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddSingleton(sp => sp.GetService<IConfiguration>()!.GetSection(GlobalConfiguration.Name).Get<GlobalConfiguration>());

builder.Services.AddDbContext<TmcbDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(TmcbDbContext)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(builder =>
{
    builder.MapControllers();
    builder.MapHealthChecks("/api/status");
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<TmcbDbContext>();
    if ((await db!.Database.GetPendingMigrationsAsync()).Any())
    {
        await db!.Database.MigrateAsync();
    }

    await DataSeed.AddAsync(db);
}

app.Run();
