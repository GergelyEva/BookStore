using BookStore.Application.GetWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,IMediator mediator)
    {
      _logger = logger;
      this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(CancellationToken token)
    {
      var response = await this.mediator.Send(new GetWeatherForecastRequest(), token);
      return this.Ok(response);
    }
  }
}
