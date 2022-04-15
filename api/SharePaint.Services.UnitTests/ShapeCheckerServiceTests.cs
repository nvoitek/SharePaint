using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharePaint.Models;
using System.Collections.Generic;

namespace SharePaint.Services.UnitTests
{
    [TestClass]
    public class ShapeCheckerServiceTests
    {
        private readonly ShapeCheckerService _sut = new ShapeCheckerService();

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
            Coord2D point = new Coord2D() { X = 100 + (int)(.75 * _sut.Tolerance), Y = 100 + (int)(.75 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(1.25 * _sut.Tolerance), Y = 100 + (int)(1.25 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(.75 * _sut.Tolerance), Y = 50 + (int)(.75 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(1.25 * _sut.Tolerance), Y = 50 + (int)(1.25 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(.75 * _sut.Tolerance), Y = 100 + (int)(.75 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(1.25 * _sut.Tolerance), Y = 100 + (int)(1.25 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(.75 * _sut.Tolerance), Y = 50 + (int)(.75 * _sut.Tolerance) };

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
            Coord2D point = new Coord2D() { X = 100 + (int)(1.25 * _sut.Tolerance), Y = 50 + (int)(1.25 * _sut.Tolerance) };

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
    }
}
