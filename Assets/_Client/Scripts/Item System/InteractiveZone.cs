using UnityEngine;

public abstract class InteractiveZone : Interectable
{
    public override void Interact()
    {
        base.Interact();
        Activate();
    }

    public abstract void Activate();
}
