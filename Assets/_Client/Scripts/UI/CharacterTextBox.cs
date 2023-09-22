using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _textSpeed;
    private string[] lines;
    private int index;

    public void Initialize ()
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
        for (index = 0; index < lines.Length; index++)
        {
            StartCoroutine(TypeLine(index));
            yield return new WaitForSeconds(5);
            _textMeshPro.text = string.Empty;
        }
        lines = null;
    }

    public void SetText(string[] lines)
    {
        if (lines != this.lines)
        {
            this.lines = lines;
            StartCoroutine(PushText());
        }
        else 
        {
            StopCoroutine(TypeLine(index));
            _textMeshPro.text = string.Empty;
            _textMeshPro.text = lines[index];
        }
    }
}
