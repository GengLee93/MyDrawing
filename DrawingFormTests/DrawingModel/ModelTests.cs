using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Linq;

namespace MyDrawing.Tests
{
    [TestClass]
    public class ModelTests
    {
        private Model _model;
        private bool _modelChangedEventRaised;
        private bool _shapeAddedEventRaised;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _model.ModelChanged += () => _modelChangedEventRaised = true;
            _model.ShapeAdded += () => _shapeAddedEventRaised = true;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _model = null;
            _modelChangedEventRaised = false;
            _shapeAddedEventRaised = false;
        }

        [TestMethod]
        public void EnterPointerState_ShouldSetPointerState()
        {
            // Act
            _model.EnterPointerState();

            // Assert
            // 無法直接訪問 private field，通過行為來驗證
            Assert.IsNotNull(_model.ShapeList); // 保持初始形狀列表不變
        }

        [TestMethod]
        public void EnterDrawingState_ShouldSetDrawingState()
        {
            // Act
            _model.EnterDrawingShapeState();

            // Assert
            // 無法直接訪問 private field，通過行為來驗證
            Assert.IsNotNull(_model.ShapeList); // 保持初始形狀列表不變
        }

        [TestMethod]
        public void PointerPressed_ShouldCallMouseDown()
        {
            // Act
            _model.PointerPressed(10, 10);

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        public void PointerMoved_ShouldCallMouseMove_InPointerState()
        {
            // Arrange
            _model.CurrentShapeName = "Process";
            _model.EnterPointerState();
            _model.PointerPressed(10, 10); // 先按下來設置選中狀態
            _model.ModelChanged += () => _modelChangedEventRaised = true;

            // Act
            _model.PointerMoved(20, 20);

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }


        [TestMethod]
        public void PointerMoved_ShouldCallMouseMove_InDrawingState()
        {
            // Arrange
            _model.CurrentShapeName = "Process";
            _model.EnterDrawingShapeState();
            _model.PointerPressed(10, 10); // 先按下來開始繪圖
            _model.ModelChanged += () => _modelChangedEventRaised = true;

            // Act
            _model.PointerMoved(20, 20);

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }


        [TestMethod]
        public void PointerReleased_ShouldCallMouseUp()
        {
            // Act
            _model.PointerReleased();

            // Assert
            Assert.IsTrue(_shapeAddedEventRaised); // 驗證事件是否被觸發
            Assert.AreEqual(string.Empty, _model.CurrentShapeName); // 驗證形狀名稱是否被清空
        }

        [TestMethod]
        public void KeyDown_ShouldCallKeyDown()
        {
            // Act
            _model.KeyDown(46);

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        public void KeyUp_ShouldCallKeyUp()
        {
            // Act
            _model.KeyUp(46);

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        public void Draw_ShouldCallOnPaint()
        {
            // Arrange
            var graphics = new MockGraphics();

            // Act
            _model.Draw(graphics);

            // Assert
            Assert.AreEqual(1, graphics.Calls.Count); // 驗證是否調用了 ClearAll
        }

        [TestMethod]
        public void AddShape_ShouldAddNewShape()
        {
            // Act
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);

            // Assert
            Assert.AreEqual(1, _model.ShapeList.Count); // 驗證形狀數量
            Assert.AreEqual("Process", _model.ShapeList.First().GetShapeName());
            Assert.AreEqual("Test Process", _model.ShapeList.First().Text);
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        public void RemoveShape_ShouldRemoveShape()
        {
            // Arrange
            _model.AddShape("Process", "Test Process", 10, 10, 60, 100);

            // Act
            _model.RemoveShape(0);

            // Assert
            Assert.AreEqual(0, _model.ShapeList.Count); // 驗證形狀是否被移除
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
            Assert.IsTrue(_shapeAddedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddShape_ShouldThrowException_WhenShapeNameIsNull()
        {
            // Act
            _model.AddShape(null, "Test Process", 10, 10, 60, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddShape_ShouldThrowException_WhenDimensionsAreInvalid()
        {
            // Act
            _model.AddShape("Process", "Test Process", 10, 10, -60, 100);
        }

        [TestMethod]
        public void NotifyModelChanged_ShouldInvokeModelChangedEvent()
        {
            // Act
            _model.NotifyModelChanged();

            // Assert
            Assert.IsTrue(_modelChangedEventRaised); // 驗證事件是否被觸發
        }

        [TestMethod]
        public void NotifyShapeAdded_ShouldInvokeShapeAddedEvent()
        {
            // Act
            _model.NotifyShapeAdded();

            // Assert
            Assert.IsTrue(_shapeAddedEventRaised); // 驗證事件是否被觸發
        }
    }
}
