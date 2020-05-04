using System;
using System.Linq;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange: prepare code in order to call a method needed to test
            // Ex: instantiate instance of the class containing code we're testing
            var tacoParser = new TacoParser();
            //Act: actually call the method that we're testing
            var actual = tacoParser.Parse(line);
            //Assert: check against a constant (actual, expected)
            //(think of what you're asserting. Use dot notation and properties)
            Assert.Equal(expected, actual.Location.Longitude); //.Location lets u access longitude, latitude within it
        }


        //DONE Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser(); //Arrange
            var actual = tacoParser.Parse(line); //Act
            Assert.Equal(expected, actual.Location.Latitude); //Assert
        }
    }
}
