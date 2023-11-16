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
        ResetParametrs();
    }   

    private IEnumerator TypeLine() 
    {
        foreach(char c in _sentences[_index].ToCharArray())
        {
            _textComponent.text += c;   
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private IEnumerator WaitToNextLine()
    {
        yield return new WaitForSeconds(_waitSecondsToNextline);
    }

    private void Dialogue()
    {
        for(int _index = 0; _index < _sentences.Length; _index++)
        {
            _textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            StartCoroutine(WaitToNextLine());
        }

        ResetParametrs();
    }

    private void ResetParametrs()
    {
        _textComponent.text = string.Empty;
        _sentences = null;
    }

    private void StartDialogue(string[] lines)
    {
        _sentences = lines;
        Dialogue();
    }

    public void SetText(string[] lines)
    {
        if (lines != _sentences)
        {
            if(_sentences != null)
            {
                StopAllCoroutines();
                ResetParametrs();
            }

            StartDialogue(lines);
        }
    }
}
