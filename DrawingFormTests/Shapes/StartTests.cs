using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class StartTests
    {
        private Start _start;
        private ShapesFactory shapeFactory;
        private MockGraphics _mockGraphics;


        [TestInitialize()]
        public void Initialize()
        {
            shapeFactory = new ShapesFactory();
            _mockGraphics = new MockGraphics();
            _start = (Start)shapeFactory.CreatShape("Start", "Test Start", 50, 50, 60, 60);
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("Start", _start.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            // Act
            _start.Draw(_mockGraphics);

            // Assert
            Assert.AreEqual(2, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawCircle(50, 50, 60, 60)", _mockGraphics.Calls[0]);
            Assert.AreEqual(50 + 60 / 3, _start.TextX);
            Assert.AreEqual(50 + 60 / 2, _start.TextY);
            Assert.AreEqual("DrawText(70, 80, \"Test Start\")", _mockGraphics.Calls[1]);
        }
    }
}