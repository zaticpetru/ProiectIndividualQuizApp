using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Settings;
using QuizApp.Core;
using QuizApp.Core.Models.Auth;
using QuizApp.Core.Servicies;
using QuizApp.Data;
using QuizApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Dependecy injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMusicService, MusicService>();
builder.Services.AddTransient<IArtistService, ArtistService>();

var connectionString = builder.Configuration.GetConnectionString("Default");

// DB context
builder.Services.AddDbContext<QuizAppDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("QuizApp.Data"))
    );

// Identity
// AddIdentity takes the two implementations of IdentityUser and IdentityRole.
builder.Services.AddIdentity<User, Role>()
    // AddEntityFrameworkStores tells that our QuizAppDbContext
    // is going to be where our Identity’s information is stored
    .AddEntityFrameworkStores<QuizAppDbContext>()
    //AddDefaultTokenProviders just adds the default providers to generate tokens for
    //a password reset, 2-factor authentication, change email, and change telephone
    .AddDefaultTokenProviders();

//AddIdentity<User, Role>(options =>
//{
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//})
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For better error pages
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
