

using SOSPets.Data;
using SOSPets.Services;
using SOSPets.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddDbContext<DataContextDatabase>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


app.Run();
