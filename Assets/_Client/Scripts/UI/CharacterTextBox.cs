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
        _textComponent.text = string.Empty;
        for (int i = 0; i < _sentences[index].Length; i++)
        {
            _textComponent.text += _sentences[index][i];
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
        if(index < _sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            _textComponent.text = string.Empty;
            _sentences = null;
        }
    }

    public void SetText(string[] lines)
    {
        if (lines == null) return;
        if(_sentences != lines)
        {
            _sentences = lines;
            StartDialogue();
        }
        else if(_textComponent.text == _sentences[index])
        {
            NextLine();
        }    
        else if (_textComponent.text != _sentences[index])
        {
            StopAllCoroutines();
            _textComponent.text = _sentences[index];
        }
    }
}
