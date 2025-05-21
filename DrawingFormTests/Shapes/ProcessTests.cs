using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyDrawing.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        private Process _process;
        private ShapesFactory shapeFactory;
        private MockGraphics _mockGraphics;

        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphics = new MockGraphics();
            shapeFactory = new ShapesFactory();
            _process = (Process)shapeFactory.CreatShape("Process", "Test Process", 10, 20, 30, 40);
        }
        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(expected: "Process", actual: _process.GetShapeName());
        }

        [TestMethod()]
        public void DrawTest()
        {
            // Act
            _process.Draw(_mockGraphics);

            // Assert
            Assert.AreEqual(2, _mockGraphics.Calls.Count);
            Assert.AreEqual("DrawRectangle(10, 20, 30, 40)", _mockGraphics.Calls[0]);
            Assert.AreEqual(10 + 30 / 3, _process.TextX);
            Assert.AreEqual(20 + 40 / 2, _process.TextY);
            Assert.AreEqual("DrawText(20, 40, \"Test Process\")", _mockGraphics.Calls[1]);
        }
    }
}