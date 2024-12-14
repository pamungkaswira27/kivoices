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

        public QuestionSO GetQuestion()
        {
            List<QuestionSO> randomQuestions = ListExtension<QuestionSO>.ShuffleList(_questions);
            QuestionSO question = randomQuestions[0];
            randomQuestions.RemoveAt(0);
            return question;
        }
    }
}