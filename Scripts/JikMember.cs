using Godot;

public class JikMember : Spatial
{
    [Export]
    public new string Name = "missing";
    private Label _nameLabel;
    
    public override void _Ready()
    {
        _nameLabel = GetNode<Label>("../Player/JikName/Label");
    }

    public void ShowName()
    {
        _nameLabel.Text = Name;
    }
}
