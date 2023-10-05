global using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class HelloWorldControllerTests
    {
        [Fact]
        public void TestControllerReturnValueIsHelloWorld()
        {
            //Arrange
            var controller = new HelloWorldController();

            //Act
            var response = controller.GetHelloWorld();

            //Assert
            Assert.Equal("Hello, World!", response);
        }
    }
}
