using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _textSpeed;
    private string[] _lines;
    private int _index;

    private void Start()
    {
        _textMeshPro.text = string.Empty;
    }

    private void NextLine()
    {
        if (_index < _lines.Length)
        {
            _index++;
            _textMeshPro.text = string.Empty;

            StartCoroutine(TypeLine(_lines[_index]));
        }
    }


    private IEnumerator TypeLine(string line)
    {
        foreach (char c in line)
        {
            _textMeshPro.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private IEnumerator PushText()
    {
        for (int _index = 0; _index < _lines.Length; _index++)
        {
            StartCoroutine(TypeLine(_lines[_index]));
            yield return new WaitForSeconds((_lines[_index].Length * _textSpeed) + 2);
            _textMeshPro.text = string.Empty;
        }
    }

    public void SetText(string[] lines)
    {
        if (this._lines != lines)
        {
            this._lines = lines;
            StopAllCoroutines();
            _textMeshPro.text = string.Empty;
            StartCoroutine(PushText());
        }
    }
}
