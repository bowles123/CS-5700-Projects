using System.Collections.Generic;
using AppLayer.CommandPattern.Commands;
using System.Windows.Forms;

namespace OceanDrawing
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(Stack<Command> history)
        {
            InitializeComponent(history);
        }
    }
}
