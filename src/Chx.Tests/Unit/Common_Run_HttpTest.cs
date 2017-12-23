﻿using Chx.Common.Run;
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
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndHeader_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string header)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("header", header));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = test.Run(webRequest.Object);

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
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndMethod_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string method)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("method", method));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = test.Run(webRequest.Object);

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
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndSearchFor_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string searchFor)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("searchfor", searchFor));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();
            webRequest.Setup(x => x.GetResponse()).Returns("response from a http server");

            //Act
            var value = test.Run(webRequest.Object);

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
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndTimeout_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string timeout)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("timeout", timeout));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = test.Run(webRequest.Object);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        //[InlineData(ActivityStatus.Fail, @"http://uri", "a string")]
        [InlineData(ActivityStatus.Success, @"http://uri", "response")]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [InlineData(ActivityStatus.Success, @"http://uri", "     ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndProxy_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string proxy)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("proxy", proxy));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();
            webRequest.Setup(x => x.GetResponse()).Returns("response from a http server");

            //Act
            var value = test.Run(webRequest.Object);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "message")]
        [InlineData(ActivityStatus.Success, @"http://uri", "   ")]
        [InlineData(ActivityStatus.Success, @"http://uri", null)]
        [InlineData(ActivityStatus.Success, @"http://uri", "")]
        [Trait("Unit", "HttpTest")]
        public void Run_WithUriAndBody_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string body)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("body", body));
            parameterSet.Parameters.Add(new ActivityParameter("method", "post"));
            var test = new HttpTest(parameterSet);
            var webRequest = new Mock<IWebRequest>();

            //Act
            var value = test.Run(webRequest.Object);

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }
    }
}
