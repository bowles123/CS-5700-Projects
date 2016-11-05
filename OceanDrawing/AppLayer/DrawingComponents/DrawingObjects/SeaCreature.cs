using System.Drawing;

namespace AppLayer.DrawingComponents.DrawingObjects
{
    public abstract class SeaCreature
    {
        public static Pen SelectedPen { get; set; } = new Pen(Color.DarkGray);
        public static Brush HandlesBrush { get; set; } = new SolidBrush(Color.Black);
        public static int HandleHalfSize { get; set; } = 3;
        public static Size ToolSize { get; set; } = new Size() { Width = 64, Height = 64 };

        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);
        public virtual bool IsSelected { get; set; } = false;
        public virtual string ActualCreature { get; set; } = "";

        public virtual void Draw(Graphics graphics) { }
    }
}
