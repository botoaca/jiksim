using Godot;

public class Game : Control
{
    private void _OnBackPressed()
    {
        GetTree().ChangeScene("res://Scenes/Menu.tscn");
    }
}
