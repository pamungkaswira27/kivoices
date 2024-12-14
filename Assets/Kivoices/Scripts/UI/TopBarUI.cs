using Kivoices.Scripts.Manager;
using Kivoices.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Kivoices.Scripts.UI
{
    public class TopBarUI : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private PlayerDataSO _playerData;

        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI _playerScoreText;
        [SerializeField] private TextMeshProUGUI _playerHealthText;

        private void OnEnable()
        {
            GameEventManager.OnAnswerCorrectEvent += SetScoreText;
            GameEventManager.OnAnswerWrongEvent += SetHealthText;
        }

        private void Start()
        {
            SetScoreText(0);
            SetHealthText(_playerData.GetInitialPlayerHealth());
        }

        private void OnDisable()
        {
            GameEventManager.OnAnswerCorrectEvent -= SetScoreText;
            GameEventManager.OnAnswerWrongEvent -= SetHealthText;
        }

        private void SetScoreText(int score)
        {
            _playerScoreText.text = score.ToString("000000");
        }

        private void SetHealthText(int health)
        {
            _playerHealthText.text = $"Health: {health}";
        }
    }
}