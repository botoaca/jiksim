using Godot;

public class Notification : Control
{
    private AnimationPlayer anim;

    public override void _Ready()
    {
        anim = GetNode<AnimationPlayer>("AnimationPlayer"); // Reference to AnimationPlayer Node in the hierarchy
    }

    private async void _OnClosePressed()
    {
        anim.Play("notification.hide");
        await ToSignal(anim, "animation_finished");
        QueueFree(); // Delete the node after the animation is done
    }

    private void _OnVotePressed()
    {
        _OnClosePressed();
        System.Diagnostics.Process.Start("https://top.gg/bot/493904957523623936/vote");
        // HIBIKI GOOD BOT PLEASE VOTE!!
        // (c) 2016, 2017, 2018, 2019, 2020, 2021 jiktim
    }
}
