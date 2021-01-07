using Godot;

public class Program : Button
{
    private void _OnProgramPressed()
    {
        GetTree().ChangeScene("res://Scenes/3D.tscn");
    }
}
