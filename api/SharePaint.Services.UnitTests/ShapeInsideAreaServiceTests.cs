using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharePaint.Models;
using SharePaint.Services.Utils;
using System.Collections.Generic;

namespace SharePaint.Services.UnitTests
{
    [TestClass]
    public class ShapeInsideAreaServiceTests
    {
        private readonly ShapeInsideAreaService _sut = new ShapeInsideAreaService();

        #region Triangle
        #endregion

        #region Rectangle
        #endregion

        #region Circle
        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleCenter_IsOutsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 125, Y = 125 };
            Coord2D point2 = new Coord2D() { X = 500, Y = 500 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleLeft_IsOutsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 10, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleRight_IsOutsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 90, Y = 100 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleTop_IsOutsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 10 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleBottom_IsOutsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 90 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Circle_IsInsideArea()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Circle_IsInsideArea_WithinTolerance()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Circle_IsInsideArea_NotWithinTolerance()
        {
            // Arrange
            Shape circle = new Shape()
            {
                ShapeType = ShapeType.Circle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 50,
                        Y = 50
                    },
                    new Coord2D() {
                        X = 50,
                        Y = 0
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, point1, point2);

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion
    }
}
