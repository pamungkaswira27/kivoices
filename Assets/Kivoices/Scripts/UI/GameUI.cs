using Kivoices.Scripts.Manager;
using Kivoices.Scripts.ScriptableObjects;
using System;
using TMPro;
using UnityEngine;

namespace Kivoices.Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI _voiceTranscriptionText;
        [SerializeField] private AnswerButton[] _answerButtons;

        private void OnEnable()
        {
            GameEventManager.OnGetQuestionEvent += SetupGameUI;
        }

        private void OnDisable()
        {
            GameEventManager.OnGetQuestionEvent -= SetupGameUI;
        }

        private void SetupGameUI(QuestionSO question, Action<bool> answerButtonCallback)
        {
            _voiceTranscriptionText.text = $"{question.GetVoiceTranscript()}";

            for (int i = 0; i < question.Answers.Count; i++)
            {
                _answerButtons[i].SetupAnswerButton(question.Answers[i], answerButtonCallback);
            }
        }
    }
}