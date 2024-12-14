using Kivoices.Scripts.Core;
using Kivoices.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Kivoices.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Answer", menuName = "Kivoices/ScriptableObject/Answer")]
    public class AnswerSO : ScriptableObject
    {
        [Header("Answer")]
        [SerializeField] private List<Answer> _answerList;
        [SerializeField] private int _maxAnswerCount;

        public List<Answer> GetRandomizeAnswer(string answerId)
        {
            List<Answer> randomAnswers = new List<Answer>();

            // Get correct answer
            Answer correctAnswer = _answerList.Find((answer) => answer.Id == answerId);
            correctAnswer.IsCorrect = true;
            randomAnswers.Add(correctAnswer);

            // Get random incorrect answers
            for (int i = 0; i < _maxAnswerCount; i++)
            {
                Answer randomAnswer = _answerList.Find((answer) => answer.Id != answerId);
                randomAnswers.Add(randomAnswer);
            }

            // Randomize answers
            randomAnswers = ListExtension<Answer>.ShuffleList(randomAnswers);

            return randomAnswers;
        }
    }
}