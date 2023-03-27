using Microsoft.AspNetCore.Mvc;

namespace WebApiAppWithControllers.Controllers;

[ApiController]
[Route("[controller]")]
public class TryParseDemoController : ControllerBase
{
    [HttpGet(Name = "TryParseInt")]
    public IActionResult Get([FromQuery] IntParser parser)
    {
        if (parser?.Value == null)
            return NoContent();

        return Ok(parser.Value);
    }
}

public class IntParser
{
    public int? Value { get; set; }

    public static bool TryParse(int? input, out IntParser? result)
    {
        if (input is null)
        {
            result = default;
            return false;
        }

        result = new IntParser { Value = input };
        return true;
    }
}