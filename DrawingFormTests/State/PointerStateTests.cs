using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing.Tests.State
{
    [TestClass]
    public class PointerStateTests
    {
        private PointerState _pointerState;
        private Model _model;
        private MockGraphics _graphics;

        [TestInitialize]
        public void Initialize()
        {
            _pointerState = new PointerState();
            _model = new Model();
            _graphics = new MockGraphics();
        }

        [TestCleanup] 
        public void Cleanup() { 
            _pointerState = null;
            _model = null; 
            _graphics = null; 
        }

        [TestMethod]
        public void Initialize_ShouldResetState()
        {
            _pointerState.Initialize(_model);
            Assert.IsFalse(_pointerState.IsDraggingText);
            Assert.IsFalse(_pointerState.IsDragging);
        }

        [TestMethod]
        public void OnPaint_ShouldDrawAllShapesAndBoundingBox()
        {
            // Act
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
            var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");
            _pointerState.AddSelectedShape(shape);

            _pointerState.OnPaint(_model, _graphics);

            Assert.AreEqual(4, _graphics.Calls.Count); // One for shape, one for text, one for shape bounding box, one for text bounding box
            Assert.AreEqual("DrawRectangle(10, 10, 60, 100)", _graphics.Calls[0]);
            Assert.AreEqual("DrawText(30, 60, \"Test Process\")", _graphics.Calls[1]);
            Assert.AreEqual("DrawShapeBoundingBox(10, 10, 60, 100)", _graphics.Calls[2]);
            Assert.AreEqual("DrawTextBoundingBox(30, 60, \"Test Process\")", _graphics.Calls[3]);
        }

        [TestMethod]
        public void MouseDown_ShouldSelectShapeAndStartDragging()
        {
            // Arrange
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
            var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");

            // 檢查是否找到該圖形
            Assert.IsNotNull(shape);

            // 呼叫 MouseDown 方法進行選擇和拖動
            _pointerState.MouseDown(_model, 15, 15);

            // 檢查選中的圖形是否正確
            Assert.IsNotNull(_pointerState.SelectShape);
            Assert.AreEqual(shape, _pointerState.SelectShape);
            Assert.IsTrue(_pointerState.IsDragging);
        }

        [TestMethod]
        public void MouseDown_ShouldStartDraggingText_WhenClickOnDragPoint()
        {
            //  Arrange
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
            var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");

            // Act
            _pointerState.MouseDown(_model, 70, 50); // 模擬點擊拖曳點

            // Assert
            Assert.AreEqual(shape, _pointerState.SelectShape);
            Assert.IsTrue(_pointerState.IsDraggingText);
            Assert.IsFalse(_pointerState.IsDragging);
        }

        [TestMethod]
        public void MouseDown_ShouldStartDraggingShape_WhenClickOnShape()
        {
            //  Arrange
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
            var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");

            // Act
            _pointerState.MouseDown(_model, 15, 25); // 模擬點擊圖形內部

            // Assert
            Assert.AreEqual(shape, _pointerState.SelectShape);
            Assert.IsTrue(_pointerState.IsDragging);
            Assert.IsFalse(_pointerState.IsDraggingText);
        }

        //[TestMethod]
        //public void MouseDoubleClick_WhenOverDragPoint_UpdatesShapeText()
        //{
        //    //  Arrange
        //    _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
        //    var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");
        //    TextChangeDialog dialog = new TextChangeDialog(shape.Text);

        //    // Act
        //    _pointerState.MouseDown(_model, 70, 50); // 模擬點擊拖曳點

        //    // Assert
        //    Assert.AreEqual(shape, _pointerState.SelectShape);
        //    Assert.IsTrue(_pointerState.IsDraggingText);
        //    Assert.IsFalse(_pointerState.IsDragging);
        //}




        [TestMethod]
        public void MouseMove_ShouldMoveSelectedShape()
        {
            // Arrange
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);
            var shape = _model.ShapeList.FirstOrDefault(s => s.GetShapeName() == "Process" && s.Text == "Test Process");

            // 檢查是否找到該圖形
            Assert.IsNotNull(shape);

            // 模擬點擊開始拖曳圖形
            _pointerState.MouseDown(_model, 15, 15);

            // 檢查圖形是否選中
            Assert.IsNotNull(_pointerState.SelectShape);

            // 模擬移動圖形
            _pointerState.MouseMove(_model, 25, 25);

            // 檢查移動後的位置
            Assert.AreEqual(20, shape.X);
            Assert.AreEqual(20, shape.Y);
        }

        [TestMethod]
        public void MouseUp_ShouldStopDragging()
        {
            // Arrange
            var shape = new Process("Test", 10, 10, 100, 100);
            _model.ShapeList.Add(shape);

            // Act
            _pointerState.MouseMove(_model, 20, 20);
            _pointerState.MouseUp(_model);

            // Assert
            Assert.IsFalse(_pointerState.IsDragging);
            Assert.IsFalse(_pointerState.IsDraggingText);
        }

        [TestMethod]
        public void KeyDown_ShouldNotThrowException()
        {
            _pointerState.KeyDown(_model, 46);
        }

        [TestMethod]
        public void KeyUp_ShouldNotThrowException()
        {
            _pointerState.KeyUp(_model, 46);
        }
    }
}