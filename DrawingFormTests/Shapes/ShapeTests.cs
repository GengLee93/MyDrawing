using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;

namespace MyDrawing.Tests
{
    [TestClass]
    public class ShapeTests
    {
        private class TestShape : Shape
        {
            public TestShape(string text, int x, int y, int width, int height)
                : base(text, x, y, width, height) { }

            public override string GetShapeName() => "TestShape";

            public override void Draw(IGraphics graphics) { }
        }

        private class MockGraphics : IGraphics
        {
            public void DrawCircle(int x, int y, int width, int height) { }
            public void DrawRectangle(int x, int y, int width, int height) { }
            public void DrawText(int x, int y, string text) { }
            public void DrawEllipse(int x, int y, int width, int height) { }
            public void DrawDiamond(int x, int y, int width, int height) { }
            public void DrawShapeBoundingBox(int x, int y, int width, int height) { }
            public void DrawTextBoundingBox(int x, int y, string text) { }
            public void ClearAll() { }
        }

        [TestMethod]
        public void TestShapeInitialization()
        {
            var shape = new TestShape("Test", 10, 20, 30, 40);
            Assert.AreEqual("Test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Width);
            Assert.AreEqual(40, shape.Height);
            Assert.AreEqual(20, shape.TextX);
            Assert.AreEqual(40, shape.TextY);
            Assert.AreEqual(28, shape.TextWidth);
        }

        [TestMethod]
        public void TestInitializeTextPosition()
        {
            var shape = new TestShape("Test", 10, 20, 30, 40);
            shape.InitializeTextPosition();
            Assert.AreEqual(20, shape.TextX);
            Assert.AreEqual(40, shape.TextY);
        }

        [TestMethod]
        public void TestDrawShapeBoundingBox()
        {
            var shape = new TestShape("Test", 10, 20, 30, 40);
            var graphics = new MockGraphics();
            shape.DrawShapeBoundingBox(graphics);
        }

        [TestMethod]
        public void TestDrawTextBoundingBox()
        {
            var shape = new TestShape("Test", 10, 20, 30, 40);
            var graphics = new MockGraphics();
            shape.DrawTextBoundingBox(graphics);
        }
    }
}
