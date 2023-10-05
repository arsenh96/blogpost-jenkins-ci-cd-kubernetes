using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp
{
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase  // Vergeet niet ControllerBase te erven
    {
        [HttpGet]
        public string GetHelloWorld()  // async en Task<string> verwijderd
        {
            return "Hello, World!";
        }
    }
}
