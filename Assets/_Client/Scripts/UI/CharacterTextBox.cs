using System.Collections;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _textSpeed;
    private string[] _lines;
    private int _index;

    public void Initialize ()
    {
        _textMeshPro.text = string.Empty;
    }

    private IEnumerator TypeLine(int numberLine)
    {
        foreach (char c in _lines[numberLine])
        {
            _textMeshPro.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private IEnumerator PushText()
    { 
        for (_index = 0; _index < _lines.Length; _index++)
        {
            StartCoroutine(TypeLine(_index));
            float waitToNextLine = _lines[_index].Length * _textSpeed + 1.5f;
            yield return new WaitForSeconds(waitToNextLine);
            _textMeshPro.text = string.Empty;
        }

        _lines = null;
    }

    public void SetText(string[] lines)
    {
        if (lines != _lines)
        {
            _lines = lines;
            StartCoroutine(PushText());
        }
        else 
        {
            StopAllCoroutines();
            _textMeshPro.text = string.Empty;
            _lines = null;
        }
    }
}
