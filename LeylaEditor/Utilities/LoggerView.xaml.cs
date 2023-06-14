﻿using System.Windows;
using System.Windows.Controls;

namespace LeylaEditor.Utilities;

public partial class LoggerView : UserControl
{
    public LoggerView()
    {
        InitializeComponent();
    }

    private void OnClear_Button_Click(object sender, RoutedEventArgs e)
    {
        Logger.Clear();
    }

    private void OnMessageFilter_Button_Click(object sender, RoutedEventArgs e)
    {
        var filter = 0x0;
        if (toggleInfo.IsChecked == true) filter |= (int)MessageType.Info;
        if (toggleWarnings.IsChecked == true) filter |= (int)MessageType.Warning;
        if (toggleError.IsChecked == true) filter |= (int)MessageType.Error;
        Logger.SetMessageFilter(filter);
    }
}