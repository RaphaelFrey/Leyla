﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Path = System.IO.Path;

namespace LeylaEditor.Utilities;

[Flags]
public enum MessageType
{
    Info = 0x01,
    Warning = 0x02,
    Error = 0x04
}

public class LogMessage
{
    public DateTime Time { get; }
    public MessageType MessageType { get; }
    public string Message { get; }
    public string File { get; }
    public string Caller { get; }
    public int Line { get; }
    public string MetaData => $"{File}: {Caller} ({Line})";

    public LogMessage(MessageType messageType, string message, string file, string caller, int line)
    {
        Time = DateTime.Now;
        MessageType = messageType;
        Message = message;
        File = Path.GetFileName(file);
        Caller = caller;
        Line = line;
    }
}

public static class Logger
{
    private static int _messageFilter = (int)(MessageType.Info | MessageType.Warning | MessageType.Error);
    private static ObservableCollection<LogMessage> _messages = new();
    public static ReadOnlyObservableCollection<LogMessage> Messages { get; } = new(_messages);
    public static CollectionViewSource FilteredMessages { get; } = new() { Source = Messages };

    public static async void Log(MessageType type, string msg,
        [CallerFilePath]string file="", [CallerMemberName]string caller="",
        [CallerLineNumber]int line = 0)
    {
        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            _messages.Add(new LogMessage(type, msg, file, caller, line));
        }));
    }

    public static async void Clear()
    {
        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            _messages.Clear();
        }));
    }

    public static void SetMessageFilter(int mask)
    {
        _messageFilter = mask;
        FilteredMessages.View.Refresh();
    }

    static Logger()
    {
        FilteredMessages.Filter += (s, e) =>
        {
            var type = (int)(e.Item as LogMessage).MessageType;
            e.Accepted = (type & _messageFilter) != 0;
        };
    }
}