using Godot;
using System;

public class Taskbar : HBoxContainer
{
    private Label timeLabel;

    public override void _Ready()
    {
        timeLabel = GetNode<Label>("time");
    }

    public override void _Process(float delta)
    {
        if (timeLabel.Visible) timeLabel.Text = "> " + DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
    }

    private void _OnClockPressed() { timeLabel.Visible = !timeLabel.Visible; }
}
