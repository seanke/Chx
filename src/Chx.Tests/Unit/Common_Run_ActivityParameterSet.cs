using Chx.Common.Run;
using Chx.Tests.Common;
using Xunit;

namespace Chx.Tests.Unit
{
    public class Common_Run_ActivityParameterSet
    {
        [Theory]
        [InlineData("    another_one", "2")]
        [InlineData("    another_one       ", "2")]
        [InlineData("myparameter    ", "1")]
        [InlineData("LAstONE", "4")]
        [Trait("Unit", "ActivityParameterSet")]
        public void GetFirstParameterValue_WithExistingParameterName_ReturnsFirstValue(string parameterName, string expectedValue)
        {
            //Arrange
            ActivityParameterSet set = Examples.ActivityParameterSet_NullName;

            //Act
            var value = set.GetFirstParameterValue(parameterName);

            //Assert
            Assert.NotNull(value);
            Assert.Equal(expectedValue, value);
        }

        [Theory]
        [InlineData("    another_one", "2", 2)]
        [InlineData("    another_one       ", "3", 2)]
        [InlineData("myparameter    ", "1", 1)]
        [InlineData("LAstONE", "4", 1)]
        [Trait("Unit", "ActivityParameterSet")]
        public void GetParameterValues_WithExistingParameterName_ReturnsFirstValue(string parameterName, string expectedValue, int numberOfResults)
        {
            //Arrange
            ActivityParameterSet set = Examples.ActivityParameterSet_NullName;

            //Act
            var value = set.GetParameterValues(parameterName);

            //Assert
            Assert.NotNull(value);
            Assert.Contains(expectedValue, value);
            Assert.InRange(value.Count, numberOfResults, numberOfResults);
        }

        [Theory]
        [InlineData("   kjsa  ldj")]
        [InlineData("asd  asdewf")]
        [InlineData("   waeffaefwvde")]
        [Trait("Unit", "ActivityParameterSet")]
        public void GetFirstParameterValue_WithNonExistingParameterName_ReturnsNull(string parameterName)
        {
            //Arrange
            ActivityParameterSet set = Examples.ActivityParameterSet_NullName;

            //Act
            var value = set.GetFirstParameterValue(parameterName);

            //Assert
            Assert.Null(value);
        }

        [Theory]
        [InlineData("   kjsa  ldj")]
        [InlineData("asd  asdewf")]
        [InlineData("   waeffaefwvde")]
        [Trait("Unit", "ActivityParameterSet")]
        public void GetParameterValues_WithNonExistingParameterName_ReturnsEmptyList(string parameterName)
        {
            //Arrange
            ActivityParameterSet set = Examples.ActivityParameterSet_NullName;

            //Act
            var value = set.GetParameterValues(parameterName);

            //Assert
            Assert.NotNull(value);
            Assert.Empty(value);
        }
    }
}
