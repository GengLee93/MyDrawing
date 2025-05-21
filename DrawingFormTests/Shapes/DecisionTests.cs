using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class DecisionTests
    {
        private Decision _decision;
        private ShapesFactory shapeFactory;
        private MockGraphics _mockGraphics;

        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphics = new MockGraphics();
            shapeFactory = new ShapesFactory();
            _decision = (Decision)shapeFactory.CreatShape("Decision", "Test Decision", 10, 20, 30, 40);
        }

        [TestMethod()]
        public void Draw_CallsDrawDiamondAndDrawText()
        {
            // Act
            _decision.Draw(_mockGraphics);

            // Assert
            Assert.AreEqual(2, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawDiamond(10, 20, 30, 40)", _mockGraphics.Calls[0]);
            Assert.AreEqual(10 + 30 / 3, _decision.TextX);
            Assert.AreEqual(20 + 40 / 2, _decision.TextY);
            Assert.AreEqual("DrawText(20, 40, \"Test Decision\")", _mockGraphics.Calls[1]);
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("Decision", _decision.GetShapeName());
        }
    }
}