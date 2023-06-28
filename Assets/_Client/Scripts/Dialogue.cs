using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private string[] _sentences;
    [SerializeField] private float _textSpeed;

    private int index;

    private void Start() 
    {
        _textComponent.text = string.Empty;
        StartDialogue();
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

    public void NextLine()
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
                gameObject.SetActive(false);
            }
        }
        else 
        {
            StopAllCoroutines();
            _textComponent.text = _sentences[index];
        }
    }

    private void OnMouseDown()
    {
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
