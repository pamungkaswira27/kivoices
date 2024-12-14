using Kivoices.Scripts.ScriptableObjects;
using Kivoices.Scripts.Utility;
using UnityEngine;

namespace Kivoices.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Question Pack")]
        [SerializeField] private QuestionPackSO _selectedQuestionPack;

        private QuestionSO _currentQuestion;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _selectedQuestionPack.Initialize();
            GetNextQuestion();
        }

        private void GetNextQuestion()
        {
            _currentQuestion = _selectedQuestionPack.GetQuestion();

            if (_currentQuestion == null)
            {
                Debug.Log("Game end");
                GameEventManager.OnGameEndEvent?.Invoke();
                return;
            }

            GameEventManager.OnGetQuestionEvent?.Invoke(_currentQuestion, DoAnswer);
        }

        private void DoAnswer(bool isCorrect)
        {
            if (isCorrect)
            {
                Debug.Log("Answer is correct");
            }
            else
            {
                Debug.Log("Answer is incorrect");
            }

            GetNextQuestion();
        }
    }
}