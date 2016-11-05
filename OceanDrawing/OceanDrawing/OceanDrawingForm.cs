using System.Windows.Forms;
using System;
using System.Drawing;
using AppLayer.DrawingComponents;
using System.Globalization;
using System.Reflection;
using System.IO;
using AppLayer.CommandPattern;
using AppLayer.CommandPattern.Commands;
using Microsoft.VisualBasic;

namespace OceanDrawing
{
    public partial class OceanDrawingForm : Form
    {
        private readonly CommandFactory commandFactory;
        private readonly Drawing drawing;
        private string currentSeaCreatureResource;
        private string currentBackgroundResource;
        private float currentScale = 1.0F;

        private enum PossibleModes
        {
            None,
            Drawing,
            Selection
        };
        private PossibleModes mode = PossibleModes.None;

        private Bitmap imageBuffer;
        private Bitmap backgroundBitmap;
        private Graphics imageBufferGraphics;
        private Graphics panelGraphics;
        private Stream backgroundImageStream;

        public OceanDrawingForm()
        {
            drawing = new Drawing();
            drawing.Factory = new SeaCreatureFactory() {
                ResourceNamePattern = @"OceanDrawing.Drawable.{0}.png",
                ReferenceType = typeof(OceanDrawingProgram) };
            commandFactory = new CommandFactory() { Drawing = drawing };
            InitializeComponent();
        }

        private void OceanDrawingForm_Load(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
            refreshTimer.Start();
            Invoker.getUniqueInstance().Start();

            currentBackgroundResource = "OceanDrawing.Drawable.Open_Ocean.png";
            if (string.IsNullOrWhiteSpace(currentBackgroundResource)) return;
            var assembly = Assembly.GetAssembly(typeof(OceanDrawingProgram));
            if (assembly == null) return;

            backgroundImageStream = assembly.GetManifestResourceStream(currentBackgroundResource);
            if (backgroundImageStream != null)
            {
                Bitmap background = new Bitmap(Image.FromStream(backgroundImageStream),
                    new Size(drawingPanel.Width, drawingPanel.Height));
                drawingPanel.BackgroundImage = background;
            }
        }
        private void ComputeDrawingPanelSize()
        {
            int width = Width - drawingToolStrip.Width;
            int height = Height - menuStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, menuStrip.Height);

            imageBuffer = null;
            if (drawing != null)
                drawing.IsDirty = true;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing();
        }

        private void DisplayDrawing()
        {
            if (imageBuffer == null)
            {
                imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                imageBufferGraphics = Graphics.FromImage(imageBuffer);
                panelGraphics = drawingPanel.CreateGraphics();
            }

            if (backgroundBitmap != null)
                drawing.SetBackground(backgroundBitmap, new Size(drawingPanel.Width, 
                    drawingPanel.Height), imageBufferGraphics);
            if (drawing.Draw(imageBufferGraphics))
                panelGraphics.DrawImageUnscaled(imageBuffer, 0, 0);
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (ToolStripItem item in drawingToolStrip.Items)
            {
                ToolStripButton toolButton = item as ToolStripButton;
                if (toolButton != null && item != ignoreItem && toolButton.Checked)
                    toolButton.Checked = false;
            }
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            float result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (!float.TryParse(text, out result))
                    result = defaultValue;
                else
                    result = Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void setBackgroundImage()
        {
            if (string.IsNullOrWhiteSpace(currentBackgroundResource)) return;
            var assembly = Assembly.GetAssembly(typeof(OceanDrawingProgram));
            if (assembly == null) return;

            backgroundImageStream = assembly.GetManifestResourceStream(currentBackgroundResource);
            if (backgroundImageStream != null)
            {
                backgroundBitmap = new Bitmap(backgroundImageStream);
                DisplayDrawing();
            }
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
            scale.Text = currentScale.ToString(CultureInfo.InvariantCulture);
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (drawingPanel.BackgroundImage != null)
                setBackgroundImage();

            if (button != null && button.Checked)
            {
                mode = PossibleModes.Selection;
                currentSeaCreatureResource = string.Empty;
            }
            else
            {
                Invoker.getUniqueInstance().Enqueue(commandFactory.Create("deselect"));
                mode = PossibleModes.None;
            }
        }

        private void creatureButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (drawingPanel.BackgroundImage != null)
                setBackgroundImage();

            if (button != null && button.Checked)
                currentSeaCreatureResource = button.Text;
            else
                currentSeaCreatureResource = string.Empty;

            mode = (currentSeaCreatureResource != string.Empty) ? PossibleModes.Drawing :
                PossibleModes.None;
        }

        private void backgroundSelection_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            string[] halves = menuItem.Text.Split(' ');
            string resourceName = halves[0] + "_" + halves[1];

            if (menuItem != null)
                currentBackgroundResource = $"OceanDrawing.Drawable.{resourceName}.png";
            else
                currentBackgroundResource = string.Empty;
            setBackgroundImage();

