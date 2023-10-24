using UnityEngine;

[CreateAssetMenu(menuName = "Capabilities/CapabilitiesSO", fileName = "New capabilities")]
public class OllCraftSO : CapabilitiesSO
{
    public override void Activate()
    {
        MonoBehaviour.print("craft mda craft");
    }
}