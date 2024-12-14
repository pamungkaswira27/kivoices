using Kivoices.Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Kivoices.Scripts.UI
{
    public class TopBarUI : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI _playerScoreText;

        private void OnEnable()
        {
            GameEventManager.OnAnswerCorrectEvent += SetScoreText;
        }

        private void Start()
        {
            SetScoreText(0);
        }

        private void OnDisable()
        {
            GameEventManager.OnAnswerCorrectEvent -= SetScoreText;
        }

        private void SetScoreText(int score)
        {
            _playerScoreText.text = score.ToString("000000");
        }
    }
}