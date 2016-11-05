using AppLayer.DrawingComponents;
using AppLayer.CommandPattern.Commands;

namespace AppLayer.CommandPattern
{
    public class CommandFactory
    {
        public Drawing Drawing { get; set; }

        public virtual Command Create(string commandType, params object[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(commandType)) return null;
            Command command = null;

            switch (commandType.Trim().ToUpper())
            {
                case "NEW":
                    command = new NewCommand();
                    break;
                case "ADD":
                    command = new AddCreatureCommand(commandParameters);
                    break;
                case "REMOVE":
                    command = new RemoveSelectedCommand();
                    break;
                case "SELECT":
                    command = new SelectCommand(commandParameters);
                    break;
                case "DESELECT":
                    command = new DeselectAllCommand();
                    break;
                case "LOAD":
                    command = new LoadCommand(commandParameters);
                    break;
                case "SAVE":
                    command = new SaveCommand(commandParameters);
                    break;
                case "DUPLICATE":
                    command = new DuplicateSelectedCommand();
                    break;
                case "MOVE":
                    command = new MoveSelectedCommand(commandParameters);
                    break;
                case "SCALE":
                    command = new ScaleSelectedCommand(commandParameters);
                    break;
            }

            if (command != null)
                command.Drawing = Drawing;

            return command;
        }
    }
}
