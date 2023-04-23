using OptionsPatternDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOptions<WeatherOptions>().BindConfiguration(nameof(WeatherOptions))
    .ValidateDataAnnotations()
    .ValidateOnStart();
//.Validate(options =>
// {
//     if (options.State != "Kerala") return false;
//     return true;
// });

var weatherOptions = builder.Configuration.GetSection(nameof(WeatherOptions)).Get<WeatherOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
