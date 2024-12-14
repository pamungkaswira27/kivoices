using Kivoices.Scripts.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kivoices.Scripts.UI
{
    public class AnswerButton : MonoBehaviour
    {
        [Header("UI Reference")]
        [SerializeField] private TextMeshProUGUI _buttonText;

        private Button _button;
        private bool _isAnswerCorrect;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetupAnswerButton(Answer answer, Action<bool> answerButtonCallback)
        {
            _buttonText.text = answer.Text;
            _isAnswerCorrect = answer.IsCorrect;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => answerButtonCallback?.Invoke(_isAnswerCorrect));
        }
    }
}