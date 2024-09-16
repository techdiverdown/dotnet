using OneReview.Persistence.Database;
using OneReview.Services;

var builder = WebApplication.CreateBuilder(args);
{
  //configure services with DI
  builder.Services.AddScoped<ProductsService>();
  builder.Services.AddScoped<ReviewsService>();
  builder.Services.AddControllers();
}

var app = builder.Build();
{
    // configure request pipeline
    app.MapControllers();
    Console.WriteLine("here is the connection string: " + 
                      app.Configuration["Database:ConnectionStrings:DefaultConnection"]);
    //DbInitializer.Initialize(app.Configuration["Database:ConnectionStrings:DefaultConnection"]!);
    DbInitializer.Initialize(app.Configuration["Database:ConnectionStrings:DefaultConnection"]!);
}


app.Run();

