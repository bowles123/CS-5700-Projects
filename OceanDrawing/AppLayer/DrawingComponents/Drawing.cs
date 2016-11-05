using System.Collections.Generic;
using System.Drawing;
using System.IO;
using AppLayer.CommandPattern;
using AppLayer.DrawingComponents.DrawingObjects;

namespace AppLayer.DrawingComponents
{
    public class Drawing
    {
        public readonly List<SeaCreature> _seaCreatures = new List<SeaCreature>();

        private readonly object _myLock = new object();
        private Bitmap _background;

        public List<SeaCreature> SeaCreatures { get { return _seaCreatures; } }
        public SeaCreatureFactory Factory { get; set; }
        public SeaCreature Selected { get; set; }
        public bool IsDirty { get; set; }

        public void SetBackground(Bitmap background, Size scale, Graphics graphics)
        {
            if (background != null)
            {
                graphics.DrawImage(background, new Rectangle(0, 0, scale.Width,
                    scale.Height), new Rectangle(0, 0, background.Width,
                    background.Height), GraphicsUnit.Pixel);
                _background = background;
            }
        }

        public void Clear()
        {
            lock (_myLock)
            {
                _seaCreatures.Clear();
                IsDirty = true;
            }
        }

        public void Add(SeaCreature SeaCreature)
        {
            if (SeaCreature != null)
            {
                lock (_myLock)
                {
                    _seaCreatures.Add(SeaCreature);
                    IsDirty = true;
                }
            }
        }

        public void RemoveSeaCreature(SeaCreature SeaCreature)
        {
            if (SeaCreature != null)
            {
                lock (_myLock)
                {
                    if (Selected == SeaCreature)
                        Selected = null;
                    _seaCreatures.Remove(SeaCreature);
                    IsDirty = true;
                }
            }
        }

        public SeaCreature FindSeaCreatureAt(Point location)
        {
            SeaCreature result;
            lock (_myLock)
            {
                result = _seaCreatures.FindLast(t => location.X >= t.Location.X &&
                                              location.X < t.Location.X + t.Size.Width &&
                                              location.Y >= t.Location.Y &&
                                              location.Y < t.Location.Y + t.Size.Height);
            }
            return result;
        }

        public SeaCreature FindSeaCreatureById(int id)
        {
            SeaCreature result = null;
            lock (_myLock)
            {
                foreach (SeaCreatureWithAllState creature in _seaCreatures)
                {
                    if (creature.CreatureId == id)
                    {
                        result = creature;
                        break;
                    }
                }
            }

            return result;
        }

        public void DeselectAll()
        {
            lock (_myLock)
            {
                foreach (var t in _seaCreatures)
                    t.IsSelected = false;
                IsDirty = true;
            }
        }

        public void DeleteAllSelected()
        {
            lock (_myLock)
            {
                _seaCreatures.RemoveAll(t => t.IsSelected);
            }
        }

        public bool Draw(Graphics graphics)
        {
            bool didARedraw = false;
            lock (_myLock)
            {
                if (IsDirty)
                {
                    foreach (var sc in _seaCreatures)
                        sc.Draw(graphics);
                    IsDirty = false;
                    didARedraw = true;
                }
            }
            return didARedraw;
        }

        public void Load(Stream stream)
        {
            var extrinsicStates =
                JsonSerializer.getInstance().getObjectSerializer().ReadObject(stream) as 
                List<ExtrinsicSeaCreature>;
            if (extrinsicStates == null) return;

            lock (_myLock)
            {
                _seaCreatures.Clear();
                foreach (ExtrinsicSeaCreature extrinsicState in extrinsicStates)
                {
                    SeaCreature SeaCreature = Factory.Create(extrinsicState);
                    _seaCreatures.Add(SeaCreature);
                }
                IsDirty = true;
            }
        }
    }
}
