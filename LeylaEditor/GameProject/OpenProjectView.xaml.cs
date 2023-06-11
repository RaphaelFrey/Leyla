using System.Windows;
using System.Windows.Controls;

namespace LeylaEditor.GameProject
{
	/// <summary>
	/// Interaction logic for OpenProjectView.xaml
	/// </summary>
	public partial class OpenProjectView : UserControl
	{
		public OpenProjectView()
		{
			InitializeComponent();

			Loaded += (s, e) =>
			{
				var item = projectListBox.ItemContainerGenerator
				.ContainerFromIndex(projectListBox.SelectedIndex) as ListBoxItem;
				item?.Focus();
			};
		}

		private void OnOpen_Button_Click(object sender, RoutedEventArgs e)
		{
			OpenSelectedProject();	
		}

		private void OnListBoxItem_Mouse_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			OpenSelectedProject();
		}

		private void OpenSelectedProject()
		{
			var project = OpenProject.Open(projectListBox.SelectedItem as ProjectData);
			bool dialogeResult = false;
			var win = Window.GetWindow(this);
			if (project != null)
			{
				dialogeResult = true;
				win.DataContext = project;
			}
			win.DialogResult = dialogeResult;
			win.Close();
		}

	}
}