            Invoker.getUniqueInstance().ResetHistory();
            Invoker.getUniqueInstance().Enqueue(commandFactory.Create("new"));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Interaction.InputBox("Enter the filename", "Load Drawing", "", 
                drawingPanel.Location.X, drawingPanel.Location.Y);

            if (!string.IsNullOrWhiteSpace(filename))
            {
                if (!filename.EndsWith(".json"))
                    filename += ".json";

                Invoker.getUniqueInstance().ResetHistory();
                Invoker.getUniqueInstance().Enqueue(commandFactory.Create("load", filename));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Interaction.InputBox("Enter the filename", "Save Drawing", "", -1, -1);

            if (!string.IsNullOrWhiteSpace(filename))
            {
                if (!filename.EndsWith(".json"))
                    filename += ".json";
                Invoker.getUniqueInstance().Enqueue(commandFactory.Create("save", filename));
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HistoryForm(Invoker.getUniqueInstance().History).ShowDialog();
        }

        private void OceanDrawingForm_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();

            if (drawingPanel.BackgroundImage != null && backgroundImageStream != null)
            {
                drawingPanel.BackgroundImage = new Bitmap(Image.FromStream(backgroundImageStream),
                    new Size(drawingPanel.Width, drawingPanel.Height));
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == PossibleModes.Drawing)
            {
                if (!string.IsNullOrWhiteSpace(currentSeaCreatureResource))
                    Invoker.getUniqueInstance().Enqueue(
                        commandFactory.Create("add", currentSeaCreatureResource, e.Location, currentScale));
            }
            else if (mode == PossibleModes.Selection)
                Invoker.getUniqueInstance().Enqueue(commandFactory.Create("select", e.Location));
        }

        private void OceanDrawingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Invoker.getUniqueInstance().Stop();
        }

        private void OceanDrawingForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case (Keys.Escape):
                    Close();
                    break;
                case (Keys.Control | Keys.O):
                    openToolStripMenuItem_Click(sender, e as EventArgs);
                    break;
                case (Keys.Control | Keys.Z):
                    Invoker.getUniqueInstance().Undo();
                    break;
                case (Keys.Control | Keys.S):
                    saveToolStripMenuItem_Click(sender, e as EventArgs);
                    break;
                case (Keys.Control | Keys.N):                   
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("new"));
                    break;
                case (Keys.Delete):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("remove"));
                    break;
                case (Keys.Control | Keys.V):
                    DuplicateSelectedCommand command = commandFactory.Create("duplicate") as
                        DuplicateSelectedCommand;
                    command.Factory = drawing.Factory;
                    Invoker.getUniqueInstance().Enqueue(command);
                    break;
                case (Keys.Control | Keys.D):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("deselect"));
                    break;
                case (Keys.Control | Keys.Up):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("scale", 1.5F));
                    break;
                case (Keys.Control | Keys.Down):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("scale", 0.5F));
                    break;
                case (Keys.Right):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("move",
                        new Point(30, 0)));
                    break;
                case (Keys.Left):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("move",
                        new Point(-30, 0)));
                    break;
                case (Keys.Up):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("move",
                        new Point(0, -30)));
                    break;
                case (Keys.Down):
                    Invoker.getUniqueInstance().Enqueue(commandFactory.Create("move",
                        new Point(0, 30)));
                    break;
                case (Keys.Control | Keys.H):
                    historyToolStripMenuItem_Click(sender, e as EventArgs);
                    break;
            }
        }

        private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    contextMenuStrip.Show(drawingPanel, e.Location);
                    contextMenuStrip.Show();
                    break;
            }
        }

        private void removeAllSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoker.getUniqueInstance().Enqueue(commandFactory.Create("remove"));
        }

        private void duplicateAllSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateSelectedCommand command = commandFactory.Create("duplicate") as
                DuplicateSelectedCommand;
            command.Factory = drawing.Factory;
            Invoker.getUniqueInstance().Enqueue(command);
        }

        private void deselectAllSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoker.getUniqueInstance().Enqueue(commandFactory.Create("deselect"));
        }

        private void backgroundSelection_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            string[] halves = menuItem.Text.Split(' ');
            string resourceName = halves[0] + "_" + halves[1];
            string backgroundResource;
            Stream backgroundStream;

            if (menuItem != null)
                backgroundResource = $"OceanDrawing.Drawable.{resourceName}.png";
            else
                backgroundResource = string.Empty;

            if (string.IsNullOrWhiteSpace(backgroundResource)) return;
            var assembly = Assembly.GetAssembly(typeof(OceanDrawingProgram));
            if (assembly == null) return;

            backgroundStream = assembly.GetManifestResourceStream(backgroundResource);
            if (backgroundStream != null)
            {
                Bitmap background = new Bitmap(Image.FromStream(backgroundStream),
                    new Size(drawingPanel.Width, drawingPanel.Height));
                drawingPanel.BackgroundImage = background;
            }
        }

        private void backgroundSelection_MouseLeave(object sender, EventArgs e)
        {
            drawingPanel.BackgroundImage = new Bitmap(Image.FromStream(backgroundImageStream),
                    new Size(drawingPanel.Width, drawingPanel.Height));
        }
    }
}
