using System.Windows;
using System.Windows.Controls;

namespace LeylaEditor.GameProject
{
	/// <summary>
	/// Interaction logic for NewProjectView.xaml
	/// </summary>
	public partial class NewProjectView : UserControl
	{
		public NewProjectView()
		{
			InitializeComponent();
		}

		private void OnCreate_Button_Click(object sender, RoutedEventArgs e)
		{
			var vm = DataContext as NewProject;
			var projectPath = vm.CreateProject(templateListBox.SelectedItem as ProjectTemplate);
			bool dialogeResult = false;
			var win = Window.GetWindow(this);
			if (!string.IsNullOrEmpty(projectPath)) 
			{
				dialogeResult = true;
				var project = OpenProject.Open(new ProjectData() { ProjectName = vm.ProjectName, ProjectPath = projectPath });
				win.DataContext = project;
			}
			win.DialogResult = dialogeResult;
			win.Close();
		}
	}
}
