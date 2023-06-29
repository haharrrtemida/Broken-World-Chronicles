using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    protected virtual void OnMouseDown()
    {
        print("Mouse clicked on " + gameObject.name);
        Interact();
    }

    protected virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
    }
}
