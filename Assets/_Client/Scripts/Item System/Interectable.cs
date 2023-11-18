using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    [SerializeField] protected string[] _lines;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private string _name;

    public Transform InteractionPoint => _interactionPoint;
    
    protected virtual void OnMouseDown()
    {
       print("Mouse clicked on " + gameObject.name);
    }
    
    public virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
    }

    private void OnMouseEnter()
    {
        UIManager.Instance.ChangeCurrentInteractableText(_name);
    }

    private void OnMouseExit()
    {
        UIManager.Instance.ChangeCurrentInteractableText("None");
    }
}