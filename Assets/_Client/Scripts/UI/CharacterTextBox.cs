using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _textSpeed;
    [SerializeField] private string[] lines;
    private int index;

    private void Start()
    {
        _textMeshPro.text = string.Empty;
    }

    /*public void StartLine(string[] lines)
    {
        index = 0;
        StartCoroutine(TypeLine(lines));
    }

    IEnumerable TypeLine(string[] lines)
    {
        foreach(char c in lines[index].ToCharArray())
        {
            _textMeshPro.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }


    private void NextLine(string[] lines)
    {
        if (index < lines.Length - 1)
        {
            index++;
            _textMeshPro.text = string.Empty;

            StartCoroutine(TypeLine(lines));
        }
    }*/

    private void PushText()
    {
        if (index == lines.Length)
        {
            index = 0;
            _textMeshPro.text = string.Empty;
        }
        else
        {
            _textMeshPro.text = lines[index];
            index++;
        }
    }

    public void SetText(string[] lines)
    {
        this.lines = lines;
        PushText();
    }
}
