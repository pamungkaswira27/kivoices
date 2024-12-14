using Kivoices.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Kivoices.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Question", menuName = "Kivoices/ScriptableObject/Question")]
    public class QuestionSO : ScriptableObject
    {
        [Header("Question")]
        [SerializeField] private string _id;
        [SerializeField] private AudioClip _voiceClip;
        [TextArea(3, 6)]
        [SerializeField] private string _voiceTranscript;

        [Header("Answer")]
        [SerializeField] private AnswerSO _answer;

        public List<Answer> Answers { get; private set; }

        public void Initialize()
        {
            Answers = _answer.GetRandomizeAnswer(_id);
        }

        public AudioClip GetVoiceClip()
        {
            return _voiceClip;
        }

        public string GetVoiceTranscript()
        {
            return _voiceTranscript;
        }
    }
}