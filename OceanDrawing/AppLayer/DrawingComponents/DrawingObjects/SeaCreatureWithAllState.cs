using System.Drawing;

namespace AppLayer.DrawingComponents.DrawingObjects
{
    public class SeaCreatureWithAllState: SeaCreature
    {
        internal IntrinsicSeaCreature IntrinsicState { get; }
        private static int creatureId = 0;
        public ExtrinsicSeaCreature ExtrinsicState { get; }
        public int CreatureId { get; private set; }

        internal SeaCreatureWithAllState(IntrinsicSeaCreature sharedPart, 
            ExtrinsicSeaCreature nonsharedPart)
        {
            IntrinsicState = sharedPart;               
            ExtrinsicState = nonsharedPart;
            CreatureId = ++creatureId;          
        }

        public override bool IsSelected
        {
            get
            {
                if (ExtrinsicState != null)
                    return ExtrinsicState.IsSelected;
                return false;
            }
            set { ExtrinsicState.IsSelected = value; }
        }

        public override Point Location
        {
            get
            {
                if (ExtrinsicState != null)
                    return ExtrinsicState.Location;
                return new Point(0, 0);
            }
            set { ExtrinsicState.Location = value; }
        }


        public override Size Size
        {
            get
            {
                if (ExtrinsicState != null)
                    return ExtrinsicState.Size;
                return new Size(0, 0);
            }
            set { ExtrinsicState.Size = value; }
        }

        public override string ActualCreature
        {
            get { return ExtrinsicState?.CreatureType; }
            set { ExtrinsicState.CreatureType = value; }
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null || IntrinsicState?.Image == null) return;

            graphics.DrawImage(IntrinsicState.Image,
                new Rectangle(ExtrinsicState.Location.X, ExtrinsicState.Location.Y, 
                ExtrinsicState.Size.Width, ExtrinsicState.Size.Height),
                0, 0, IntrinsicState.Image.Width, IntrinsicState.Image.Height,
                GraphicsUnit.Pixel);

            if (ExtrinsicState.IsSelected)
            {
                graphics.DrawRectangle(
                    SelectedPen,
                    ExtrinsicState.Location.X,
                    ExtrinsicState.Location.Y,
                    ExtrinsicState.Size.Width,
                    ExtrinsicState.Size.Height);

                DrawActionHandle(graphics, ExtrinsicState.Location.X, ExtrinsicState.Location.Y);
                DrawActionHandle(graphics, ExtrinsicState.Location.X + ExtrinsicState.Size.Width, 
                    ExtrinsicState.Location.Y);
                DrawActionHandle(graphics, ExtrinsicState.Location.X, ExtrinsicState.Location.Y + 
                    ExtrinsicState.Size.Height);
                DrawActionHandle(graphics, ExtrinsicState.Location.X + ExtrinsicState.Size.Width, 
                    ExtrinsicState.Location.Y + ExtrinsicState.Size.Height);
            }
        }

        private void DrawActionHandle(Graphics graphics, int x, int y)
        {
            graphics.FillRectangle(HandlesBrush, x - HandleHalfSize, y - HandleHalfSize, 
                HandleHalfSize * 2, HandleHalfSize * 2);
        }
    }
}
