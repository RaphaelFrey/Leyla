using System.Windows;

namespace LeylaEditor.Utilities.Controls;

internal class ScalarBox : NumberBox
{
    static ScalarBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ScalarBox),
            new FrameworkPropertyMetadata(typeof(ScalarBox)));
    }
}