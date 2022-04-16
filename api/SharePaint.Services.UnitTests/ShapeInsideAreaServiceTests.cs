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
        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice1_IsOutsideArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 10, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice2_IsOutsideArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 120,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 110, Y = 110 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice3_IsOutsideArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 90 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Triangle_IsInsideArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Triangle_IsInsideArea_WithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Triangle_IsInsideArea_NotWithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice1_IsOutsideReversedArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 10, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice2_IsOutsideReversedArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 120,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 110, Y = 110 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_TriangleVertice3_IsOutsideReversedArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 90 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Triangle_IsInsideReversedArea()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Triangle_IsInsideReversedArea_WithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Triangle_IsInsideReversedArea_NotWithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(triangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion

        #region Rectangle

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleLeft_IsOutsideArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 10, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleRight_IsOutsideArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 90, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleTop_IsOutsideArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 10 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleBottom_IsOutsideArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 90 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Rectangle_IsInsideArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0, Y = 0 };
            Coord2D point2 = new Coord2D() { X = 100, Y = 100 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Rectangle_IsInsideArea_WithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Rectangle_IsInsideArea_NotWithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleLeft_IsOutsideReversedArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 10, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleRight_IsOutsideReversedArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 90, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleTop_IsOutsideReversedArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 10 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_RectangleBottom_IsOutsideReversedArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 90 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Rectangle_IsInsideReversedArea()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Rectangle_IsInsideReversedArea_WithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Rectangle_IsInsideReversedArea_NotWithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    }
                }
            };
            Coord2D point1 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(rectangle, area);

            // Assert
            Assert.AreEqual(false, result);
        }
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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

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
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleCenter_IsOutsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 500, Y = 500 };
            Coord2D point2 = new Coord2D() { X = 125, Y = 125 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleLeft_IsOutsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 10, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleRight_IsOutsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 90, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleTop_IsOutsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 10 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_CircleBottom_IsOutsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 100, Y = 90 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Circle_IsInsideReversedArea()
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
            Coord2D point1 = new Coord2D() { X = 100, Y = 100 };
            Coord2D point2 = new Coord2D() { X = 0, Y = 0 };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnTrue_When_Circle_IsInsideReversedArea_WithinTolerance()
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
            Coord2D point1 = new Coord2D() { X = 100 - 0.75 * Double.Tolerance, Y = 100 - 0.75 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 0.75 * Double.Tolerance, Y = 0 - 0.75 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeInsideArea_Should_ReturnFalse_When_Circle_IsInsideReversedArea_NotWithinTolerance()
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
            Coord2D point1 = new Coord2D() { X = 100 - 1.25 * Double.Tolerance, Y = 100 - 1.25 * Double.Tolerance };
            Coord2D point2 = new Coord2D() { X = 0 - 1.25 * Double.Tolerance, Y = 0 - 1.25 * Double.Tolerance };
            Area2D area = new Area2D() { Point1 = point1, Point2 = point2 };

            // Act
            bool result = _sut.IsShapeInsideArea(circle, area);

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion
    }
}
