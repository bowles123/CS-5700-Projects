using AppLayer.DrawingComponents;

namespace AppLayer.CommandPattern.Commands
{
    public class NewCommand : Command
    {
        internal NewCommand() { ActualCommand = "NEW"; }

        public override bool Execute()
        {
            if (Drawing == null) return false;

            Drawing?.Clear();
            return true;
        }

        public override bool Undo() { return false; }
    }
}
