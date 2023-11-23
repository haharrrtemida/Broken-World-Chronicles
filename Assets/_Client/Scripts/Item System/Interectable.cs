using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    [SerializeField] protected string[] _lines;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private string _name;

    public Transform InteractionPoint => _interactionPoint;
    
    public void OnClick()
    {
       print("Mouse clicked on " + gameObject.name);
       Player.Instance.Move(this);
    }
    
    public virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
    }

    public void OnEnter()
    {
        UIManager.Instance.ChangeCurrentInteractableText(_name);
    }

    public void OnExit()
    {
        UIManager.Instance.ChangeCurrentInteractableText("None");
    }
}