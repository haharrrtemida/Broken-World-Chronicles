using UnityEngine;

namespace Artemida.Tools
{
    public class AudioSystem : PersistentSingleton<AudioSystem>
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _soundSource;
        [SerializeField] private AudioBase _audioBase;

        public AudioBase AudioBase => _audioBase;

        public void PlayMusic(AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        public void PlaySound(AudioClip clip, Vector3 pos, float volume = 1)
        {
            _soundSource.transform.position = pos;
            PlaySound(clip, volume);
        }

        public void PlaySound(AudioClip clip, float volume = 1)
        {
            _soundSource.PlayOneShot(clip, volume);
        }
    }
}