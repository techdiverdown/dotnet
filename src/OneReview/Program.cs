using OneReview.Persistence.Database.Scripts;
using OneReview.Services;

var builder = WebApplication.CreateBuilder(args);
{
  //configure services with DI
  builder.Services.AddScoped<ProductsService>();
  builder.Services.AddControllers();
}

var app = builder.Build();
{
    // configure request pipeline
    app.MapControllers();
        
    // DbInitializer.Initialize(app.Configuration[]);
}

app.Run();

