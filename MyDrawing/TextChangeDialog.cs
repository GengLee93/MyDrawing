using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class TextChangeDialog : Form
    {
        private readonly string originalText;
        public string NewText { get; private set; }

        public TextChangeDialog(string currentText)
        {
            InitializeComponent();

            originalText = currentText;

            // 
            // textBox
            //
            textBox.Text = currentText;
            textBox.TextChanged += TextBoxTextChanged;
            //
            // okButton
            //
            okButton.Enabled = false;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            NewText = textBox.Text;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = textBox.Text != originalText;
        }
    }
}
