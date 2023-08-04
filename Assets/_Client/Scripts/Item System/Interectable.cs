using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    [SerializeField] protected string[] _lines;
    [SerializeField] private Transform _interactionPoint;

    public Transform InteractionPoint => _interactionPoint;

    protected virtual void OnMouseDown()
    {
        print("Mouse clicked on " + gameObject.name);
        //Player.Instance.CurrentInteractable = this;
    }

    public virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
        FindObjectOfType<CharacterTextBox>().SetText(_lines);
    }
}
