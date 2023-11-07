using UnityEngine;

public abstract class UITimeStopElement : MonoBehaviour 
{
    public virtual void Close()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }    
}