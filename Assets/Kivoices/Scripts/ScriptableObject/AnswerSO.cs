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
            List<Answer> tempAnswer = new List<Answer>();

            foreach (Answer answer in _answerList)
            {
                tempAnswer.Add(answer);
            }
            
            List<Answer> randomAnswers = new List<Answer>();

            // Get correct answer
            Answer correctAnswer = tempAnswer.Find((answer) => answer.Id.ToLower().Trim().Equals(answerId.ToLower().Trim()));
            correctAnswer.IsCorrect = true;
            randomAnswers.Add(correctAnswer);
            tempAnswer.Remove(correctAnswer);

            // Get random incorrect answers
            for (int i = 0; i < _maxAnswerCount - 1; i++)
            {
                int randomIndex = Random.Range(0, tempAnswer.Count);
                Answer randomAnswer = tempAnswer[randomIndex];
                randomAnswer.IsCorrect = false;
                randomAnswers.Add(randomAnswer);
                tempAnswer.RemoveAt(randomIndex);
            }

            // Randomize answers
            randomAnswers = ListExtension<Answer>.ShuffleList(randomAnswers);

            return randomAnswers;
        }
    }
}