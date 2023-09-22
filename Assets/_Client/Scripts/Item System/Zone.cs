using UnityEngine;

public class Zone : Interectable
{
    public override void Interact()
    {
        base.Interact();
        Player.Instance.CharacterTextBox.SetText(_lines);
    }
}