using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Tum", fileName = "new Tum")]
public class TumSO : CharacterSO
{
    public override void Activate()
    {   
        MonoBehaviour.print("i am tun and i was activate"); 
    }
}