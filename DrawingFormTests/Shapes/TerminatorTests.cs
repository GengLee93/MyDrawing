using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class TerminatorTests
    {
        private Terminator _terminator;
        private ShapesFactory shapeFactory;
        private MockGraphics _mockGraphics;


        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphics = new MockGraphics();
            shapeFactory = new ShapesFactory();
            _terminator = (Terminator)shapeFactory.CreatShape("Terminator", "Test Terminator", 10, 20, 30, 40);
        }
        //[TestMethod()]
        //public void TerminatorTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(expected: "Terminator", actual: _terminator.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            // Act
            _terminator.Draw(_mockGraphics);

            // Assert
            Assert.AreEqual(2, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawEllipse(10, 20, 30, 40)", _mockGraphics.Calls[0]);
            Assert.AreEqual(10 + 30 / 3, _terminator.TextX);
            Assert.AreEqual(20 + 40 / 2, _terminator.TextY);
            Assert.AreEqual("DrawText(20, 40, \"Test Terminator\")", _mockGraphics.Calls[1]);
        }

        [TestMethod()]
        public void DrawShapeBoundingBoxTest()
        {
            // Act 
            _terminator.DrawShapeBoundingBox(_mockGraphics);

            // Assert
            Assert.AreEqual(1, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawShapeBoundingBox(10, 20, 70, 40)", _mockGraphics.Calls[0]);
        }

        [TestMethod()]
        public void DrawTextBoundingBoxTest()
        {
            // Act
            _terminator.DrawTextBoundingBox(_mockGraphics);

            // Assert
            Assert.AreEqual(1, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawTextBoundingBox(20, 40, \"Test Terminator\")", _mockGraphics.Calls[0]);
        }
    }
}