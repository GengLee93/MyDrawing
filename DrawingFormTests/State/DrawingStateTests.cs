using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System.Linq;
using MyDrawing.State;
using static System.Net.Mime.MediaTypeNames;


namespace MyDrawing.Tests.State
{
    [TestClass]
    public class DrawingStateTests
    {
        private DrawingShapeState _drawingState;
        private PointerState _pointerState;
        private Model _model;
        private MockGraphics _graphics;

        [TestInitialize]
        public void Initialize()
        {
            _pointerState = new PointerState();
            _drawingState = new DrawingShapeState(_pointerState);
            _model = new Model();
            _graphics = new MockGraphics();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _drawingState = null;
            _pointerState = null;
            _model = null;
            _graphics = null;
        }

        [TestMethod]
        public void Initialize_SetsCorrectInitialValues()
        {
            // Act
            _drawingState.Initialize(_model);

            // Assert
            Assert.IsFalse(_drawingState.IsUpperLeftPressed);
            Assert.IsNull(_drawingState.Hint);
            Assert.AreEqual(0, _drawingState.FirstPointX);
            Assert.AreEqual(0, _drawingState.FirstPointY);
        }

        [TestMethod]
        public void OnPaint_DrawsAllShapesAndHint()
        {
            // Arrange
            // 添加一個初始圖形
            _model.CurrentShapeName = "Process";
            _drawingState.Initialize(_model);
            _drawingState.MouseDown(_model, 10, 10);

            // Act
            _drawingState.OnPaint(_model, _graphics);

            // Assert
            Assert.IsTrue(_graphics.Calls.Count >= 2); // 至少應該有一次繪製現有圖形和一次繪製 hint
            Assert.IsNotNull(_drawingState.Hint);
        }

        [TestMethod]
        public void MouseDown_CreatesNewHintShape()
        {
            _model.CurrentShapeName = "Process";
            _drawingState.Initialize(_model);

            // Act
            _drawingState.MouseDown(_model, 20, 30);

            // Assert
            Assert.IsTrue(_drawingState.IsUpperLeftPressed);
            Assert.IsNotNull(_drawingState.Hint);
            Assert.AreEqual(20, _drawingState.FirstPointX);
            Assert.AreEqual(30, _drawingState.FirstPointY);
        }

        [TestMethod]
        public void MouseMove_UpdatesHintDimensions()
        {
            _model.CurrentShapeName = "Process";
            _drawingState.Initialize(_model);

            // Arrange
            _drawingState.MouseDown(_model, 10, 10);

            // Act
            _drawingState.MouseMove(_model, 30, 40);

            // Assert
            Assert.IsNotNull(_drawingState.Hint);
            Assert.AreEqual(10, _drawingState.Hint.X);
            Assert.AreEqual(10, _drawingState.Hint.Y);
            Assert.AreEqual(20, _drawingState.Hint.Width);
            Assert.AreEqual(30, _drawingState.Hint.Height);
        }

        [TestMethod]
        public void MouseMove_DoesNothingWhenNotPressed()
        {
            // Act
            _drawingState.MouseMove(_model, 20, 20);

            // Assert
            Assert.IsNull(_drawingState.Hint);
        }

        [TestMethod]
        public void MouseUp_AddsShapeWhenValidSize()
        {
            _model.CurrentShapeName = "Process";
            _drawingState.Initialize(_model);

            // Arrange
            int initialShapeCount = _model.ShapeList.Count;
            _drawingState.MouseDown(_model, 10, 10);
            _drawingState.MouseMove(_model, 30, 40);

            // Act
            _drawingState.MouseUp(_model);

            // Assert
            Assert.AreEqual(initialShapeCount + 1, _model.ShapeList.Count);
            Assert.IsFalse(_drawingState.IsUpperLeftPressed);
            var lastShape = _model.ShapeList.Last();
            Assert.AreEqual(10, lastShape.X);
            Assert.AreEqual(10, lastShape.Y);
            Assert.AreEqual(20, lastShape.Width);
            Assert.AreEqual(30, lastShape.Height);
        }

        [TestMethod]
        public void MouseUp_DoesNotAddShapeWhenInvalidSize()
        {
            _model.CurrentShapeName = "Process";
            _drawingState.Initialize(_model);

            // Arrange
            int initialShapeCount = _model.ShapeList.Count;
            _drawingState.MouseDown(_model, 10, 10);
            _drawingState.MouseMove(_model, 10, 10); // 相同位置 = 0 寬度/高度

            // Act
            _drawingState.MouseUp(_model);

            // Assert
            Assert.AreEqual(initialShapeCount, _model.ShapeList.Count);
        }

        [TestMethod]
        public void KeyDown_DoesNothing()
        {
            // Act & Assert - 不應拋出異常
            _drawingState.KeyDown(_model, 0);
        }

        [TestMethod]
        public void KeyUp_DoesNothing()
        {
            // 添加一個初始圖形
            _model.CurrentShapeName = "Process";
            _model.AddShape("Process", "Process", 10, 10, 60, 100);

            // Act & Assert - 不應拋出異常
            _drawingState.KeyUp(_model, 0);
        }
    }
}