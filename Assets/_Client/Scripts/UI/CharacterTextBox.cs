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
    }

    private void NextLine()
    {
        for(int i = 0; i < _sentences.Length; i++)
        {
            StartCoroutine(TypeLine());
            StartCoroutine(WaitToNextLine());
            _index++;
        }

        ResetParametrs();
    }

    private void ResetParametrs()
    {
        _textComponent.text = null;
        _sentences = null;
        _index = 0;
    }

    public void SetText(string[] lines)
    {
        if (lines == null || lines == _sentences)
        {
            return;
        }
        else
        {
            _sentences = lines;
            NextLine();
        }
    }
}
