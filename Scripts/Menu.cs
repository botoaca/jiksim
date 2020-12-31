using Godot;

public class Menu : Control
{
    // The buttons' methods here are connected to the actual buttons with signals, they're pretty cool

    private void _OnPlayPressed()
    {
        GetTree().ChangeScene("res://Scenes/Game.tscn");
    }

    private void _OnQuitPressed()
    {
        GetTree().Quit();
    }
}
