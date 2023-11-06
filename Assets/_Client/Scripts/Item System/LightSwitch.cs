using UnityEngine.Rendering.Universal;
using UnityEngine;

public class LightSwitch : InteractiveZone
{
    [SerializeField] private Light2D _localLight;

    private bool _isOn = false;

    public override void Activate()
    {
        if (CharactersManager.Instance.GetStateCharacter() == Characters.Wal)
        {
            if (!_isOn)
            {
                _localLight.gameObject.SetActive(true);
                _isOn = true;
            }
            else
            {
                _localLight.gameObject.SetActive(false);
                _isOn = false;
            }
        }
    }
}