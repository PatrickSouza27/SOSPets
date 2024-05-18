using Amazon;
using SOSPets.Data;
using SOSPets.Services;
using SOSPets.Services.AWSService;
using SOSPets.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddDbContext<DataContextDatabase>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMapService, MapService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IProfilePetService, ProfilePetService>();
builder.Services.AddTransient<IS3Service>(_ => new S3Service(RegionEndpoint.USEast1));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


app.Run();
