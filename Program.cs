using McDonalds.Models;
using McDonalds.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<McDonaldsDBContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
//   app.UseDeveloperExeceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// https://stackoverflow.com/a/53809870
// dependency inject then seed
using (var scope = app.Services.CreateScope())
{
  McDonaldsDBContext _context = scope.ServiceProvider.GetRequiredService<McDonaldsDBContext>();

  List<Food> foodList = Seeder.LoadJson("./Seeding/seeding.json");

  await Seeder.ClearTable(_context);
  await Seeder.SeedFoods(_context, foodList);
}

app.Run();

//localhost:{port}/swagger/index.html