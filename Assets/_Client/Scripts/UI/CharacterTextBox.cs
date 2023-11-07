using System.Collections;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private float _textSpeed;
    [SerializeField] private float _waitSecondsToNextline;

    private string[] _sentences;
    private int _index;

    public void Initialize() 
    {
        _textComponent.text = null;
    }   

    private void StartDialogue()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine() 
    {
        _textComponent.text = string.Empty;
        for (int i = 0; i < _sentences[_index].Length; i++)
        {
            _textComponent.text += _sentences[_index][i];
            yield return new WaitForSeconds(_textSpeed);
        }
        StartCoroutine(WaitToNextLine());
    }
    private IEnumerator WaitToNextLine()
    {
        yield return new WaitForSeconds(_waitSecondsToNextline);
        NextLine();
    }

    private void NextLine()
    {

        if (_index < _sentences.Length - 1)
        {
            _index++;
            StartCoroutine(TypeLine());
        }
        else if(_index == _sentences.Length - 1)
        {
            ResetParametrs();
        }
    }

    private void ResetParametrs()
    {
        _textComponent.text = null;
        _sentences = null;
        _index = 0;
    }

    public void SetText(string[] lines)
    {
        if (lines == null)
        {
            return;
        }
        else
        {
            if (_index == 0)
            {
                _sentences = lines;
                StartDialogue();
                return;
            }
            else if (_textComponent.text == _sentences[_index])
            {
                if (_index == _sentences.Length - 1)
                {
                    ResetParametrs();
                    return; 
                }
                StopAllCoroutines();
                NextLine();
                return;
            }
            else if (_textComponent.text != _sentences[_index])
            {
                StopAllCoroutines();
                _textComponent.text = _sentences[_index];
                return;
            }
        }
    }
}
