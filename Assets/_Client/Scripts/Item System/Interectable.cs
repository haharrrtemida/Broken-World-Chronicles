using UnityEngine;

public abstract class Interectable : MonoBehaviour
{
    [SerializeField] protected string[] _lines;
    [SerializeField] private Transform _interactionPoint;

    public Transform InteractionPoint => _interactionPoint;

    protected virtual void OnMouseDown()
    {
        print("Mouse clicked on " + gameObject.name);
    }

    public virtual void Interact()
    {
        print(gameObject.name + ": Interact!");
        Player.Instance.CharacterTextBox.SetText(_lines);
    }
}