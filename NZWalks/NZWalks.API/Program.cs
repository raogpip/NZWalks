using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Repos;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<NZWalksDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks"));
        });

        builder.Services.AddScoped<IRegionRepository, RegionRepo>();
        builder.Services.AddScoped<IWalkRepository, WalkRepo>();
        builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepo>();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
    }
}