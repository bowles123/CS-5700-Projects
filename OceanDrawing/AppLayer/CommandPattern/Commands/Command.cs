using AppLayer.DrawingComponents;

namespace AppLayer.CommandPattern.Commands
{
    public abstract class Command
    {
        public Drawing Drawing { get; set; }
        public string ActualCommand { get; set; }
        public abstract bool Execute();
        public abstract bool Undo();
    }
}
