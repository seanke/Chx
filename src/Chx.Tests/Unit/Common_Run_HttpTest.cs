using Chx.Common.Run;
using Moq;
using Xunit;

namespace Chx.Tests.Unit
{
    public class Common_Run_HttpTest
    {
        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.BadParameters, null, "header:value")]
        [InlineData(ActivityStatus.Success, @"http://uri", "value")]
        [InlineData(ActivityStatus.Success, @"http://uri", "value,header")]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "value:")]
        [InlineData(ActivityStatus.Success, @"http://uri", "value:header")]
        [InlineData(ActivityStatus.Success, @"http://uri", "value:header:")]
        [InlineData(ActivityStatus.Success, @"http://uri", "value:header:header")]
        [InlineData(ActivityStatus.BadParameters, @"bad uri!!", "value:header")]
        [InlineData(ActivityStatus.BadParameters, @"", "value:header")]
        [InlineData(ActivityStatus.BadParameters, @"uri", "value:header")]
        public void Run_WithUriAndHeader_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string header)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("header", header));
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "get")]
        [InlineData(ActivityStatus.Success, @"http://uri", "   ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [InlineData(ActivityStatus.Success, @"http://uri", "POST")]
        [InlineData(ActivityStatus.Success, @"http://uri", "SomeOtherMethod")]
        public void Run_WithUriAndMethod_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string method)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("method", method));
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Fail, @"http://uri", "a string")]
        [InlineData(ActivityStatus.Success, @"http://uri", "response")]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [InlineData(ActivityStatus.Success, @"http://uri", "     ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        public void Run_WithUriAndSearchFor_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string searchFor)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("searchfor", searchFor));
            var webRequest = new Mock<IWebRequest>();
            webRequest.Setup(x => x.GetResponse()).Returns("response from a http server");

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "1")]
        [InlineData(ActivityStatus.Success, @"http://uri", "   ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [InlineData(ActivityStatus.Success, @"http://uri", "string")]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "-500")]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "0")]
        [InlineData(ActivityStatus.Success, @"http://uri", "123456789123456789")]
        public void Run_WithUriAndTimeout_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string timeout)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("timeout", timeout));
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "a string")]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "response")]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "")]
        [InlineData(ActivityStatus.BadParameters, @"http://uri", "     ")]
        [InlineData(ActivityStatus.Success, @"http://uri", "http://uri")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        public void Run_WithUriAndProxy_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string proxy)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("proxy", proxy));
            var webRequest = new Mock<IWebRequest>();
            webRequest.Setup(x => x.GetResponse()).Returns("response from a http server");

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "message")]
        [InlineData(ActivityStatus.Success, @"http://uri", "   ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        public void Run_WithUriAndBody_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string body)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("body", body));
            parameterSet.Parameters.Add(new ActivityParameter("method", "post"));
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = new HttpCheck().Run(webRequest.Object, parameterSet);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }
    }
}
