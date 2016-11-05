using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace AppLayer.DrawingComponents.DrawingObjects
{
    internal class IntrinsicSeaCreature: SeaCreature
    {
        public static Color SelectionBackgroundColor { get; set; } = Color.DarkKhaki;
        public string SeaCreatureType { get; set; }
        public Bitmap Image { get; private set; }
        public Bitmap ToolImage { get; private set; }
        public Bitmap ToolImageSelected { get; private set; }

        public void LoadFromResource(string seaCreatureType, Type rType)
        {
            if (string.IsNullOrWhiteSpace(seaCreatureType)) return;

            var assembly = Assembly.GetAssembly(rType);

            if (assembly == null) return;

            using (Stream stream = assembly.GetManifestResourceStream(seaCreatureType))
            {
                if (stream != null)
                {
                    Image = new Bitmap(stream);
                    ToolImage = new Bitmap(Image, ToolSize);
                    ToolImageSelected = new Bitmap(ToolSize.Width, ToolSize.Height);

                    Graphics g = Graphics.FromImage(ToolImageSelected);
                    g.Clear(SelectionBackgroundColor);
                    g.DrawImage(ToolImage, new Point() { X = 0, Y = 0 });
                }
            }
        }

        public override bool IsSelected
        {
            get { return false; }
            set
            {
                throw new ApplicationException("Cannot select a sea creature with only intrinsic state - "
                    + "the intrinsic state is immutable");
            }
        }


        public override Point Location
        {
            get { return new Point(); }
            set
            {
                throw new ApplicationException("Cannot change a sea creature with only intrinsic state - "
                    + "the intrinsic state is immutable");
            }
        }


        public override Size Size
        {
            get { return new Size(); }
            set
            {
                throw new ApplicationException("Cannot change a sea creature with only intrinsic state - "
                    + "the intrinsic state is immutable");
            }
        }

        public override string ActualCreature
        {
            get { return ""; }

            set
            {
                throw new ApplicationException("Cannot have an actual sea creature with only intrinsic state -"
                    + "the intrinsic state is immutable");
            }
        }

        public override void Draw(Graphics graphics)
        {
            throw new ApplicationException("Cannot draw a sea creature with only intrinsic state");
        }
    }
}
