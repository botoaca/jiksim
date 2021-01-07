using Godot;

public class Player : KinematicBody
{

    private int speed = 4;
    private float sens = 0.5f;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
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