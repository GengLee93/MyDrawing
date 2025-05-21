using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;


namespace MyDrawing.Tests
{
    [TestClass]
    public class PresentationModelTests
    {
        private PresentationModel _pm;
        private Model _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _pm = new PresentationModel(_model, null);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _model = null;
            _pm = null;
        }

        [TestMethod]
        public void SetCheckedButton_ShouldSetStartChecked()
        {
            // Act
            _pm.SetCheckedButton("Start");

            // Assert
            Assert.IsTrue(_pm.IsStartChecked);
            Assert.IsFalse(_pm.IsTerminatorChecked);
            Assert.IsFalse(_pm.IsDecisionChecked);
            Assert.IsFalse(_pm.IsProcessChecked);
            Assert.IsFalse(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void SetCheckedButton_ShouldSetTerminatorChecked()
        {
            // Act
            _pm.SetCheckedButton("Terminator");

            // Assert
            Assert.IsFalse(_pm.IsStartChecked);
            Assert.IsTrue(_pm.IsTerminatorChecked);
            Assert.IsFalse(_pm.IsDecisionChecked);
            Assert.IsFalse(_pm.IsProcessChecked);
            Assert.IsFalse(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void SetCheckedButton_ShouldSetDecisionChecked()
        {
            // Act
            _pm.SetCheckedButton("Decision");

            // Assert
            Assert.IsFalse(_pm.IsStartChecked);
            Assert.IsFalse(_pm.IsTerminatorChecked);
            Assert.IsTrue(_pm.IsDecisionChecked);
            Assert.IsFalse(_pm.IsProcessChecked);
            Assert.IsFalse(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void SetCheckedButton_ShouldSetProcessChecked()
        {
            // Act
            _pm.SetCheckedButton("Process");

            // Assert
            Assert.IsFalse(_pm.IsStartChecked);
            Assert.IsFalse(_pm.IsTerminatorChecked);
            Assert.IsFalse(_pm.IsDecisionChecked);
            Assert.IsTrue(_pm.IsProcessChecked);
            Assert.IsFalse(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void SetCheckedButton_ShouldSetPointerChecked()
        {
            // Act
            _pm.SetCheckedButton("");

            // Assert
            Assert.IsFalse(_pm.IsStartChecked);
            Assert.IsFalse(_pm.IsTerminatorChecked);
            Assert.IsFalse(_pm.IsDecisionChecked);
            Assert.IsFalse(_pm.IsProcessChecked);
            Assert.IsTrue(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void ClearAllCheckedButtons_ShouldResetAllButtons()
        {
            // Arrange
            _pm.SetCheckedButton("Start");

            // Act
            _pm.ClearAllCheckedButtons();

            // Assert
            Assert.IsFalse(_pm.IsStartChecked);
            Assert.IsFalse(_pm.IsTerminatorChecked);
            Assert.IsFalse(_pm.IsDecisionChecked);
            Assert.IsFalse(_pm.IsProcessChecked);
            Assert.IsFalse(_pm.IsPointerChecked);
        }

        [TestMethod]
        public void ValidateForm_ShouldEnableAddButtonWhenInputsAreValid()
        {
            // Arrange
            _pm.XText = "10";
            _pm.YText = "20";
            _pm.WidthText = "30";
            _pm.HeightText = "40";
            _pm.ShapesComboBoxText = "Rectangle";

            // Act
            _pm.ValidateForm();

            // Assert
            Assert.IsTrue(_pm.IsAddButtonEnabled);
            Assert.AreEqual("Black", _pm.XLabelColor);
            Assert.AreEqual("Black", _pm.YLabelColor);
            Assert.AreEqual("Black", _pm.WidthLabelColor);
            Assert.AreEqual("Black", _pm.HeightLabelColor);
        }

        [TestMethod]
        public void ValidateForm_ShouldDisableAddButtonWhenInputsAreInvalid()
        {
            // Arrange
            _pm.XText = "-10";
            _pm.YText = "0";
            _pm.WidthText = "abc";
            _pm.HeightText = "";
            _pm.ShapesComboBoxText = "";

            // Act
            _pm.ValidateForm();

            // Assert
            Assert.IsFalse(_pm.IsAddButtonEnabled);
            Assert.AreEqual("Red", _pm.XLabelColor);
            Assert.AreEqual("Red", _pm.YLabelColor);
            Assert.AreEqual("Red", _pm.WidthLabelColor);
            Assert.AreEqual("Red", _pm.HeightLabelColor);
        }

        [TestMethod]
        public void UpdateCursor_ShouldChangeCursorOnCanvas()
        {
            // Arrange
            var canvas = new Panel(); // 使用真實的控件作為畫布
            var pm = new PresentationModel(null, canvas); // Model 為 null，因為不需要用到它
            var expectedCursor = Cursors.Hand;

            // Act
            pm.UpdateCursor(expectedCursor);

            // Assert
            Assert.AreEqual(expectedCursor, canvas.Cursor, "Cursor on the canvas should be updated.");
        }
    }
}
