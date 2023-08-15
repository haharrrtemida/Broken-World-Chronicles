using Artemida.Tools;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private const string _STEP_SOUND_PATH = "Sounds/StepSound";

    public void PlayStepSound() 
    {
        AudioClip stepSoundClip = (AudioClip)Resources.Load(_STEP_SOUND_PATH);
        AudioSystem.Instance.PlaySound(stepSoundClip, transform.position);
    }
}
