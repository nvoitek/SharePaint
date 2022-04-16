using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharePaint.Models;
using SharePaint.Services.Utils;
using System.Collections.Generic;

namespace SharePaint.Services.UnitTests
{
    [TestClass]
    public class ShapeUnderPointServiceTests
    {
        private readonly ShapeUnderPointService _sut = new ShapeUnderPointService();

        #region Triangle
        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Vertice1_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 0, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Vertice2_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Vertice3_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Vertice_Is_UnderPoint_WithinTolerance()
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
            Coord2D point = new Coord2D() { X = 100 + .75 * Double.Tolerance, Y = 100 + .75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_RightTriangle_Vertice_Is_UnderPoint_NotWithinTolerance()
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
            Coord2D point = new Coord2D() { X = 100 + 1.25 * Double.Tolerance, Y = 100 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Side1_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 50, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Side2_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 50, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Side3_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_RightTriangle_Side_Is_UnderPoint_WithinTolerance()
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
            Coord2D point = new Coord2D() { X = 100 + .75 * Double.Tolerance, Y = 50 + .75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_RightTriangle_Side_Is_UnderPoint_NotWithinTolerance()
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
            Coord2D point = new Coord2D() { X = 100 + 1.25 * Double.Tolerance, Y = 50 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsInside_RightTriangle()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 25 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOutside_RightTriangle()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 125, Y = 125 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Vertice1_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Vertice2_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Vertice3_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Vertice_Is_UnderPoint_WithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100 + .75 * Double.Tolerance, Y = 100 + .75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_ReverseRightTriangle_Vertice_Is_UnderPoint_NotWithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100 + 1.25 * Double.Tolerance, Y = 100 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Side1_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Side2_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Side3_Is_UnderPoint()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRightTriangle_Side_Is_UnderPoint_WithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100 + .75 * Double.Tolerance, Y = 50 + .75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_ReverseRightTriangle_Side_Is_UnderPoint_NotWithinTolerance()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100 + 1.25 * Double.Tolerance, Y = 50 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsInside_ReverseRightTriangle()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 25 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOutside_ReverseRightTriangle()
        {
            // Arrange
            Shape triangle = new Shape()
            {
                ShapeType = ShapeType.Triangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    },
                    new Coord2D() {
                        X = 100,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 125, Y = 125 };

            // Act
            bool result = _sut.IsShapeUnderPoint(triangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion

        #region Rectangle
        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Vertice1_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 0, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Vertice2_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Vertice3_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Vertice4_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 0, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Vertice_Is_UnderPoint_WithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + 0.75 * Double.Tolerance, Y = 100 + 0.75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_Rectangle_Vertice_Is_UnderPoint_NotWithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + 1.25 * Double.Tolerance, Y = 100 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Side1_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 50, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Side2_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 100, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Side3_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 50, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Side4_Is_UnderPoint()
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
            Coord2D point = new Coord2D() { X = 0, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_Rectangle_Side_Is_UnderPoint_WithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + 0.75 * Double.Tolerance, Y = 50 + 0.75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_Rectangle_Side_Is_UnderPoint_NotWithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + 1.25 * Double.Tolerance, Y = 50 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_PointIsInside_Rectangle()
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
            Coord2D point = new Coord2D() { X = 25, Y = 25 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOutside_Rectangle()
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
            Coord2D point = new Coord2D() { X = 125, Y = 125 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Vertice1_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Vertice2_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Vertice3_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Vertice4_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Vertice_Is_UnderPoint_WithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0 + 0.75 * Double.Tolerance, Y = 100 + 0.75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_ReverseRectangle_Vertice_Is_UnderPoint_NotWithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0 + 1.25 * Double.Tolerance, Y = 100 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Side1_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 0 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Side2_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 100, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Side3_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 50, Y = 100 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Side4_Is_UnderPoint()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_ReverseRectangle_Side_Is_UnderPoint_WithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0 + 0.75 * Double.Tolerance, Y = 50 + 0.75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_ReverseRectangle_Side_Is_UnderPoint_NotWithinTolerance()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 0 + 1.25 * Double.Tolerance, Y = 50 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_PointIsInside_ReverseRectangle()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 25, Y = 25 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOutside_ReverseRectangle()
        {
            // Arrange
            Shape rectangle = new Shape()
            {
                ShapeType = ShapeType.Rectangle,
                Points = new List<Coord2D>() {
                    new Coord2D() {
                        X = 100,
                        Y = 100
                    },
                    new Coord2D() {
                        X = 0,
                        Y = 0
                    }
                }
            };
            Coord2D point = new Coord2D() { X = 125, Y = 125 };

            // Act
            bool result = _sut.IsShapeUnderPoint(rectangle, point);

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion

        #region Circle
        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_PointIsOn_Circle()
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
            Coord2D point = new Coord2D() { X = 0, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(circle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_PointIsOn_Circle_WithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + .75 * Double.Tolerance, Y = 50 + .75 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(circle, point);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOn_Circle_NotWithinTolerance()
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
            Coord2D point = new Coord2D() { X = 0 + 1.25 * Double.Tolerance, Y = 50 + 1.25 * Double.Tolerance };

            // Act
            bool result = _sut.IsShapeUnderPoint(circle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnTrue_When_PointIsInside_Circle()
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
            Coord2D point = new Coord2D() { X = 50, Y = 50 };

            // Act
            bool result = _sut.IsShapeUnderPoint(circle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShapeUnderPoint_Should_ReturnFalse_When_PointIsOutside_Circle()
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
            Coord2D point = new Coord2D() { X = 125, Y = 125 };

            // Act
            bool result = _sut.IsShapeUnderPoint(circle, point);

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion
    }
}
