using Kivoices.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Kivoices.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "QuestionPack", menuName = "Kivoices/ScriptableObject/QuestionPack")]
    public class QuestionPackSO : ScriptableObject
    {
        [Header("Questions")]
        [SerializeField] private List<QuestionSO> _questions;

        private List<QuestionSO> _randomQuestions;

        public void Initialize()
        {
            _randomQuestions= new List<QuestionSO>();

            foreach (QuestionSO question in _questions)
            {
                _randomQuestions.Add(question);
            }

            _randomQuestions = ListExtension<QuestionSO>.ShuffleList(_randomQuestions);
        }

        public QuestionSO GetQuestion()
        {
            if (_randomQuestions.Count == 0)
            {
                return null;
            }

            QuestionSO question = _randomQuestions[0];
            question.Initialize();
            _randomQuestions.RemoveAt(0);
            return question;
        }
    }
}