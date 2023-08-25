using Artemida.Tools;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private const string _STEP_SOUND_PATH = "Sounds/PlayerSounds/Steps/StepSound0";

    public void PlayStepSound() 
    {
        AudioClip CurrentStepSoundClip = (AudioClip)Resources.Load(_STEP_SOUND_PATH + Random.Range(1,7));
        AudioSystem.Instance.PlaySound(CurrentStepSoundClip, transform.position);
    }
}