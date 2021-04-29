using MarsRover.Library;
using MarsRover.Library.Interface;
using System;
using Validator;
using Xunit;

namespace UnitTests
{
    public class SurfaceTest
    {
        [Theory]
        [InlineData("1 2 3")]
        [InlineData("6")]
        [InlineData("4 2 1 5")]
        public void CreateSurface_ThrowsLengthException_WhenInputStringNotHasOnlyOneSpace(string coordinates)
        {
            Assert.Throws<ArgumentException>(() => Validation.ValidateCoordinates(coordinates));
        }

        [Theory]
        [InlineData("1 A")]
        [InlineData("B 2")]
        public void CreateSurface_ThrowsIntegerTypeException_WhenInputStringHasChar(string coordinates)
        {
            Assert.Throws<ArgumentException>(() => Validation.ValidateCoordinates(coordinates));
        }

        [Theory]
        [InlineData("5 5")]
        [InlineData("7 8")]
        public void CreateSurface_ReturnsISurface_WhenInputInCorrectFormat(string coordinates)
        {
            ICoordinate surface = new Surface(coordinates);
            Assert.NotNull(surface);
            Assert.True(surface.X > 0 && surface.Y > 0);
        }
    }
}
