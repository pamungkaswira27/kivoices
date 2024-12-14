using Kivoices.Scripts.Manager;
using UnityEngine;

namespace Kivoices.Scripts.UI
{
    public class VoiceButton : MonoBehaviour
    {
        private AudioClip _voiceClip;

        public void SetupVoiceButton(AudioClip voiceClip)
        {
            _voiceClip = voiceClip;
        }

        public void PlayVoice()
        {
            AudioManager.Instance.PlaySound(_voiceClip);
        }
    }
}