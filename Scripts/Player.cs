using System.Text;
using Godot;

public class Player : KinematicBody
{

    private int speed = 4;
    private float sens = 0.5f;
    private RayCast _raycast;
    private Label _memberLabel;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
        _raycast = GetNode<RayCast>("Camera/RayCast");
        _memberLabel = GetNode<Label>("JikName/Label");
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion @eventMouseMotion)
        {
            var rotationDegrees = RotationDegrees;
            rotationDegrees.y -= sens * @eventMouseMotion.Relative.x;
            RotationDegrees = rotationDegrees;
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsKeyPressed((int) KeyList.Escape) && Input.GetMouseMode() == Input.MouseMode.Captured) Input.SetMouseMode(Input.MouseMode.Visible);
        
        if (_raycast.IsColliding())
        {
            var body = _raycast.GetCollider();
            if (body.HasMethod("ShowName")) body.Call("ShowName");
        }
        else _memberLabel.Text = string.Empty;

        var moveVector = new Vector3();
        if (Input.IsKeyPressed((int)KeyList.W)) moveVector.z -= 1;
        if (Input.IsKeyPressed((int)KeyList.S)) moveVector.z += 1;
        if (Input.IsKeyPressed((int)KeyList.A)) moveVector.x -= 1;
        if (Input.IsKeyPressed((int) KeyList.D)) moveVector.x += 1;
        moveVector = moveVector.Normalized();
        moveVector = moveVector.Rotated(new Vector3(0, 1, 0), Rotation.y);
        MoveAndCollide(moveVector * speed * delta);
    }
}