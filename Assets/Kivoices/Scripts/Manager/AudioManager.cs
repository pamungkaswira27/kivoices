using Kivoices.Scripts.Utility;
using UnityEngine;

namespace Kivoices.Scripts.Manager
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Reference")]
        [SerializeField] private AudioSource _audioSource;

        public void PlaySound(AudioClip clip)
        {
            if (_audioSource.isPlaying)
            {
                return;
            }

            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void StopSound()
        {
            _audioSource.Stop();
            _audioSource.clip = null;
        }
    }
}