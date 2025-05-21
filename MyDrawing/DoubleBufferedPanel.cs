using System.Windows.Forms;

namespace MyDrawing
{
    public partial class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            //         ControlStyles.UserPaint |
            //         ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
