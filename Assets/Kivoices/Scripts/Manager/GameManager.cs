using Kivoices.Scripts.ScriptableObjects;
using Kivoices.Scripts.Utility;
using UnityEngine;

namespace Kivoices.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Question Pack")]
        [SerializeField] private QuestionPackSO _selectedQuestionPack;

        [Header("Player Data")]
        [SerializeField] private int _playerHealth;
        [SerializeField] private int _playerScore;

        [Header("Game Settings")]
        [SerializeField] private int _scorePerQuestion;

        private QuestionSO _currentQuestion;

        private int _currentHealth;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _currentHealth = _playerHealth;
            _playerScore = 0;
            _selectedQuestionPack.Initialize();
            GetNextQuestion();
        }

        private void GetNextQuestion()
        {
            _currentQuestion = _selectedQuestionPack.GetQuestion();

            if (_currentQuestion == null)
            {
                GameEventManager.OnGameEndEvent?.Invoke(true, _playerScore);
                return;
            }

            GameEventManager.OnGetQuestionEvent?.Invoke(_currentQuestion, DoAnswer);
        }

        private void DoAnswer(bool isCorrect)
        {
            if (isCorrect)
            {
                _playerScore += _scorePerQuestion;
                GameEventManager.OnAnswerCorrectEvent?.Invoke(_playerScore);
            }
            else
            {
                _currentHealth--;

                if (_currentHealth <= 0)
                {
                    _currentHealth = 0;
                    GameEventManager.OnGameEndEvent?.Invoke(false, 0);
                    return;
                }
            }

            AudioManager.Instance.StopSound();
            GetNextQuestion();
        }
    }
}