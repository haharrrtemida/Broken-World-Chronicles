using UnityEngine;
using System;

[Serializable]
public class Tun : Character
{
    public override void Activate()
    {   
        MonoBehaviour.print("i am tun and i was activate"); 
    }
}