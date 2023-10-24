using System.Collections;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private float _textSpeed;

    private string[] _sentences;
    private int index;

    public void Initialize() 
    {
        _textComponent.text = string.Empty;
    }   

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine() 
    {
        foreach (char c in _sentences[index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
         if(_textComponent.text == _sentences[index])
        {
            if(index < _sentences.Length - 1)
            {
                index++;
                _textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                _sentences = null;
                gameObject.SetActive(false);
            }
        }
        else 
        {
            StopAllCoroutines();
            _textComponent.text = _sentences[index];
        }
    }

    public void SetText(string[] lines)
    {
        if(_sentences != lines)
        {
            _sentences = lines;
            StartDialogue();
        }

        if(_textComponent.text == _sentences[index])
        {
            NextLine();
        }    
        else 
        {
            StopAllCoroutines();
            _textComponent.text = _sentences[index];
        }
    }
}
