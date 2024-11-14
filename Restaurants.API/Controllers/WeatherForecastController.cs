using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class TemperatureRequest()
{
    public int Min { get; set; }
    public int Max { get; set; }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpPost]
    [Route("generate")]
    public IActionResult Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
    {
        if (count < 0 || request.Max < request.Min)
        {
            return BadRequest("error");
        }
        var result = _weatherForecastService.Get(count, request.Min, request.Max);
        return Ok(result);
    }
}