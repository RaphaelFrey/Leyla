using System.Windows.Controls;

namespace LeylaEditor.Editors;

public partial class GameEntityView : UserControl
{
    public static GameEntityView Instance { get; private set; }
    public GameEntityView()
    {
        InitializeComponent();
        DataContext = null;
        Instance = this;
    }
}