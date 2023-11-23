using System;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        // Create a new instance of the Form class (window)
        Form popupWindow = new Form();

        // Set the title of the window
        popupWindow.Text = "Popup Window";

        // Set the size of the window
        popupWindow.Size = new System.Drawing.Size(300, 200);

        // Create a label to display some text in the window
        Label label = new Label();
        label.Text = "This is a popup window!";
        label.Dock = DockStyle.Fill; // Dock the label to fill the window
        label.TextAlign = ContentAlignment.MiddleCenter; // Center the text

        // Add the label to the window's controls
        popupWindow.Controls.Add(label);

        // Show the popup window
        Application.Run(popupWindow);
    }
}
