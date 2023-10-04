using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Tests
{
    public class HelloWorldControllerTests
    {
        [Fact]
        public async Task TestControllerReturnValueIsHelloWorld()
        {
            //Arrange
            var controller = new HelloWorldController();

            //Act
            var response = await controller.GetHelloWorld();

            //Assert
            Assert.Equal("Hello, World!", response);
        }
    }
}
