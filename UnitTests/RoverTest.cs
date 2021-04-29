using MarsRover.Library;
using MarsRover.Library.Interface;
using Moq;
using System;
using System.Collections.Generic;
using Validator;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class RoverTest
    {
        private readonly ITestOutputHelper output;
        private Mock<ICoordinate> surface;
        private List<string> directions;
        public RoverTest(ITestOutputHelper output)
        {
            this.output = output;
            surface = new Mock<ICoordinate>();
            surface.Setup(m => m.X).Returns(5);
            surface.Setup(m => m.Y).Returns(5);

            directions = new List<string>() { "N", "W", "S", "E" };
        }

        [Theory]
        [InlineData("1 2 3 N")]
        [InlineData("6 W")]
        [InlineData("4 2 1 5 E")]
        public void CreateRover_ThrowsLengthException_WhenInputStringNotHasOnlyTwoSpace(string coordinates)
        {
            Assert.Throws<ArgumentException>(() => Validation.ValidateCoordinatesAndDirection(coordinates));
        }

        [Theory]
        [InlineData("1 A W")]
        [InlineData("B 2 N")]
        public void CreateRover_ThrowsIntegerTypeException_WhenFirstTwoCharacterHasChar(string coordinates)
        {
            Assert.Throws<ArgumentException>(() => Validation.ValidateCoordinatesAndDirection(coordinates));
        }

        [Theory]
        [InlineData("1 2 T")]
        [InlineData("7 8 X")]
        public void CreateRover_ThrowsDirectionException_WhenThirdCharIsNotaDirection(string coordinates)
        {
            Assert.Throws<ArgumentException>(() => Validation.ValidateCoordinatesAndDirection(coordinates));
        }

        [Theory]
        [InlineData("1 2 N")]
        [InlineData("3 3 W")]
        public void CreateRover_ReturnsIRover_WhenInputInCorrectFormat(string coordinates)
        {
            IRover rover = new Rover(coordinates, surface.Object);
            Assert.NotNull(rover);
            Assert.True(rover.X > 0 && rover.Y > 0);
        }

        [Theory]
        [InlineData("X")]
        [InlineData("Y")]
        public void Move_ReturnInvalidMovementMessage_WhenMovementCodeIsInvalid(string code)
        {
            IRover rover = new Rover("1 2 N", surface.Object);
            Assert.NotNull(rover);
            output.WriteLine($"The rover could not be moved due to an invalid movement character : {code}");
        }

        [Fact]
        public void Move_ThrowsRoverIsOurOfRangeException_WhenXCoordinateIsBiggerThanSurfaceX()
        {
            IRover rover = new Rover("5 2 E", surface.Object);
            Assert.Throws<ArgumentException>(() => rover.Move("M"));
        }

        [Fact]
        public void Move_ThrowsRoverIsOurOfRangeException_WhenYCoordinateIsBiggerThanSurfaceY()
        {
            IRover rover = new Rover("2 5 N", surface.Object);
            Assert.Throws<ArgumentException>(() => rover.Move("M"));
        }

        [Fact]
        public void Move_ReturnCorrectMovement_WhenMovementIsInSurface()
        {
            IRover rover = new Rover("1 2 N", surface.Object);
            rover.Move("M");
            rover.Move("R");
            rover.Move("M");

            Assert.Equal(2, rover.X);
            Assert.Equal(3, rover.Y);
            Assert.Equal("E", rover.Direction);
        }
    }
}
