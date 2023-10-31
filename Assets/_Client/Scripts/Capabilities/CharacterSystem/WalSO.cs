using UnityEngine;


[CreateAssetMenu(menuName = "Characters/Wal", fileName = "new Tum")]
public class WalSO : CharacterSO
{
    [HideInInspector] public bool isSwitch = false;

    private bool _wiresIsActive = false;

    public override void Activate()
    {
        MonoBehaviour.print("I am oll and i will somthing do");
    }

    public void OpenCraft()
    {
        MonoBehaviour.print("Opncgaa");
    }

    public void HZChtotoIwiee()
    {
        MonoBehaviour.print("fefee");
    }

    public void SwitchOnWires()
    {
        if (!_wiresIsActive)
        {
            Camera.main.cullingMask += (1 << LayerMask.NameToLayer("Wires"));
        }
        else
        {
            Camera.main.cullingMask -= (1 << LayerMask.NameToLayer("Wires"));
        }
    }

    public void SwitchLight()
    {
        if (isSwitch)
        {
            isSwitch = false;
        }
        else
        {
            isSwitch = true;
        }
    }
}