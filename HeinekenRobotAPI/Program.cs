using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.Mapper;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Repository.Repo;
using HeinekenRobotAPI.Service.IServices;
using HeinekenRobotAPI.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddScoped(typeof(IBaseDAO<,>), typeof(BaseDAO<,>));
builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<ICampaignRobotMachineService, CampaignRobotMachineService>();
builder.Services.AddScoped<ICampaignRobotMachineRepository, CampaignRobotMachineRepository>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IGiftRedemptionRepository, GiftRedemptionRepository>();
builder.Services.AddScoped<IGiftRedemptionService, GiftRedemptionService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IRecycleMachineRepository, RecycleMachineRepository>();
builder.Services.AddScoped<IRecycleMachineService, RecycleMachineService>();



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
