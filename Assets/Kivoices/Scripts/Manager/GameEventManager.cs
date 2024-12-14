using Kivoices.Scripts.ScriptableObjects;
using System;
using UnityEngine;

namespace Kivoices.Scripts.Manager
{
    public class GameEventManager : MonoBehaviour
    {
        public static Action<QuestionSO, Action<bool>> OnGetQuestionEvent;
        public static Action<bool, int> OnGameEndEvent;
    }
}