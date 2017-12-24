using Chx.Common.Run;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chx.Tests.Integration
{
    public class Common_Run_HttpTest
    {
        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.BadParameters, "", "")]
        [InlineData(ActivityStatus.Fail, @"http://google.com", "something that would not be found!!!!!")]
        [InlineData(ActivityStatus.Success, @"http://google.com", "google")]
        public void Run_WithUriAndSearchFor_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string searchFor)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("searchfor", searchFor));
            var test = new HttpTest(parameterSet);

            //Act
            var value = test.Run();

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }

        [Theory]
        [InlineData(ActivityStatus.BadParameters, null, null)]
        [InlineData(ActivityStatus.Fail, @"http://google.com", "message")]
        [InlineData(ActivityStatus.Fail, @"http://google.com", "   ")]
        [InlineData(ActivityStatus.Fail, @"http://google.com", null)]
        public void Run_WithUriAndBody_ReturnsValidResponse(ActivityStatus expectedStatus, string uri, string body)
        {
            //Arrange
            var parameterSet = new ActivityParameterSet();
            parameterSet.Parameters.Add(new ActivityParameter("uri", uri));
            parameterSet.Parameters.Add(new ActivityParameter("body", body));
            parameterSet.Parameters.Add(new ActivityParameter("method", "post"));
            var test = new HttpTest(parameterSet);

            //Act
            var value = test.Run();

            //Assert
            Assert.Equal(expectedStatus, value.ActivityStatus);
        }
    }
}
