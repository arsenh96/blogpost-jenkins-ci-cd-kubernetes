using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp
{
    [ApiController]
    public class HelloWorldController
    {
        [HttpGet]
        public async Task<string> GetHelloWorld()
        {
            return "Hello, World!";
        }
    }
}
