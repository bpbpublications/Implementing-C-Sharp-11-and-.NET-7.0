using Microsoft.AspNetCore.Mvc;

namespace WebApiAppWithControllers.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        _logger.LogInformation("Obtaining 5-day weather forecast.");

        try
        {
            var forecast = _weatherForecastService.GetFiveDayForecast();
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error obtaining weather forecast;");
            throw;
        }
    }
    
    [HttpGet("injected-service")]
    public IActionResult GetFromService(IWeatherForecastService weatherForecastService)
    {
        _logger.LogInformation("Obtaining 5-day weather forecast.");

        try
        {
            var forecast = weatherForecastService.GetFiveDayForecast();
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error obtaining weather forecast;");
            throw;
        }
    }
}