using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;

namespace MyDrawing.Tests
{
    [TestClass]
    public class ShapesFactoryTests
    {
        private ShapesFactory shapeFactory;

        [TestInitialize()]
        public void Initailize()
        {
            MockGraphics _mockGraphics = new MockGraphics();
            shapeFactory = new ShapesFactory();

        }
        [TestMethod]
        public void CreatShape_StartShape_ReturnsStartInstance()
        {
            // Arrange
            string shapeName = "Start";
            string text = "Start";
            int x = 0, y = 0, width = 100, height = 50;

            // Act
            Shape shape = shapeFactory.CreatShape(shapeName, text, x, y, width, height);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Start));
            Assert.AreEqual(text, shape.Text);
            Assert.AreEqual(x, shape.X);
            Assert.AreEqual(y, shape.Y);
            Assert.AreEqual(width, shape.Width);
            Assert.AreEqual(height, shape.Height);
        }

        [TestMethod]
        public void CreatShape_TerminatorShape_ReturnsTerminatorInstance()
        {
            // Arrange
            string shapeName = "Terminator";
            string text = "End";
            int x = 0, y = 0, width = 100, height = 50;

            // Act
            Shape shape = shapeFactory.CreatShape(shapeName, text, x, y, width, height);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Terminator));
            Assert.AreEqual(text, shape.Text);
            Assert.AreEqual(x, shape.X);
            Assert.AreEqual(y, shape.Y);
            Assert.AreEqual(width, shape.Width);
            Assert.AreEqual(height, shape.Height);
        }

        [TestMethod]
        public void CreatShape_ProcessShape_ReturnsProcessInstance()
        {
            // Arrange
            string shapeName = "Process";
            string text = "Process";
            int x = 0, y = 0, width = 100, height = 50;

            // Act
            Shape shape = shapeFactory.CreatShape(shapeName, text, x, y, width, height);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Process));
            Assert.AreEqual(text, shape.Text);
            Assert.AreEqual(x, shape.X);
            Assert.AreEqual(y, shape.Y);
            Assert.AreEqual(width, shape.Width);
            Assert.AreEqual(height, shape.Height);
        }

        [TestMethod]
        public void CreatShape_DecisionShape_ReturnsDecisionInstance()
        {
            // Arrange
            string shapeName = "Decision";
            string text = "Decision";
            int x = 0, y = 0, width = 100, height = 50;

            // Act
            Shape shape = shapeFactory.CreatShape(shapeName, text, x, y, width, height);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Decision));
            Assert.AreEqual(text, shape.Text);
            Assert.AreEqual(x, shape.X);
            Assert.AreEqual(y, shape.Y);
            Assert.AreEqual(width, shape.Width);
            Assert.AreEqual(height, shape.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatShape_InvalidShape_ThrowsArgumentException()
        {
            // Arrange
            string shapeName = "InvalidShape";
            string text = "Invalid";
            int x = 0, y = 0, width = 100, height = 50;

            // Act
            Shape shape = shapeFactory.CreatShape(shapeName, text, x, y, width, height);

            // Assert is handled by ExpectedException
        }
    }
}
