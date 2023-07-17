using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _textSpeed;
    private string[] lines;

    private void Start()
    {
        _textMeshPro.text = string.Empty;
    }

    private IEnumerator TypeLine(int numberLine)
    {
        foreach (char c in lines[numberLine])
        {
            _textMeshPro.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private IEnumerator PushText()
    { 
        for (int i = 0; i < lines.Length; i++)
        {
            StartCoroutine(TypeLine(i));
            yield return new WaitForSeconds(5);
            _textMeshPro.text = string.Empty;
        }

    }

    public void SetText(string[] lines)
    {
        if (this.lines != lines)
        {
            StopAllCoroutines();
            _textMeshPro.text = string.Empty;
            this.lines = lines;
            StartCoroutine(PushText());
        }
    }
}
