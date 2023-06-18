using LeylaEditor.GameProject;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace LeylaEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string LeylaPath { get; private set; } = @"D:\Rider-Leyla\Leyla";
		public MainWindow()
		{
			InitializeComponent();
			Loaded += OnMainWindowLoaded;
			Closing += OnMainWindowClosing;
		}

		private void GetEnginePath()
		{
			var leylaPath = Environment.GetEnvironmentVariable("LEYLA_ENGINE", EnvironmentVariableTarget.User);
			if (leylaPath == null || !Directory.Exists(Path.Combine(leylaPath, @"Engine\EngineAPI")))
			{
				var dlg = new EnginePathDialog();
				if (dlg.ShowDialog() == true)
				{
					LeylaPath = dlg.LeylaPath;
					Environment.SetEnvironmentVariable("LEYLA_ENGINE", LeylaPath.ToUpper(), EnvironmentVariableTarget.User);
				}
				else
				{
					Application.Current.Shutdown();
				}
			}
			else
			{
				LeylaPath = leylaPath;
			}
		}
		
		private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
		{
			Loaded -= OnMainWindowLoaded;
			GetEnginePath();
			OpenProjectBrowserDialog();
		}

		private void OnMainWindowClosing(object? sender, CancelEventArgs e)
		{
			Closing -= OnMainWindowClosing;
			Project.Current?.Unload();
		}

		private void OpenProjectBrowserDialog()
		{
			var projectBrowser = new ProjectBrowserDialog();
			if (projectBrowser.ShowDialog() == false || projectBrowser.DataContext == null)
			{
				Application.Current.Shutdown();
			}
			else
			{
				Project.Current?.Unload();
				DataContext = projectBrowser.DataContext;
			}
		}
	}
}
