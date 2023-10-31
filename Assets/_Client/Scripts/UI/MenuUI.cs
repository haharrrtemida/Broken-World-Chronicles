using UnityEngine;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private MenuScript _menu;
    [SerializeField] private VisualTreeAsset _setting;
    private VisualElement _settingsButton;
    private VisualElement contaner;
    private VisualElement menu;

    private void OnEnable()
    {
        contaner = GetComponent<UIDocument>().rootVisualElement;
        menu = contaner.Q<VisualElement>("Menu");

        Button _play = contaner.Q<Button>("ButtonPlay");
        Button _settings = contaner.Q<Button>("ButtonSettings");
        Button _exit = contaner.Q<Button>("ButtonExit");

        _settingsButton = _setting.CloneTree();
        var backButton = _settingsButton.Q<Button>("ButtonBack");

        _play.clicked += () => _menu.Play();
        _settings.clicked += () => OpenSettings();
        _exit.clicked += () => _menu.Exit();
        backButton.clicked += () => BackToMenu();
    }

    private void OpenSettings()
    {
        contaner.Clear();
        contaner.Add(_settingsButton);
    }

    private void BackToMenu()
    {
        contaner.Clear();
        contaner.Add(menu);
    }
}
