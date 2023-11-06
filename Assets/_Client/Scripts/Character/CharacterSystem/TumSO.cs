using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Tum", fileName = "new Tum")]
public class TumSO : CharacterSO
{
    public override void Activate()
    {   
        MonoBehaviour.print("Current Character is Tum"); 
        LoadCraft();
    }

    public override void Deactivate()
    {
        MonoBehaviour.print("Current Character is not Tum");
        ScenesManager.Instance.CloseInventory();
    }

    private void LoadCraft()
    {
        ScenesManager.Instance.OpenInventory(InventoryMode.Craft);
    }
}