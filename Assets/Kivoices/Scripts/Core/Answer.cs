namespace Kivoices.Scripts.Core
{
    using UnityEngine;

    [System.Serializable]
    public class Answer
    {
        public string Id;
        public string Text;
        [HideInInspector] public bool IsCorrect;
    }
}
