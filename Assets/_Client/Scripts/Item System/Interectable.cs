using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    [SerializeField] protected string[] lines;

    protected virtual void OnMouseDown()
    {
        print("Mouse clicked on " + gameObject.name);
        Interact();
    }

    protected virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
        FindObjectOfType<CharacterTextBox>().SetText(lines);

    }
}
