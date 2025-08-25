using Microsoft.AspNetCore.Mvc;

namespace Day30_SimpleSessionDemo.Controllers;

public class SessionController : Controller
{
    // To get this in url /Session/SetSession?key=yourKey&value=yourValue 
    public IActionResult SetSession(string key, string value)
    {
        HttpContext.Session.SetString(key, value);
        return Ok();
    }

// To get this in url /Session/GetSession?key=yourKey
    public IActionResult GetSession(string key)
    {
        var value = HttpContext.Session.GetString(key);
        return Ok(value);
    }

    // To get this in url /Session/RemoveSession?key=yourKey
    public IActionResult RemoveSession(string key)
    {
        HttpContext.Session.Remove(key);
        return Ok();
    }
}