using UnityEngine;


[CreateAssetMenu(menuName = "Characters/Wal", fileName = "new Tum")]
public class WalSO : CharacterSO
{
    private bool _wiresIsActive = false;

    public override void Initialize(bool state)
    {
        base.Initialize(state);
        _wiresIsActive = false;
    }

    public override void Activate()
    {
        MonoBehaviour.print("Current character is Wal");
        SwitchOnWires();
    }
    

    public override void Deactivate()
    {
        MonoBehaviour.print("Current character is not Wal");
        SwitchOffWires();
    }

    private void SwitchOnWires()
    {
        if (!_wiresIsActive)
        {
            Camera.main.cullingMask += (1 << LayerMask.NameToLayer("Wires"));
            _wiresIsActive = true;
        }
    }

    private void SwitchOffWires()
    {
        if(_wiresIsActive)
        {
            Camera.main.cullingMask -= (1 << LayerMask.NameToLayer("Wires"));
            _wiresIsActive = false;
        }
    }
}